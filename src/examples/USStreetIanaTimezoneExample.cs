namespace Examples
{
	using System;
	using System.IO;
	using System.Net;
	using SmartyStreets;
	using SmartyStreets.USStreetApi;

	internal static class USStreetIanaTimezoneExample
	{
		public static void Run()
		{
			const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

			ServicePointManager.SecurityProtocol = tlsProtocol1_2;

			using var client = new ClientBuilder(new BasicAuthCredentials(authId, authToken))
				.WithFeatureIanaTimeZone()
				.BuildUsStreetApiClient();

			var lookup = new Lookup
			{
				Street = "1 Rosedale",
				City = "Baltimore",
				State = "MD",
				ZipCode = "21229",
				MatchStrategy = Lookup.ENHANCED
			};

			try
			{
				client.Send(lookup);
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

			var candidates = lookup.Result;

			if (candidates.Count == 0)
			{
				return;
			}

			var firstCandidate = candidates[0];
			var metadata = firstCandidate.Metadata;

			Console.WriteLine("Legacy Timezone Fields:");
			Console.WriteLine("  TimeZone:  " + metadata.TimeZone);
			Console.WriteLine("  UtcOffset: " + metadata.UtcOffset);
			Console.WriteLine("  ObeysDst:  " + metadata.ObeysDst);
			Console.WriteLine();
			Console.WriteLine("IANA Timezone Fields:");
			Console.WriteLine("  IanaTimeZone:  " + metadata.IanaTimeZone);
			Console.WriteLine("  IanaUtcOffset: " + metadata.IanaUtcOffset);
			Console.WriteLine("  IanaObeysDst:  " + metadata.IanaObeysDst);
		}
	}
}
