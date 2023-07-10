﻿Imports System.Formats
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USAutocompleteProApi

Module USAutocompleteProExample

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    Dim url = Environment.GetEnvironmentVariable("SMARTY_US_AUTOCOMPLETE_URL")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-autocomplete-pro-cloud"}).WithCustomBaseUrl(url).BuildUsAutocompleteProApiClient()

    Sub USAutocompleteProExample()

        Dim lookup As New Lookup("1042 W Center")
        With lookup
            .PreferGeolocation = "none"
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

        Console.WriteLine("Original lookup: " + lookup.Search + Environment.NewLine())

        If lookup.Result Is Nothing Then
            Console.WriteLine("No results. This means the address is not valid." + Environment.NewLine)
            Return
        End If

        Console.WriteLine("*** Result" + If(result.Count = 1, "", "s") + " with no filter ***" + Environment.NewLine)

        For Each suggestion In lookup.Result
            Console.WriteLine(suggestion.Street + " " + suggestion.City + ", " + suggestion.State)
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

        Console.WriteLine(Environment.NewLine + "*** Result" + If(suggestions.Count = 1, "", "s") + " with some filters ***" + Environment.NewLine)

        For Each suggestion In suggestions
            Console.WriteLine(suggestion.Street + " " + suggestion.City + ", " + suggestion.State)
        Next

        Console.WriteLine()
    End Sub

End Module
