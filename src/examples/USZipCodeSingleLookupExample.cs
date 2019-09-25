namespace Examples
{
	using System;
	using System.IO;
	using SmartyStreets;
	using SmartyStreets.USZipCodeApi;

	internal static class USZipCodeSingleLookupExample
	{
		public static void Run()
		{
			// You don't have to store your keys in environment variables, but we recommend it.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var client = new ClientBuilder(authId, authToken).BuildUsZipCodeApiClient();
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/us-zipcode-api#input-fields

			var lookup = new Lookup
			{
				InputId = "dfc33cb6-829e-4fea-aa1b-b6d6580f0817", // Optional ID from your system
				City = "Mountain View",
				State = "California",
				ZipCode = "94039"
			};

			try
			{
				client.Send(lookup);
			}
			catch (SmartyException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
			catch (IOException ex)
			{
				Console.WriteLine(ex.StackTrace);
			}

			var result = lookup.Result;
			var cities = result.CityStates;
			var zipCodes = result.ZipCodes;

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