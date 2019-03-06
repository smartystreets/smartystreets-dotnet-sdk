namespace Examples
{
	using System;
	using System.IO;
    using System.Threading.Tasks;
    using SmartyStreets;
	using SmartyStreets.USZipCodeApi;

	internal static class USZipCodeSingleLookupExample
	{
		public static async Task RunAsync()
		{
			// You don't have to store your keys in environment variables, but we recommend it.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var client = new ClientBuilder(authId, authToken).BuildUsZipCodeApiClient();

			var lookup = new Lookup
			{
				City = "Mountain View",
				State = "California"
			};

			try
			{
				await client.SendAsync(lookup);
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