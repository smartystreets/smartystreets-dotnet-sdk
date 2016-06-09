using System;
using SmartyStreets.USStreetApi;
using SmartyStreets;
using System.IO;
using System.Collections;

namespace UsStreetGetExample
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var client = new ClientBuilder("YOUR AUTH-ID HERE", "YOUR AUTH-TOKEN HERE").Build();

			var lookup = new Lookup();
			lookup.Street = "1600 Amphitheatre Pkwy";
			lookup.City = "Mountain View";
			lookup.State = "CA";

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

			ArrayList candidates = lookup.Result;

			if (candidates.Count == 0)
			{
				Console.WriteLine("No candidates. This means the address is not valid.");
				return;
			}

			Candidate firstCandidate = (Candidate)candidates[0];

			Console.WriteLine("Address is valid. (There is at least one candidate)\n");
			Console.WriteLine("ZIP Code: " + firstCandidate.Components.ZipCode);
			Console.WriteLine("County: " + firstCandidate.Metadata.CountyName);
			Console.WriteLine("Latitude: " + firstCandidate.Metadata.Latitude);
			Console.WriteLine("Longitude: " + firstCandidate.Metadata.Longitude);
		}
	}
}
