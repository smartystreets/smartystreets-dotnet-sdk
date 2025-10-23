﻿namespace Examples
{
	using System;
	using System.Net;
	using System.IO;
    using SmartyStreets;
	using SmartyStreets.USStreetApi;

    internal static class USStreetSingleAddressEndpointExample
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
				// NOTE: this is how to point the SDK at an alternate installation
				// for example, this might be used to connect through "stunnel" to handle things like TLSv1.2 encryption
				.WithCustomBaseUrl("http://127.0.0.1:8080/street-address") // point to local installation
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
				Urbanization = "", // Only applies to Puerto Rico addresses
				City = "Mountain View",
				State = "CA",
				ZipCode = "21229",
				MaxCandidates = 3,
				MatchStrategy = Lookup.ENHANCED // "invalid" is the most permissive match,
                                               // this will always return at least one result even if the address is invalid.
                                               // Refer to the documentation for additional MatchStrategy options.
			};

			//uncomment the line below to add a custom parameter
			//lookup.AddCustomParameter("InputId", "24601");

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