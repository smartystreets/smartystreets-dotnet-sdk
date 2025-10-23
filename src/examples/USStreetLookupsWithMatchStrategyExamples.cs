﻿namespace Examples
{
	using System;
	using System.IO;
    using System.Net;
    using SmartyStreets;
	using SmartyStreets.USStreetApi;

	internal static class USStreetLookupsWithMatchStrategyExamples
	{
		public static void Run()
		{
            // specifies the TLS protocoll to use - this is TLS 1.2
            const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

            // You don't have to store your keys in environment variables, but we recommend it.
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			ServicePointManager.SecurityProtocol = tlsProtocol1_2;

			using var client = new ClientBuilder(authId, authToken).BuildUsStreetApiClient();
			var batch = new Batch();
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/us-street-api#input-fields

			var addressWithStrictStrategy = new Lookup
			{
				Street = "691 W 1150 S",
				City = "provo",
				State = "utah",
				MatchStrategy = Lookup.STRICT
			};

			//uncomment the line below to add a custom parameter
			//addressWithStrictStrategy.AddCustomParameter("city", "provo");

			var addressWithEnhancedStrategy = new Lookup
			{
				Street = "693 W 1150 S",
				City = "provo",
				State = "utah",
				MatchStrategy = Lookup.ENHANCED
			};

			var addressWithInvalidStrategy = new Lookup
			{
				Street = "9999 W 1150 S",
				City = "provo",
				State = "utah",
				MatchStrategy = Lookup.INVALID
			};

			try
			{
				batch.Add(addressWithStrictStrategy);
				batch.Add(addressWithEnhancedStrategy);
				batch.Add(addressWithInvalidStrategy);

				client.Send(batch);
			}
			catch (BatchFullException)
			{
				Console.WriteLine("Error. The batch is already full.");
				return;
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

					Console.Write("\nCandidate " + candidate.CandidateIndex);
					var match = batch[i].MatchStrategy;
					Console.Write(" with " + match + " strategy");
					Console.WriteLine("\nDelivery line 1: " + candidate.DeliveryLine1);
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