namespace Examples
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using SmartyStreets;
	using SmartyStreets.USStreetApi;

	internal static class USStreetMultipleAddressesExample
	{
		public static void Run()
		{
			// You don't have to store your keys in environment variables, but we recommend it.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

            // The appropriate license values to be used for your subscriptions
            // can be found on the Subscriptions page the account dashboard.
            // https://www.smartystreets.com/docs/cloud/licensing
			var client = new ClientBuilder(authId, authToken).WithLicense(new List<string>{"us-core-cloud"})
				.BuildUsStreetApiClient();
			var batch = new Batch();
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/us-street-api#input-fields

			var address1 = new Lookup
			{
				InputId = "24601", // Optional ID from your system
				Addressee = "John Doe",
				Street = "1600 amphitheatre parkway",
				Street2 = "closet under the stairs",
				Secondary = "APT 2",
				Urbanization = "", // Only applies to Puerto Rico addresses
				City = "Mountain view",
				State = "california",
				ZipCode = "94043",
				MaxCandidates = 3,
				MatchStrategy = Lookup.ENHANCED // "invalid" is the most permissive match,
                                               // this will always return at least one result even if the address is invalid.
                                               // Refer to the documentation for additional MatchStrategy options.
			};

			var address2 = new Lookup("1 Rosedale, Baltimore, Maryland")
			{
				Street = "1 Rosedale",
				Lastline = "Baltimore, Maryland",
				MaxCandidates = 5
			};

			var address3 = new Lookup("123 Bogus Street, Pretend Lake, Oklahoma"); // Freeform addresses work too

			var address4 = new Lookup
			{
				InputId = "8675309",
				Street = "1 Infinite Loop",
				ZipCode = "95014",
				MaxCandidates = 1
			};

			try
			{
				batch.Add(address1);
				batch.Add(address2);
				batch.Add(address3);
				batch.Add(address4);

				client.Send(batch);
			}
			catch (BatchFullException)
			{
				Console.WriteLine("Error. The batch is already full.");
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

			for (var i = 0; i < batch.Count; i++)
			{
				var candidates = batch[i].Result;

				if (candidates.Count == 0)
				{
					Console.WriteLine("Address " + i + " is invalid.\n");
					continue;
				}

				Console.WriteLine("Address " + i + " has at least one candidate.\n If the match parameter is set to STRICT, the address is valid.\n Otherwise, check the Analysis output fields to see if the address is valid.");

				foreach (var candidate in candidates)
				{
					var components = candidate.Components;
					var metadata = candidate.Metadata;

					Console.WriteLine("\nCandidate " + candidate.CandidateIndex + ":");
					Console.WriteLine("Input ID: " + candidate.InputId);
					Console.WriteLine("Delivery line 1: " + candidate.DeliveryLine1);
					Console.WriteLine("Last line:       " + candidate.LastLine);
					Console.WriteLine("ZIP Code:        " + components.ZipCode + "-" + components.Plus4Code);
					Console.WriteLine("County:          " + metadata.CountyName);
					Console.WriteLine("Latitude:        " + metadata.Latitude);
					Console.WriteLine("Longitude:       " + metadata.Longitude);
				}

				Console.WriteLine();
			}
		}
	}
}