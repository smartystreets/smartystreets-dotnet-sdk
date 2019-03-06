namespace Examples
{
	using System;
	using System.IO;
    using System.Threading.Tasks;
    using SmartyStreets;
	using SmartyStreets.USStreetApi;

	internal static class USStreetLookupsWithMatchStrategyExamples
	{
		public static async Task RunAsync()
		{
			// You don't have to store your keys in environment variables, but we recommend it.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var client = new ClientBuilder(authId, authToken).BuildUsStreetApiClient();
			var batch = new Batch();

			var addressWithStrictStrategy = new Lookup
			{
				Street = "691 W 1150 S",
				City = "provo",
				State = "utah",
				MatchStrategy = Lookup.STRICT
			};

			var addressWithRangeStrategy = new Lookup
			{
				Street = "693 W 1150 S",
				City = "provo",
				State = "utah",
				MatchStrategy = Lookup.RANGE
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
				batch.Add(addressWithRangeStrategy);
				batch.Add(addressWithInvalidStrategy);

				await client.SendAsync(batch);
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

				Console.WriteLine("Address " + i + " is valid. (There is at least one candidate)");

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