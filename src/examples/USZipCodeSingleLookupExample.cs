namespace Examples
{
	using System;
	using System.IO;
    using System.Net;
    using SmartyStreets;
	using SmartyStreets.USZipCodeApi;

	internal static class USZipCodeSingleLookupExample
	{
		public static void Run()
		{
			// specifies the TLS protocoll to use - this is TLS 1.2
			const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

			// You don't have to store your keys in environment variables, but we recommend it.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			ServicePointManager.SecurityProtocol = tlsProtocol1_2;

			using var client = new ClientBuilder(authId, authToken).BuildUsZipCodeApiClient();

			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/us-zipcode-api#input-fields

			var lookup = new Lookup
			{
				InputId = "dfc33cb6-829e-4fea-aa1b-b6d6580f0817", // Optional ID from your system
				City = "Mountain View",
				State = "California",
				ZipCode = "94039"
			};

			//uncomment the line below to add a custom parameter
			//lookup.AddCustomParameter("zipcode", "94039");
			
			var batch = new Batch();
			batch.Add(lookup);
			
			try
			{
				client.Send(batch);
			}
			catch (SmartyException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
				return;
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.StackTrace);
				return;
			}

			var result = lookup.Result;
			var cities = result.CityStates;
			var zipCodes = result.ZipCodes;

			if (cities == null || zipCodes == null)
			{
				Console.WriteLine("No results.");
				return;
			}

			Console.WriteLine("Input ID: " + result.InputId);

			foreach (var city in cities)
			{
				Console.WriteLine("\nCity: " + city.City);
				Console.WriteLine("State: " + city.State);
				Console.WriteLine("Mailable City: " + city.MailableCity);
			}

			foreach (var zipCode in zipCodes)
			{
				Console.WriteLine("\nZIP Code: " + zipCode.ZipCode);
				Console.WriteLine("Latitude: " + zipCode.Latitude);
				Console.WriteLine("Longitude: " + zipCode.Longitude);
			}
		}
	}
}