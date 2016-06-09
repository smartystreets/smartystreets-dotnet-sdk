using SmartyStreets;
using SmartyStreets.USStreetApi;
using System;
using System.IO;
namespace Examples
{
	public class UsStreetPostExample
	{
		public static void Run()
		{
			var client = new ClientBuilder("YOUR AUTH-ID HERE", "YOUR AUTH-TOKEN HERE").Build();
			var batch = new Batch();

			var address1 = new Lookup();
			address1.Street = "1600 amphitheatre parkway";
			address1.City = "Mountain view";
			address1.State = "california";

			var address2 = new Lookup("1 Rosedale, Baltimore, Maryland"); // Freeform addresses work too.
			address2.MaxCandidates = 10; // Allows up to ten possible matches to be returned (default is 1).

			var address3 = new Lookup("123 Bogus Street, Pretend Lake, Oklahoma");

			var address4 = new Lookup();
			address4.Street = "1 Infinite Loop";
			address4.ZipCode = "95014"; // You can just input the street and ZIP if you want.

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
				Console.WriteLine("Error. Batch is already full.");
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

			var lookups = batch.AllLookups;

			for (int i = 0; i < batch.Size(); i++)
			{
				var candidates = lookups[i].Result;

				if (batch.Get(i).Result.Count == 0)
				{
					Console.WriteLine("Address " + i + " is invalid.\n");
					continue;
				}

				Console.WriteLine("Address " + i + " is valid. (There is at least one candidate)");

				foreach (Candidate candidate in candidates)
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