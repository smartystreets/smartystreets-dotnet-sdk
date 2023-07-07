Imports System.Formats
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USReverseGeoApi

Module USReverseGeoExample

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    Dim url = Environment.GetEnvironmentVariable("SMARTY_URL")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-reverse-geocoding-cloud"}).WithCustomBaseUrl(url).BuildUsReverseGeoApiClient()

    Sub USReverseGeoExample()

        Dim lookup As New Lookup(40.111111, -111.111111)

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

        Dim results = lookup.SmartyResponse.Results

        If results.Count = 0 Then
            Console.WriteLine("No candidates. This means the address is not valid.")
            Return
        End If

        Console.WriteLine("\nResults for input: (" + lookup.Latitude + ", " + lookup.Longitude)

        For Each result In results
            Dim coordinate = result.Coordinate
            Dim address = result.Address

            Console.WriteLine("\nLatitude: " + coordinate.Latitude)
            Console.WriteLine("Longitude: " + coordinate.Longitude)
            Console.WriteLine("Distance: " + result.Distance)
            Console.WriteLine("Street: " + address.Street)
            Console.WriteLine("City: " + address.City)
            Console.WriteLine("State Abbreviation: " + address.StateAbbreviation)
            Console.WriteLine("ZIP Code: " + address.ZipCode)
            Console.WriteLine("License: " + coordinate.License)
        Next

    End Sub

End Module
