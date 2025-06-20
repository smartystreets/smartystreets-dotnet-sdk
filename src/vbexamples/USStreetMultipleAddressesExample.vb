Imports System
Imports System.IO
Imports System.Reflection.Emit
Imports System.Windows
Imports SmartyStreets
Imports SmartyStreets.USStreetApi

Module USStreetMultipleAddressesExamples

    Sub USStreetMultipleAddressesExamples()
        Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
        Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")

        Dim client = New ClientBuilder(authID, authToken).BuildUsStreetApiClient()
        Dim batch = New Batch()

        Dim address0 As New Lookup()
        With address0
            .InputId = "24601"
            .Addressee = "John Doe"
            .Street = "1600 Amphitheatre Pkwy"
            .Street2 = "closet under the stairs"
            .Secondary = "APT 2"
            .Urbanization = ""
            .City = "Mountain View"
            .State = "CA"
            .ZipCode = "21229"
            .MaxCandidates = 3
            .MatchStrategy = Lookup.INVALID
        End With

        Dim address1 As New Lookup()
        With address1
            .Street = "1 Rosedale"
            .Lastline = "Baltimore, Maryland"
            .MaxCandidates = 5
        End With

        Dim address2 As New Lookup()
        With address2
            .Street = "123 Bogus Street, Pretend Lake, Oklahoma"
        End With

        Dim address3 As New Lookup()
        With address3
            .InputId = "8675309"
            .Street = "1 Infinite Loop"
            .ZipCode = "95014"
            .MaxCandidates = 1
        End With

        Console.WriteLine("*******************************************************")
        Console.WriteLine()

        Try
            batch.Add(address0)
            batch.Add(address1)
            batch.Add(address2)
            batch.Add(address3)
            Client.Send(batch)
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

        Dim numLookups = batch.Count

        For i As Integer = 0 To numLookups - 1
            If i > 0 Then
                Console.WriteLine()
            End If

            Dim candidates = batch(i).Result

            If candidates.Count = 0 Then
                Console.WriteLine("Address " + CStr(i) + " has no candidates. The address is not valid.")
                Continue For
            End If

            Console.WriteLine("Address " + CStr(i) + " has " + CStr(candidates.Count) + " candidate" + If(candidates.Count = 1, "", "s") + Environment.NewLine + "If the match parameter is set to STRICT, the address is valid." + Environment.NewLine + "Otherwise, check the Analysis output fields to see if the address is valid." + Environment.NewLine())

            Console.WriteLine("Input ID: " + batch(i).InputId)

            For Each candidate In candidates
                Console.WriteLine()
                Dim components = candidate.Components
                Dim metadata = candidate.Metadata

                Console.Write("Candidate " + CStr(candidate.CandidateIndex))
                Dim match = batch(i).MatchStrategy
                If match Is Nothing Then
                    match = "strict"
                End If
                Console.WriteLine(" with " + match + " strategy:")
                Console.WriteLine("Delivery line 1: " + candidate.DeliveryLine1)
                Console.WriteLine("Last line:       " + candidate.LastLine)
                Console.WriteLine("ZIP Code:        " + components.ZipCode + "-" + components.Plus4Code)
                Console.WriteLine("County:          " + metadata.CountyName)
                Console.WriteLine("Latitude:        " + CStr(metadata.Latitude))
                Console.WriteLine("Longitude:       " + CStr(metadata.Longitude))
            Next

        Next

        Console.WriteLine()

    End Sub

End Module
