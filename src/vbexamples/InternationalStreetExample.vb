Imports System
Imports System.Diagnostics.Metrics
Imports System.IO
Imports System.Windows
Imports SmartyStreets
Imports SmartyStreets.InternationalStreetApi

Module InternationalStreetExample

	Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
	Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
	Dim url = Environment.GetEnvironmentVariable("SMARTY_URL")

	Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"international-global-plus-cloud"}).WithCustomBaseUrl(url).BuildInternationalStreetApiClient()
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
		Dim firstCandidate = candidates(0)
		Console.WriteLine("Input ID: " + firstCandidate.InputId)
		Console.WriteLine("Address is " + firstCandidate.Analysis.VerificationStatus)
		Console.WriteLine("Address precision: " + firstCandidate.Analysis.AddressPrecision + "\n")

		Console.WriteLine("First Line: " + firstCandidate.Address1)
		Console.WriteLine("Second Line: " + firstCandidate.Address2)
		Console.WriteLine("Third Line: " + firstCandidate.Address3)
		Console.WriteLine("Fourth Line: " + firstCandidate.Address4)
		Console.WriteLine("Address Format: " + firstCandidate.Metadata.AddressFormat)
		Console.WriteLine("Latitude: " + firstCandidate.Metadata.Latitude)
		Console.WriteLine("Longitude: " + firstCandidate.Metadata.Longitude)

	End Sub

End Module
