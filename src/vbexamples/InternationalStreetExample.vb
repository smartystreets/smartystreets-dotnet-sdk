Imports System
Imports System.Diagnostics.Metrics
Imports System.IO
Imports System.Windows
Imports SmartyStreets
Imports SmartyStreets.InternationalStreetApi

Module InternationalStreetExample

	Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
	Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")

	Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"international-global-plus-cloud"}).BuildInternationalStreetApiClient()

	Sub InternationalStreetExample()

		Dim lookup As New Lookup("Rua Padre Antonio D'Angelo 121 Casa Verde, Sao Paulo", "Brazil")
		With lookup
			.InputId = "ID-8675309"
			.Geocode = True
			.Organization = "John Doe"
			.Address1 = "Rua Padre Antonio D'Angelo 121"
			.Address2 = "Casa Verde"
			.Locality = "Sao Paulo"
			.AdministrativeArea = "SP"
			.Country = "Brazil"
			.PostalCode = "02516-050"
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

		Console.WriteLine("Original lookup: " + lookup.Freeform + " " + lookup.Country)
		Console.WriteLine("Input ID: " + lookup.InputId + Environment.NewLine())

		If candidates.Count = 0 Then
			Console.WriteLine("No candidates. Tthe address is not valid." + Environment.NewLine)
			Return
		End If

		Console.WriteLine("Address is valid. (There is at least one candidate)")


		Console.WriteLine("*** Found " + CStr(candidates.Count) + " result" + If(candidates.Count = 1, "", "s") + " ***")

		For Each candidate In candidates
			Console.WriteLine()
			Dim components = candidate.Components
			Dim metadata = candidate.Metadata

			Console.WriteLine("Address: " + candidate.Analysis.VerificationStatus)
			Console.WriteLine("Address precision: " + candidate.Analysis.AddressPrecision + Environment.NewLine)

			Console.WriteLine("First Line: " + candidate.Address1)
			Console.WriteLine("Second Line: " + candidate.Address2)
			Console.WriteLine("Third Line: " + candidate.Address3)
			Console.WriteLine("Fourth Line: " + candidate.Address4)
			Console.WriteLine("Address Format: " + candidate.Metadata.AddressFormat)
			Console.WriteLine("Latitude: " + CStr(candidate.Metadata.Latitude))
			Console.WriteLine("Longitude: " + CStr(candidate.Metadata.Longitude))
		Next

		Console.WriteLine()



	End Sub

End Module
