Imports System
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USStreetApi

Module USStreetSingleAddressEndpointExample

    Sub USStreetSingleAddressEndpointExample()

        Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
        Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")

        ' NOTE this Is how to point the SDK at an alternate installation
        ' for example, this might be used to connect through "stunnel" to handle things Like TLSv1.2 encryption
        Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).WithCustomBaseUrl("http://127.0.0.1:8080/street-address").BuildUsStreetApiClient()

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
        Console.WriteLine("Original lookup: " + lookup.Street + ", " + lookup.Street2 + ", " + lookup.Secondary + ", " + lookup.City + ", " + lookup.State + ", " + lookup.ZipCode + Environment.NewLine())

        If candidates.Count = 0 Then
            Console.WriteLine("No candidates. The address is not valid." + Environment.NewLine)
            Return
        End If

        Console.WriteLine("Address has " + CStr(candidates.Count) + " candidate" + If(candidates.Count = 1, "", "s") + Environment.NewLine())

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
