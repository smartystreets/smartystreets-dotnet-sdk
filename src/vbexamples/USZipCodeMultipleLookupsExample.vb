Imports System.Reflection.Emit
Imports System.Windows
Imports System.IO
Imports SmartyStreets
Imports SmartyStreets.USZipCodeApi
Imports System.Formats

Module USZipCodeMultipleLookupsExample

	Sub USZipCodeMultipleLookupsExample()

		Dim authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")
		Dim authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")

		Dim client = New ClientBuilder(authID, authToken).BuildUsZipCodeApiClient()
		Dim batch = New Batch()

		Dim lookup0 As New Lookup()
		With lookup0
			.InputId = "dfc33cb6-829e-4fea-aa1b-b6d6580f0817"
			.ZipCode = "12345"
		End With

		Dim lookup1 As New Lookup
		With lookup1
			.City = "Phoenix"
			.State = "Arizona"
		End With

		Dim lookup2 As New Lookup("cupertino", "CA", "95014")
		With lookup2
			.InputId = "01189998819991197253"
		End With

		Console.WriteLine("*******************************************************")
		Console.WriteLine()

		Try
			batch.Add(lookup0)
			batch.Add(lookup1)
			batch.Add(lookup2)
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

			Dim result = batch(i).Result
			Dim cities = result.CityStates
			Dim zipCodes = result.ZipCodes

			If result.Status IsNot Nothing Then
				Console.WriteLine("Lookup " + CStr(i) + " has an invalid status.")
				Console.WriteLine("Status: " + result.Status)
				Console.WriteLine("Reason: " + result.Reason)
				Continue For
			End If

			If zipCodes Is Nothing Or cities Is Nothing Then
				Console.WriteLine("Lookup " + CStr(i) + " has no candidates. The lookup is not valid.")
				Continue For
			End If

			Console.WriteLine("Lookup " + CStr(i) + " is valid." + Environment.NewLine())

			Console.WriteLine("Input ID: " + result.InputId + Environment.NewLine())

			Console.WriteLine(CStr(cities.Length) + " city and state match" + If(cities.Length = 1, ":", "es:"))

			For Each cityState In cities
				Console.WriteLine()
				Console.WriteLine("City: " + cityState.City)
				Console.WriteLine("State: " + cityState.State)
				Console.WriteLine("Mailable City: " + CStr(cityState.MailableCity))
			Next

			Console.WriteLine()
			Console.WriteLine(CStr(zipCodes.Length) + " ZIP code match" + If((zipCodes.Length = 1), ":", "es:"))

			For Each zipCode In zipCodes
				Console.WriteLine()
				Console.WriteLine("ZIP Code: " + zipCode.ZipCode)
				Console.WriteLine("County: " + zipCode.CountyName)
				Console.WriteLine("Latitude: " + CStr(zipCode.Latitude))
				Console.WriteLine("Longitude: " + CStr(zipCode.Longitude))
			Next

		Next

		Console.WriteLine()

	End Sub

End Module
