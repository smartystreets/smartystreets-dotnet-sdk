Imports System.Reflection.Emit
Imports System.Windows
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USZipCodeApi
Imports System.Formats

Module USZipCodeMultipleLookupsExample
	Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
	Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")
	Dim url = Environment.GetEnvironmentVariable("SMARTY_URL")

	Dim client = New ClientBuilder(authID, authToken).WithLicense(New List(Of String) From {"us-core-cloud"}).WithCustomBaseUrl(url).BuildUsZipCodeApiClient()
	Dim batch = New Batch()

	Sub USZipCodeMultipleLookupsExample()

		Dim lookup1 As New Lookup()
		With lookup1
			.InputId = "dfc33cb6-829e-4fea-aa1b-b6d6580f0817"
			.ZipCode = "12345"
		End With

		Dim lookup2 As New Lookup
		With lookup2
			.City = "Phoenix"
			.State = "Arizona"
		End With

		Dim lookup3 As New Lookup("cupertino", "CA", "95014")
		With lookup3
			.InputId = "01189998819991197253"
		End With

		Try
			batch.Add(lookup1)
			batch.Add(lookup2)
			batch.Add(lookup3)
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

		For i As Integer = 0 To batch.Count
			Dim result = batch(i).Result
			Console.WriteLine("Lookup " + i + ":" + Environment.NewLine)

			If result.Status IsNot Nothing Then
				Console.WriteLine("Status: " + result.Status)
				Console.WriteLine("Reason: " + result.Reason)
				Continue For
			End If

			Console.WriteLine("Input ID: " + result.InputId)

			Dim cityStates = result.CityStates
			Console.WriteLine(cityStates.Length + " City and State match" + If(cityStates.Length = 1, ":", "es:"))

			For Each cityState In cityStates
				Console.WriteLine("City: " + cityState.City)
				Console.WriteLine("State: " + cityState.State)
				Console.WriteLine("Mailable City: " + cityState.MailableCity)
				Console.WriteLine()
			Next

			Dim zipCodes = result.ZipCodes
			Console.WriteLine(zipCodes.Length + " ZIP Code match" + If((cityStates.Length = 1), ":", "es:"))

			For Each zipCode In zipCodes
				Console.WriteLine("ZIP Code: " + zipCode.ZipCode)
				Console.WriteLine("County: " + zipCode.CountyName)
				Console.WriteLine("Latitude: " + zipCode.Latitude)
				Console.WriteLine("Longitude: " + zipCode.Longitude)
				Console.WriteLine()
			Next

			Console.WriteLine("***********************************")

		Next

	End Sub

End Module
