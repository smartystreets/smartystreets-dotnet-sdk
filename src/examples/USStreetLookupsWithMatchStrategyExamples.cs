namespace Examples
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using SmartyStreets;
	using SmartyStreets.USStreetApi;

	internal static class USStreetLookupsWithMatchStrategyExamples
	{
		public static void Run()
		{
			// You don't have to store your keys in environment variables, but we recommend it.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

			using var client = new ClientBuilder(new BasicAuthCredentials(authId, authToken)).BuildUsStreetApiClient();
			var batch = new Batch();

			// Each address is run through all three match strategies so you can compare how
			// 'strict', 'enhanced', and 'invalid' each handle a valid, an invalid, and an
			// ambiguous address.
			//   - strict:   only returns candidates that are valid, mailable addresses.
			//   - enhanced: returns a more comprehensive dataset (requires a US Core or Rooftop license).
			//   - invalid:  most permissive; always returns at least one candidate (a best-guess standardization).
			// Documentation for input fields: https://smartystreets.com/docs/us-street-api#input-fields
			var addresses = new[]
			{
				new { Label = "valid (real, deliverable)",    Street = "1600 Amphitheatre Pkwy", City = "Mountain View", State = "CA", Zip = "94043" },
				new { Label = "invalid (no such address)",    Street = "9999 W 1150 S",          City = "Provo",         State = "UT", Zip = "84601" },
				new { Label = "ambiguous (missing ZIP/unit)", Street = "1 Rosedale St",          City = "Baltimore",     State = "MD", Zip = "" },
			};
			var strategies = new[] { Lookup.STRICT, Lookup.ENHANCED, Lookup.INVALID };

			// parallel metadata for each lookup, in the order they are added to the batch
			var cases = new List<(string Label, string Address, string Strategy)>();

			try
			{
				foreach (var address in addresses)
				{
					foreach (var strategy in strategies)
					{
						batch.Add(new Lookup
						{
							Street = address.Street,
							City = address.City,
							State = address.State,
							ZipCode = address.Zip,
							MatchStrategy = strategy,
							MaxCandidates = 10 // allow ambiguous addresses to return more than one match
						});
						cases.Add((address.Label, $"{address.Street}, {address.City}, {address.State}", strategy));
					}
				}

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

			string lastAddress = null;
			for (var i = 0; i < batch.Count; i++)
			{
				var (label, address, strategy) = cases[i];

				if (address != lastAddress)
				{
					Console.WriteLine("\n" + new string('=', 70));
					Console.WriteLine($" Address: {address}  [{label}]");
					Console.WriteLine(new string('=', 70));
					lastAddress = address;
				}

				var candidates = batch[i].Result;
				Console.WriteLine($"\n--- '{strategy}' strategy ---");

				if (candidates.Count == 0)
				{
					Console.WriteLine("  0 candidates - no match returned under this strategy.");
					continue;
				}

				Console.WriteLine($"  {candidates.Count} candidate(s):");
				foreach (var candidate in candidates)
					Console.WriteLine($"    [{candidate.CandidateIndex}] {candidate.DeliveryLine1}  {candidate.LastLine}");
			}
		}
	}
}
