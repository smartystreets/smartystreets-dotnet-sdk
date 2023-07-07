Imports System
Imports System.IO
Imports System.Reflection.Emit
Imports System.Windows
Imports SmartyStreets
Imports SmartyStreets.USStreetApi

Module USStreetMultipleAddressesExamples

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    Dim url = Environment.GetEnvironmentVariable("SMARTY_US_STREET_URL")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).WithCustomBaseUrl(url).BuildUsStreetApiClient()
    Dim batch = New Batch()

    Sub USStreetMultipleAddressesExamples()

        Dim address1 As New Lookup()
        With address1
            .InputId = "24601"
            .Addressee = "John Doe"
            .Street = "1600 Amphitheatre Pkwy"
            .Street2 = "closet under the stairs"
            .Secondary = "APT 2"
            .Urbanization = ""
            .City = "Mountain View"
            .State = "CA"
            .ZipCode = "21229"
            .MaxCandidates = 3
            .MatchStrategy = Lookup.INVALID
        End With

        Dim address2 As New Lookup()
        With address2
            .Street = "1 Rosedale"
            .Lastline = "Baltimore, Maryland"
            .MaxCandidates = 5
        End With

        Dim address3 As New Lookup()
        With address3
            .Street = "123 Bogus Street, Pretend Lake, Oklahoma"
        End With

        Dim address4 As New Lookup()
        With address4
            .InputId = "8675309"
            .Street = "1 Infinite Loop"
            .ZipCode = "95014"
            .MaxCandidates = 1
        End With

        Try
            batch.Add(address1)
            batch.Add(address2)
            batch.Add(address3)
            batch.Add(address4)
            client.Send(batch)
        Catch ex As BatchFullException
            Console.WriteLine("Error. The batch is already full.")
        Catch ex As SmartyException
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
        Catch ex As IOException
            Console.WriteLine(ex.StackTrace)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
        End Try

        Console.WriteLine("*******************************************************")

        For i As Integer = 0 To batch.Count - 1
            Dim candidates = batch(i).Result

            If candidates.Count = 0 Then
                Console.WriteLine("Address " + CStr(i) + " is invalid." + Environment.NewLine)
                Continue For
            End If

            Console.WriteLine("Address " + CStr(i) + " is valid. (There is at least one candidate)" + Environment.NewLine + "If the match parameter is set to STRICT, the address is valid." + Environment.NewLine + "Otherwise, check the Analysis output fields to see if the address is valid.")

            For Each candidate In candidates
                Console.WriteLine()
                Dim components = candidate.Components
                Dim metadata = candidate.metadata

                Console.WriteLine("Candidate " + CStr(candidate.CandidateIndex) + ":")
                Console.WriteLine("Input ID: " + candidate.InputId)
                Console.WriteLine("Delivery line 1: " + candidate.DeliveryLine1)
                Console.WriteLine("Last line:       " + candidate.LastLine)
                Console.WriteLine("ZIP Code:        " + components.ZipCode + "-" + components.Plus4Code)
                Console.WriteLine("County:          " + metadata.CountyName)
                Console.WriteLine("Latitude:        " + CStr(metadata.Latitude))
                Console.WriteLine("Longitude:       " + CStr(metadata.Longitude))
            Next

            Console.WriteLine()

        Next

        Console.WriteLine()

    End Sub

End Module
