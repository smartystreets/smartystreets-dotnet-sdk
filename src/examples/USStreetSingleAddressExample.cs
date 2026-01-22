namespace Examples
{
	using System;
	using System.IO;
    using System.Net;
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

			using var client = new ClientBuilder(new BasicAuthCredentials(authId, authToken))
				//.WithCustomBaseUrl("us-street.api.smarty.com")
				//.ViaProxy("http://localhost:8080", "username", "password") // uncomment this line to point to the specified proxy.
				// .WithDebug()  // uncomment this line to print out the HTTP request and response 
				.BuildUsStreetApiClient();
			
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/us-street-api#input-fields

			var lookup = new Lookup
			{
				InputId = "24601", // Optional ID from your system
				Addressee = "John Doe",
				Street = "1600 Amphitheatre Pkwy",
				Street2 = "closet under the stairs",
				Secondary = "APT 2",
				Urbanization = "", // Only applies to Puerto Rico addresses
				City = "Mountain View",
				State = "CA",
				ZipCode = "21229",
				CountySource = Lookup.GEOGRAPHIC,
				MaxCandidates = 3,
				MatchStrategy = Lookup.ENHANCED // "invalid" is the most permissive match,
												// this will always return at least one result even if the address is invalid.
												// Refer to the documentation for additional MatchStrategy options.
			};

			//uncomment the line below to add a custom parameter
			//lookup.AddCustomParameter("county_source", "geographic");

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