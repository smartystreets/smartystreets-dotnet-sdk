Imports System.Diagnostics.Metrics
Imports System.Formats
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.InternationalAutocompleteApi
Module InternationalAutocompleteExample
    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    Dim url = Environment.GetEnvironmentVariable("SMARTY_INTERNATIONAL_AUTOCOMPLETE_URL")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"international-autocomplete-cloud"}).WithCustomBaseUrl(url).BuildInternationalAutocompleteApiClient()

    Sub InternationalAutocompleteExample()

        Dim lookup = New Lookup("Louis")
        With lookup
            .Country = "FRA"
            .Locality = "Paris"
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

        Console.WriteLine("Original lookup: " + lookup.Search + " " + lookup.Country + Environment.NewLine())

        If candidates Is Nothing Then
            Console.WriteLine("No results. The input is not valid." + Environment.NewLine)
            Return
        End If

        Console.WriteLine("*** Found " + CStr(candidates.Count) + " result" + If(candidates.Count = 1, "", "s") + " ***" + Environment.NewLine)

        For Each candidate In candidates
            Console.WriteLine(candidate.Street + " " + candidate.Locality + ", " + candidate.CountryISO3)
        Next

        Console.WriteLine()

    End Sub

End Module
