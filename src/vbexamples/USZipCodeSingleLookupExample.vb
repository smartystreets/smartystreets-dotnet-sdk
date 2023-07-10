Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USZipCodeApi

Module USZipCodeSingleLookupExample

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    Dim url = Environment.GetEnvironmentVariable("SMARTY_US_ZIP_URL")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).WithCustomBaseUrl(url).BuildUsZipCodeApiClient()

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
            Console.WriteLine("ZIP has an invalid status.")
            Console.WriteLine("Status: " + result.Status)
            Console.WriteLine("Reason: " + result.Reason + Environment.NewLine)
            Return
        End If

        If zipCodes Is Nothing Or cities Is Nothing Then
            Console.WriteLine("No results. This means the ZIP code is not valid." + Environment.NewLine)
            Return
        End If

        Console.WriteLine("ZIP is valid. (There is at least one result)" + Environment.NewLine())

        Console.WriteLine("Input ID: " + result.InputId)

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
