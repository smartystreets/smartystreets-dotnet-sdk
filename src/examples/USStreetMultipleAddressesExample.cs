namespace Examples
{
	using System;
	using System.IO;
    using System.Threading.Tasks;
    using SmartyStreets;
	using SmartyStreets.USStreetApi;

	internal static class USStreetMultipleAddressesExample
	{
		public static async Task RunAsync()
		{
			// You don't have to store your keys in environment variables, but we recommend it.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var client = new ClientBuilder(authId, authToken).BuildUsStreetApiClient();
			var batch = new Batch();

			var address1 = new Lookup
			{
				Street = "1600 amphitheatre parkway",
				City = "Mountain view",
				State = "california",
				MatchStrategy = "invalid"
			};

			var address2 = new Lookup("1 Rosedale, Baltimore, Maryland")
			{
				MaxCandidates = 10
			}; // Freeform addresses work too.

			var address3 = new Lookup("123 Bogus Street, Pretend Lake, Oklahoma");

			var address4 = new Lookup
			{
				Street = "1 Infinite Loop",
				ZipCode = "95014"
			};

			try
			{
				batch.Add(address1);
				batch.Add(address2);
				batch.Add(address3);
				batch.Add(address4);

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

					Console.WriteLine("\nCandidate " + candidate.CandidateIndex + ":");
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