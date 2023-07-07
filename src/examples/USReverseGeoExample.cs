namespace Examples
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using SmartyStreets;
	using SmartyStreets.USReverseGeoApi;

	internal static class USReverseGeoExample
	{
		public static void Run()
		{
			// var authId = "Your SmartyStreets Auth ID here";
			// var authToken = "Your SmartyStreets Auth Token here";

			// We recommend storing your keys in environment variables instead---it's safer!
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

			// The appropriate license values to be used for your subscriptions
			// can be found on the Subscriptions page the account dashboard.
			// https://www.smartystreets.com/docs/cloud/licensing
			var client = new ClientBuilder(authId, authToken).WithLicense(new List<string>{"us-reverse-geocoding-cloud"})
				//.WithCustomBaseUrl("us-street-reverse-geo.api.smarty.com")
				//.ViaProxy("http://localhost:8080", "username", "password") // uncomment this line to point to the specified proxy.
				.BuildUsReverseGeoApiClient();
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/us-street-api#input-fields

			var lookup = new Lookup(40.111111, -111.111111);

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

			var results = lookup.SmartyResponse.Results;

			if (results.Count == 0)
			{
				Console.WriteLine("No candidates. This means the address is not valid.");
				return;
			}

			Console.WriteLine("\nResults for input: (" + lookup.Latitude + ", " + lookup.Longitude);
			foreach (var result in results)
			{
				var coordinate = result.Coordinate;
				var address = result.Address;
				
				Console.WriteLine("\nLatitude: " + coordinate.Latitude);
				Console.WriteLine("Longitude: " + coordinate.Longitude);
				Console.WriteLine("Distance: " + result.Distance);
				Console.WriteLine("Street: " + address.Street);
				Console.WriteLine("City: " + address.City);
				Console.WriteLine("State Abbreviation: " + address.StateAbbreviation);
				Console.WriteLine("ZIP Code: " + address.ZipCode);
				Console.WriteLine("License: " + coordinate.License);
			}
		}
	}
}