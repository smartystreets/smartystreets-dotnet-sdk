using System;
using SmartyStreets.USZipCodeApi;
using SmartyStreets;
using System.IO;
namespace Examples
{
	public class UsZipCodePostExample
	{
		public static void Run()
		{
			var authID = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var client = new ClientBuilder(authID, authToken).Build();

			var lookup1 = new Lookup();
			lookup1.ZipCode = "12345";   // A Lookup may have a ZIP Code, city and state, or city, state, and ZIP Code

			var lookup2 = new Lookup();
			lookup2.City = "Phoenix";
			lookup2.State = "Arizona";

			var lookup3 = new Lookup("cupertino", "CA", "95014"); // You can also set these with arguments

			var batch = new Batch();

			try
			{
				batch.Add(lookup1);
				batch.Add(lookup2);
				batch.Add(lookup3);

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

			for (int i = 0; i < batch.Size(); i++)
			{
				var result = batch.Get(i).Result;
				Console.WriteLine("Lookup " + i + ":\n");

				if (result.Status != null)
				{
					Console.WriteLine("Status: " + result.Status);
					Console.WriteLine("Reason: " + result.Reason);
					continue;
				}

				var cityStates = result.CityStates;
				Console.WriteLine(cityStates.Length + " City and State match" + ((cityStates.Length == 1) ? ":" : "es:"));

				foreach (CityState cityState in cityStates)
				{
					Console.WriteLine("City: " + cityState.City);
					Console.WriteLine("State: " + cityState.State);
					Console.WriteLine("Mailable City: " + cityState.MailableCity);
					Console.WriteLine();
				}

				var zipCodes = result.ZipCodes;
				Console.WriteLine(zipCodes.Length + " ZIP Code match" + ((cityStates.Length == 1) ? ":" : "es:"));

				foreach (ZipCodeEntry zipCode in zipCodes)
				{
					Console.WriteLine("ZIP Code: " + zipCode.ZipCode);
					Console.WriteLine("County: " + zipCode.CountyName);
					Console.WriteLine("Latitude: " + zipCode.Latitude);
					Console.WriteLine("Longitude: " + zipCode.Longitude);
					Console.WriteLine();
				}
				Console.WriteLine("***********************************");
			}
		}
	}
}

