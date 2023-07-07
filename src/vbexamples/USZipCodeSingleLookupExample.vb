Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USZipCodeApi

Module USZipCodeSingleLookupExample

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    Dim url = Environment.GetEnvironmentVariable("SMARTY_URL")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).WithCustomBaseUrl(url).BuildUsZipCodeApiClient()

    Sub USZipCodeSingleLookupExample()

        Dim lookup As New Lookup()
        With lookup
            .InputId = "dfc33cb6-829e-4fea-aa1b-b6d6580f0817"
            .City = "Mountain View"
            .State = "California"
            .ZipCode = "94039"
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
        Dim cities = result.CityStates
        Dim zipCodes = result.ZipCodes

        Console.WriteLine("Input ID: " + result.InputId)

        For Each city In cities
            Console.WriteLine("\nCity: " + city.City)
            Console.WriteLine("State: " + city.State)
            Console.WriteLine("Mailable City: " + city.MailableCity)
        Next

        For Each zipCode In zipCodes
            Console.WriteLine("\nZIP Code: " + zipCode.ZipCode)
            Console.WriteLine("Latitude: " + zipCode.Latitude)
            Console.WriteLine("Longitude: " + zipCode.Longitude)
        Next

    End Sub

End Module
