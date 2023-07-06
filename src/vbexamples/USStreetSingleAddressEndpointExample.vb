﻿Imports System
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USStreetApi

Module USStreetSingleAddressEndpointExample

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")

    ' NOTE this Is how to point the SDK at an alternate installation
    ' for example, this might be used to connect through "stunnel" to handle things Like TLSv1.2 encryption
    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).WithCustomBaseUrl("http://127.0.0.1:8080/street-address").BuildUsStreetApiClient()

    Sub USStreetSingleAddressEndpointExample()

        Dim myLookup As New Lookup()
        With myLookup
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

        Try
            client.Send(myLookup)
        Catch ex As SmartyException
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
        Catch ex As IOException
            Console.WriteLine(ex.StackTrace)
        End Try

        Dim candidates = myLookup.Result

        If candidates.Count = 0 Then
            Console.WriteLine("No candidates. This means the address is not valid.")
            Return
        End If

        Dim firstCandidate = candidates(0)

        Console.WriteLine("Address is valid. (There is at least one candidate)")
        Console.WriteLine("Primary Number: " + firstCandidate.Components.PrimaryNumber)
        Console.WriteLine("Street: " + firstCandidate.Components.StreetName)
        Console.WriteLine("CityName: " + firstCandidate.Components.CityName)
        Console.WriteLine("State: " + firstCandidate.Components.State)
        Console.WriteLine("ZIP Code: " + firstCandidate.Components.ZipCode)
        Console.WriteLine("County: " + firstCandidate.Metadata.CountyName)
        Console.WriteLine("Latitude: " + firstCandidate.Metadata.Latitude.ToString)
        Console.WriteLine("Longitude: " + firstCandidate.Metadata.Longitude.ToString)

    End Sub

End Module
