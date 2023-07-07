Imports System.Formats
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USAutocompleteProApi

Module USAutocompleteProExample

    Dim key = Environment.GetEnvironmentVariable("SMARTY_AUTH_WEB")
    Dim hostname = Environment.GetEnvironmentVariable("SMARTY_WEBSITE_DOMAIN")
    Dim credentials = New SharedCredentials(key, hostname)

    'Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    'Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    'Dim url = Environment.GetEnvironmentVariable("SMARTY_URL")

    Dim client = New ClientBuilder(credentials).WithLicense(New List(Of String) From {"us-autocomplete-pro-cloud"}).BuildUsAutocompleteProApiClient()

    Sub USAutocompleteProExample()

        Dim lookup As New Lookup("1042 W Center")
        With lookup
            .PreferGeolocation = "none"
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

        Console.WriteLine("*** Result with no filter ***" + Environment.NewLine)

        For Each suggestion In lookup.Result
            Console.WriteLine(suggestion.Street, suggestion.City, ", ", suggestion.State)
        Next

        lookup.AddStateFilter("CO")
        lookup.AddStateFilter("UT")
        lookup.AddCityFilter("Denver")
        lookup.AddCityFilter("Orem")
        lookup.AddPreferState("CO")
        lookup.AddPreferState("UT")
        'lookup.Selected = "1042 W Center St Apt A (24) Orem UT 84057"
        lookup.MaxResults = 5
        lookup.PreferGeolocation = GeolocateType.NONE
        lookup.PreferRatio = 4
        lookup.Source = "all"

        client.Send(lookup)

        Dim suggestions = lookup.Result

        Console.WriteLine(Environment.NewLine + "*** Result with some filters ***" + Environment.NewLine)

        For Each suggestion In suggestions
            Console.WriteLine(suggestion.Street, suggestion.City, ",", suggestion.State)
        Next

    End Sub

End Module
