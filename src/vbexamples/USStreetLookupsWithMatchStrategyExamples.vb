Imports System.IO
Imports System.Text.RegularExpressions
Imports SmartyStreets
Imports SmartyStreets.USStreetApi

Module USStreetLookupsWithMatchStrategyExamples

    Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
    Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
    Dim url = Environment.GetEnvironmentVariable("SMARTY_US_STREET_URL")

    Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).WithCustomBaseUrl(url).BuildUsStreetApiClient()
    Dim batch = New Batch()

    Sub USStreetLookupsWithMatchStrategyExamples()

        Dim addressWithStrictStrategy As New Lookup()
        With addressWithStrictStrategy
            .Street = "691 W 1150 S"
            .City = "provo"
            .State = "utah"
            .MatchStrategy = Lookup.STRICT
        End With

        Dim addressWithRangeStrategy As New Lookup()
        With addressWithRangeStrategy
            .Street = "691 W 1150 S"
            .City = "provo"
            .State = "utah"
            .MatchStrategy = Lookup.ENHANCED
        End With

        Dim addressWithInvalidStrategy As New Lookup()
        With addressWithInvalidStrategy
            .Street = "691 W 1150 S"
            .City = "provo"
            .State = "utah"
            .MatchStrategy = Lookup.INVALID
        End With

        Try
            batch.Add(addressWithStrictStrategy)
            batch.Add(addressWithRangeStrategy)
            batch.Add(addressWithInvalidStrategy)
            client.Send(batch)
        Catch ex As BatchFullException
            Console.WriteLine("Error. The batch is already full.")
        Catch ex As SmartyException
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
        Catch ex As IOException
            Console.WriteLine(ex.StackTrace)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
        End Try

        Console.WriteLine("*******************************************************")

        For i As Integer = 0 To batch.Count - 1
            Dim candidates = batch(i).Result

            If candidates.Count = 0 Then
                Console.WriteLine("Address " + CStr(i) + " is invalid." + Environment.NewLine)
                Continue For
            End If

            Console.WriteLine("Address " + CStr(i) + " is valid. (There is at least one candidate)" + Environment.NewLine + "If the match parameter is set to STRICT, the address is valid." + Environment.NewLine + "Otherwise, check the Analysis output fields to see if the address is valid.")

            For Each candidate In candidates
                Console.WriteLine()
                Dim components = candidate.Components
                Dim metadata = candidate.Metadata

                Console.Write("Candidate " + CStr(candidate.CandidateIndex))
                Dim match = batch(i).MatchStrategy
                Console.WriteLine(" with " + match + " strategy:")
                Console.WriteLine("Delivery line 1: " + candidate.DeliveryLine1)
                Console.WriteLine("Last line:       " + candidate.LastLine)
                Console.WriteLine("ZIP Code:        " + components.ZipCode + "-" + components.Plus4Code)
                Console.WriteLine("County:          " + metadata.CountyName)
                Console.WriteLine("Latitude:        " + CStr(metadata.Latitude))
                Console.WriteLine("Longitude:       " + CStr(metadata.Longitude))
            Next

            Console.WriteLine()

        Next

        Console.WriteLine()

    End Sub

End Module
