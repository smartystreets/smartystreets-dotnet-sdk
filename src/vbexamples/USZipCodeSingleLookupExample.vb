Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USZipCodeApi

Module USZipCodeSingleLookupExample

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).BuildUsZipCodeApiClient()

    Sub USZipCodeSingleLookupExample()

        Dim lookup As New Lookup()
        With lookup
            .InputId = "dfc33cb6-829e-4fea-aa1b-b6d6580f0817"
            .City = "Mountain View"
            .State = "California"
            .ZipCode = "94039"
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
        Dim cities = result.CityStates
        Dim zipCodes = result.ZipCodes

        If result.Status IsNot Nothing Then
            Console.WriteLine("Lookup has an invalid status.")
            Console.WriteLine("Status: " + result.Status)
            Console.WriteLine("Reason: " + result.Reason + Environment.NewLine)
            Return
        End If

        If zipCodes Is Nothing Or cities Is Nothing Then
            Console.WriteLine("Lookup has no candidates. The lookup is not valid." + Environment.NewLine)
            Return
        End If

        Console.WriteLine("Lookup is valid." + Environment.NewLine())

        Console.WriteLine("Input ID: " + result.InputId)

        Console.WriteLine(CStr(cities.Length) + " city and state match" + If(cities.Length = 1, ":", "es:"))

        For Each city In cities
            Console.WriteLine()
            Console.WriteLine("City: " + city.City)
            Console.WriteLine("State: " + city.State)
            Console.WriteLine("Mailable City: " + CStr(city.MailableCity))
        Next

        For Each zipCode In zipCodes
            Console.WriteLine()
            Console.WriteLine("ZIP Code: " + zipCode.ZipCode)
            Console.WriteLine("Latitude: " + CStr(zipCode.Latitude))
            Console.WriteLine("Longitude: " + CStr(zipCode.Longitude))
        Next

        Console.WriteLine()

    End Sub

End Module
