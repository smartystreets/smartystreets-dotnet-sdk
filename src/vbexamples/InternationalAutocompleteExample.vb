Imports System.Diagnostics.Metrics
Imports System.Formats
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.InternationalAutocompleteApi
Module InternationalAutocompleteExample
    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    Dim url = Environment.GetEnvironmentVariable("SMARTY_URL")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"international-autocomplete-cloud"}).WithCustomBaseUrl(url).BuildInternationalStreetApiClient()
    Sub InternationalAutocompleteExample()
        Dim lookup = New InternationalAutocompleteApi.Lookup("Louis")

        With lookup
            .Country = "FRA"
            .Locality = "Paris"
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

        Dim candidates = lookup.Result
        Console.WriteLine()
        Console.WriteLine("*** Results ***")

        For Each candidate In candidates
            Console.Write(candidate.Street)
            Console.Write(" ")
            Console.Write(candidate.Locality)
            Console.Write(", ")
            Console.WriteLine(candidate.CountryISO3)
        Next

    End Sub

End Module
