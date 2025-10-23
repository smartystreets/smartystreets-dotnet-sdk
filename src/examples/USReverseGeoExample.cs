namespace Examples
{
	using System;
	using System.IO;
    using System.Net;
    using SmartyStreets;
	using SmartyStreets.USReverseGeoApi;

	internal static class USReverseGeoExample
	{
		public static void Run()
		{
            // specifies the TLS protocoll to use - this is TLS 1.2
            const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

            // var authId = "Your SmartyStreets Auth ID here";
            // var authToken = "Your SmartyStreets Auth Token here";

            // We recommend storing your keys in environment variables instead---it's safer!
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			ServicePointManager.SecurityProtocol = tlsProtocol1_2;

			using var client = new ClientBuilder(authId, authToken)
				//.WithCustomBaseUrl("us-street-reverse-geo.api.smarty.com")
				//.ViaProxy("http://localhost:8080", "username", "password") // uncomment this line to point to the specified proxy.
				.BuildUsReverseGeoApiClient();
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/us-street-api#input-fields

			var lookup = new Lookup(40.111111, -111.111111);

			//uncomment the line below to add a custom parameter
			//lookup.AddCustomParameter("source", "all");

			try
			{
				client.Send(lookup);
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

			if (lookup.SmartyResponse == null)
			{
				Console.WriteLine("No candidates.");
				return;
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
				Console.WriteLine("Smartykey: " + address.Smartykey);
			}
		}
	}
}