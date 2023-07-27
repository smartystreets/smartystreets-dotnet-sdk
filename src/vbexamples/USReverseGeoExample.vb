Imports System.Formats
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USReverseGeoApi

Module USReverseGeoExample

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-reverse-geocoding-cloud"}).BuildUsReverseGeoApiClient()

    Sub USReverseGeoExample()

        Dim lookup As New Lookup(40.111111, -111.111111)

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

        Dim results = lookup.SmartyResponse.Results

        Console.WriteLine("Original lookup: Latitude: " + lookup.Latitude + " Longitude: " + lookup.Longitude + Environment.NewLine())

        If results.Count = 0 Then
            Console.WriteLine("No candidates. The coordinates did not return any results.")
            Return
        End If

        Console.WriteLine("Coordinates are valid." + Environment.NewLine())

        Console.WriteLine(CStr(results.Count) + " results for input (" + lookup.Latitude + ", " + lookup.Longitude + ")")

        For Each result In results
            Dim coordinate = result.Coordinate
            Dim address = result.Address
            Console.WriteLine()
            Console.WriteLine("Latitude: " + CStr(coordinate.Latitude))
            Console.WriteLine("Longitude: " + CStr(coordinate.Longitude))
            Console.WriteLine("Distance: " + CStr(result.Distance))
            Console.WriteLine("Street: " + address.Street)
            Console.WriteLine("City: " + address.City)
            Console.WriteLine("State Abbreviation: " + address.StateAbbreviation)
            Console.WriteLine("ZIP Code: " + address.ZipCode)
            Console.WriteLine("License: " + CStr(coordinate.License))
        Next

        Console.WriteLine()

    End Sub

End Module
