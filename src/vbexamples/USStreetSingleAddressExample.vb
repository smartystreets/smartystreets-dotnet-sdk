Imports System
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USStreetApi

Module USStreetSingleAddressExample

    Sub USStreetSingleAddressExample()

        Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
        Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
        Dim url = Environment.GetEnvironmentVariable("SMARTY_US_STREET_URL")

        Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).WithCustomBaseUrl(url).BuildUsStreetApiClient()

        Dim lookup As New Lookup()
        With lookup
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

        Dim candidates = lookup.Result

        If candidates.Count = 0 Then
            Console.WriteLine("No candidates. This means the address is not valid." + Environment.NewLine)
            Return
        End If

        Console.WriteLine("Address is valid. (There is at least one candidate)" + Environment.NewLine())

        Console.WriteLine("Input ID: " + lookup.InputId)

        For Each candidate In candidates
            Console.WriteLine()
            Dim components = candidate.Components
            Dim metadata = candidate.Metadata

            Console.WriteLine("Candidate " + CStr(candidate.CandidateIndex) + ":")
            Console.WriteLine("Delivery line 1: " + candidate.DeliveryLine1)
            Console.WriteLine("Last line:       " + candidate.LastLine)
            Console.WriteLine("ZIP Code:        " + components.ZipCode + "-" + components.Plus4Code)
            Console.WriteLine("County:          " + metadata.CountyName)
            Console.WriteLine("Latitude:        " + CStr(metadata.Latitude))
            Console.WriteLine("Longitude:       " + CStr(metadata.Longitude))
        Next

        Console.WriteLine()

    End Sub

End Module