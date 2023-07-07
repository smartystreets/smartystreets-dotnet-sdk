namespace Examples
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using SmartyStreets;
	using SmartyStreets.USStreetApi;

	internal static class USStreetSingleAddressExample
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
			var client = new ClientBuilder(authId, authToken).WithLicense(new List<string>{"us-core-cloud"})
				//.WithCustomBaseUrl("us-street.api.smarty.com")
				//.ViaProxy("http://localhost:8080", "username", "password") // uncomment this line to point to the specified proxy.
				.BuildUsStreetApiClient();
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/us-street-api#input-fields

			var lookup = new Lookup
			{
				InputId = "24601", // Optional ID from you system
				Addressee = "John Doe",
				Street = "1600 Amphitheatre Pkwy",
				Street2 = "closet under the stairs",
				Secondary = "APT 2",
				Urbanization = "", // Only applies to Pue rto Rico addresses
				City = "Mountain View",
				State = "CA",
				ZipCode = "21229",
				MaxCandidates = 3,
				MatchStrategy = Lookup.ENHANCED // "invalid" is the most permissive match,
                                               // this will always return at least one result even if the address is invalid.
                                               // Refer to the documentation for additional MatchStrategy options.
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

			var candidates = lookup.Result;

			if (candidates.Count == 0)
			{
				Console.WriteLine("No candidates. This means the address is not valid.");
				return;
			}

			var firstCandidate = candidates[0];

			Console.WriteLine("Input ID: " + firstCandidate.InputId);
			Console.WriteLine("There is at least one candidate.\n If the match parameter is set to STRICT, the address is valid.\n Otherwise, check the Analysis output fields to see if the address is valid.\n");
			Console.WriteLine("ZIP Code: " + firstCandidate.Components.ZipCode);
			Console.WriteLine("County: " + firstCandidate.Metadata.CountyName);
			Console.WriteLine("Latitude: " + firstCandidate.Metadata.Latitude);
			Console.WriteLine("Longitude: " + firstCandidate.Metadata.Longitude);
		}
	}
}