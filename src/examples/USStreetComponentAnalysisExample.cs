namespace Examples
{
	using System;
	using System.IO;
    using System.Net;
    using System.Text.Json;
    using SmartyStreets;
	using SmartyStreets.USStreetApi;

	internal static class USStreetComponentAnalysisExample
	{
		public static void Run()
		{
            // specifies the TLS protocol to use - this is TLS 1.2
            const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

            // For client-side requests (browser/mobile), use this code:
            // var key = Environment.GetEnvironmentVariable("SMARTY_AUTH_WEB");
            // var referer =  Environment.GetEnvironmentVariable("SMARTY_AUTH_REFERER");
            // var credentials = new SharedCredentials(key, referer);

            // For server-to-server requests, use this code:
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
            var credentials = new StaticCredentials(authId, authToken);

            ServicePointManager.SecurityProtocol = tlsProtocol1_2;

            using var client = new ClientBuilder(credentials)
                .WithFeatureComponentAnalysis() // To add component analysis feature you need to specify when you create the client.
				.BuildUsStreetApiClient();

			var lookup = new Lookup
			{
				Street = "1 Rosedale",
				Secondary = "APT 2",
				City = "Baltimore",
				State = "MD",
				ZipCode = "21229",
				MatchStrategy = Lookup.ENHANCED // Enhanced matching is required to return component analysis results.
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


            // Here is an example of how to access component analysis
            string json = JsonSerializer.Serialize(firstCandidate.Analysis.Components, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            
            Console.WriteLine("Component Analysis Results: \n" + json);
		}
	}
}