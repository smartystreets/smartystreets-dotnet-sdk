Imports SmartyStreets.USExtractApi
Imports SmartyStreets
Imports System.IO
Imports System.Formats

Module USExtractExample

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).BuildUsExtractApiClient()

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

        Console.WriteLine("*******************************************************")
        Console.WriteLine()

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
        Dim addressCount = metadata.AddressCount
        Dim verifiedCount = metadata.VerifiedCount

        Console.WriteLine("Original lookup: " + lookup.Text + Environment.NewLine())

        Console.WriteLine("Extracted " + CStr(addressCount) + " address" + If(addressCount = 1, ".", "es."))
        Console.WriteLine(CStr(verifiedCount) + " of them " + If(addressCount = 1, "was", "were") + " valid.")
        Console.WriteLine()

        Dim addresses = result.Addresses

        If addressCount > 0 Then
            Console.WriteLine("Extracted address" + If(addressCount = 1, ":", "es:"))
        End If

        For Each address In addresses
            Console.WriteLine("""" + address.Text + """")
            Console.WriteLine("Verified? " + CStr(address.Verified) + Environment.NewLine)

            Dim candidatesCount = address.Candidates.Length

            If (candidatesCount > 0) Then
                Console.WriteLine("Found " + CStr(address.Candidates.Length) + " address match" + If(candidatesCount = 1, ":", "es:") + Environment.NewLine())

                For Each candidate In address.Candidates
                    Console.WriteLine(candidate.DeliveryLine1)
                    Console.WriteLine(candidate.LastLine)
                    Console.WriteLine()
                Next
            Else
                Console.WriteLine()
            End If

        Next

    End Sub

End Module
