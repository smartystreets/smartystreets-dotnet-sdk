Imports SmartyStreets.USExtractApi
Imports SmartyStreets
Imports System.IO
Imports System.Formats

Module USExtractExample

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    Dim url = Environment.GetEnvironmentVariable("SMARTY_URL")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).WithCustomBaseUrl(url).BuildUsExtractApiClient()

    Dim text = "Here is some text." + Environment.NewLine + "My address is 3785 Las Vegs Av." + Environment.NewLine +
                       "Los Vegas, Nevada." + Environment.NewLine +
                       "Meet me at 1 Rosedale Baltimore Maryland, not at 123 Phony Street, Boise Idaho."

    Sub USExtractExample()

        Dim lookup As New Lookup()
        With lookup
            .Text = text
            .IsAggressive = True
            .AddressesHaveLineBreaks = False
            .AddressesPerLine = 1
        End With

        Try
            client.Send(lookup)
        Catch ex As SmartyException
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
        Catch ex As IOException
            Console.WriteLine(ex.StackTrace)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
        End Try

        Dim result = lookup.Result
        Dim metadata = result.Metadata

        Console.WriteLine("Found " + CStr(metadata.AddressCount) + " addresses.")
        Console.WriteLine(metadata.VerifiedCount + " of them were valid.")
        Console.WriteLine()

        Dim addresses = result.Addresses

        Console.WriteLine("Addresses: " + Environment.NewLine + "**********************" + Environment.NewLine)

        For Each address In addresses
            Console.WriteLine("""" + address.Text + """" + Environment.NewLine)
            Console.WriteLine("Verified? " + address.Verified + Environment.NewLine)

            If (address.Candidates.Length > 0) Then
                Console.WriteLine("Matches:")

                For Each candidate In address.Candidates
                    Console.WriteLine(candidate.DeliveryLine1)
                    Console.WriteLine(candidate.LastLine)
                    Console.WriteLine()
                Next
            Else
                Console.WriteLine()
            End If

            Console.WriteLine("**********************" + Environment.NewLine)

        Next

    End Sub

End Module
