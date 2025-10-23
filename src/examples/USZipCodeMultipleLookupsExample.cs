﻿namespace Examples
{
	using System;
	using System.IO;
    using System.Net;
    using SmartyStreets;
	using SmartyStreets.USZipCodeApi;

	internal static class USZipCodeMultipleLookupsExample
	{
		public static void Run()
		{
			// specifies the TLS protocoll to use - this is TLS 1.2
			const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

			// You don't have to store your keys in environment variables, but we recommend it.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			ServicePointManager.SecurityProtocol = tlsProtocol1_2;

			using var client = new ClientBuilder(authId, authToken)
				.BuildUsZipCodeApiClient();

			var lookup1 = new Lookup
			{
				InputId = "dfc33cb6-829e-4fea-aa1b-b6d6580f0817", // Optional ID from your system
				ZipCode = "12345"
			};

			//uncomment the lines below to add custom parameters
			// lookup1.AddCustomParameter("city", "Schenectady");
			// lookup1.AddCustomParameter("state", "NY");

			var lookup2 = new Lookup
			{
				City = "Phoenix",
				State = "Arizona"
			};

			var lookup3 = new Lookup("cupertino", "CA", "95014") // You can also set these with arguments
			{
				InputId = "01189998819991197253"
			};

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
				var result = batch[i].Result;
				Console.WriteLine("Lookup " + i + ":\n");

				if (result.Status != null)
				{
					Console.WriteLine("Status: " + result.Status);
					Console.WriteLine("Reason: " + result.Reason);
					continue;
				}

				Console.WriteLine("Input ID: " + result.InputId);

				var cityStates = result.CityStates;
				var zipCodes = result.ZipCodes;

				if (cityStates == null || zipCodes == null)
				{
					Console.WriteLine("Lookup " + i + " is invalid.\n");
					continue;
				}

				Console.WriteLine(cityStates.Length + " City and State match" + (cityStates.Length == 1 ? ":" : "es:"));

				foreach (var cityState in cityStates)
				{
					Console.WriteLine("City: " + cityState.City);
					Console.WriteLine("State: " + cityState.State);
					Console.WriteLine("Mailable City: " + cityState.MailableCity);
					Console.WriteLine();
				}

				Console.WriteLine(zipCodes.Length + " ZIP Code match" + (cityStates.Length == 1 ? ":" : "es:"));

				foreach (var zipCode in zipCodes)
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