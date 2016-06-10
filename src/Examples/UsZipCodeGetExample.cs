using System;
using SmartyStreets.USZipCodeApi;
using SmartyStreets;
using System.IO;

namespace Examples
{
	public class UsZipCodeGetExample
	{
		public static void Run()
		{
			var client = new ClientBuilder("YOUR AUTH-ID HERE", "YOUR AUTH-TOKEN HERE").Build();

			var lookup = new Lookup();
			lookup.City = "Mountain View";
			lookup.State = "California";

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

			var result = lookup.Result;
			var cityStates = result.CityStates;
			var zipCodes = result.ZipCodes;

			foreach (CityState cityState in cityStates)
			{
				Console.WriteLine("\nCity: " + cityState.City);
				Console.WriteLine("State: " + cityState.State);
				Console.WriteLine("Mailable City: " + cityState.MailableCity);
			}

			foreach (ZipCodeEntry zipCode in zipCodes)
			{
				Console.WriteLine("\nZIP Code: " + zipCode.ZipCode);
				Console.WriteLine("Latitude: " + zipCode.Latitude);
				Console.WriteLine("Longitude: " + zipCode.Longitude);
			}
		}
	}
}

