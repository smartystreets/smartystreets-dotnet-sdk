namespace IntegrationTests
{
	using System;
	using System.Net.Http;
	using System.Threading;
	using System.Threading.Tasks;
    using SmartyStreets;
	using SmartyStreets.InternationalStreetApi;

	internal static class Tests
	{
		public static void RunAllApiIntegrationTests()
		{
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var credentials = new StaticCredentials(authId, authToken);

			var key = Environment.GetEnvironmentVariable("SMARTY_AUTH_WEB");
			var hostname = Environment.GetEnvironmentVariable("SMARTY_WEBSITE_DOMAIN");
			var shared = new SharedCredentials(key, hostname);

			TestInternationalStreetRequestReturnsWithCorrectNumberOfResults(credentials);
			TestUSAutocompleteProRequestReturnsWithCorrectNumberOfResults(shared);
			TestUSExtractRequestReturnsWithCorrectNumberOfResults(credentials);
			TestUSStreetRequestReturnsWithCorrectNumberOfResults(credentials);
			TestUSZIPCodeRequestReturnsWithCorrectNumberOfResults(credentials);
			TestReturnsCorrectNumberOfResultsViaProxy(credentials);
			TestUsEnrichmentPropertyPrincipalRequestReturnsCorrectNumberOfResults(credentials);
			TestNegotiatesHttp2ByDefaultAndHttp11WhenOptedOut(credentials);
		}

		// Verifies the protocol actually negotiated over the wire (not just what the SDK requested):
		// HttpResponseMessage.Version reflects the negotiated HTTP version. We observe it by injecting
		// an HttpClient whose DelegatingHandler records the response version after the live round-trip.
		// Uses the same SMARTY_URL_US_STREET base URL as the other tests, since our staging
		// environments also serve HTTP/2.
		private static void TestNegotiatesHttp2ByDefaultAndHttp11WhenOptedOut(ICredentials credentials)
		{
			var baseUrl = Environment.GetEnvironmentVariable("SMARTY_URL_US_STREET");

			var defaultHandler = new VersionRecordingHandler();
			var defaultClient = new ClientBuilder(credentials)
				.WithCustomBaseUrl(baseUrl)
				.WithHttpClient(new HttpClient(defaultHandler))
				.RetryAtMost(0)
				.BuildUsStreetApiClient();
			SendStreetLookup(defaultClient);
			AssertVersion("HTTP2_DEFAULT", defaultHandler.LastResponseVersion, new Version(2, 0));

			var optOutHandler = new VersionRecordingHandler();
			var optOutClient = new ClientBuilder(credentials)
				.WithCustomBaseUrl(baseUrl)
				.WithHttpClient(new HttpClient(optOutHandler))
				.WithoutHttp2()
				.RetryAtMost(0)
				.BuildUsStreetApiClient();
			SendStreetLookup(optOutClient);
			AssertVersion("HTTP11_OPTOUT", optOutHandler.LastResponseVersion, new Version(1, 1));
		}

		private static void SendStreetLookup(SmartyStreets.USStreetApi.Client client)
		{
			try
			{
				client.Send(new SmartyStreets.USStreetApi.Lookup("1 Rosedale, Baltimore, Maryland"));
			}
			catch (Exception)
			{
				// The negotiated version is recorded by the handler regardless of the SDK's
				// status-code handling, so a non-2xx response does not invalidate the check.
				Console.Write("");
			}
		}

		private static void AssertVersion(string label, Version actual, Version expected)
		{
			if (Equals(actual, expected))
				Console.Write(label + " - OK\n");
			else
				Console.Write(label + " - FAILED (Expected: HTTP/" + expected + ", Actual: HTTP/" +
				              (actual?.ToString() ?? "none") + ")\n");
		}

		private sealed class VersionRecordingHandler : DelegatingHandler
		{
			public Version LastResponseVersion { get; private set; }

			public VersionRecordingHandler() : base(new HttpClientHandler())
			{
			}

			protected override async Task<HttpResponseMessage> SendAsync(
				HttpRequestMessage request, CancellationToken cancellationToken)
			{
				var response = await base.SendAsync(request, cancellationToken);
				LastResponseVersion = response.Version;
				return response;
			}
		}

		private static void TestInternationalStreetRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_INTERNATIONAL_STREET")).RetryAtMost(0).BuildInternationalStreetApiClient();
			var lookup = new Lookup("Rua Padre Antonio D'Angelo 121 Casa Verde, Sao Paulo", "Brazil");

			try
			{
				client.Send(lookup);
			}
			catch (Exception)
			{
				Console.Write("");
			}

			var candidates = 0;
			if (lookup.Result != null)
				candidates = lookup.Result.Count;

			AssertResults("International_Street", candidates, 1);
		}

		private static void TestUSAutocompleteProRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_AUTOCOMPLETE_PRO")).RetryAtMost(0).BuildUsAutocompleteProApiClient();
			var lookup = new SmartyStreets.USAutocompleteProApi.Lookup("4770 Lincoln Ave O");
			lookup.AddStateFilter("IL");

			try
			{
				client.Send(lookup);
			}
			catch (Exception)
			{
				Console.Write("");
				throw;
			}

			var suggestions = 0;
			if (lookup.Result != null)
				suggestions = lookup.Result.Length;
			
			AssertResults("US_Autocomplete_Pro", suggestions, 1);
		}

		private static void TestUSExtractRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_EXTRACT")).RetryAtMost(0).BuildUsExtractApiClient();
			const string text = "Here is some text.\r\nMy address is 3785 Las Vegs Av." +
			                    "\r\nLos Vegas, Nevada." +
			                    "\r\nMeet me at 1 Rosedale Baltimore Maryland, not at 123 Phony Street, Boise Idaho.";

			var lookup = new SmartyStreets.USExtractApi.Lookup(text);

			try
			{
				client.Send(lookup);
			}
			catch (Exception)
			{
				Console.Write("");
			}

			var addresses = 0;
			if (lookup.Result.Addresses != null)
				addresses = lookup.Result.Addresses.Length;

			AssertResults("US_Extract", addresses, 3);
		}

		private static void TestUSStreetRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_STREET")).RetryAtMost(0).BuildUsStreetApiClient();
			var lookup = new SmartyStreets.USStreetApi.Lookup("1 Rosedale, Baltimore, Maryland") {MaxCandidates = 10};

			try
			{
				client.Send(lookup);
			}
			catch (Exception)
			{
				Console.Write("");
			}

			var candidates = 0;
			if (lookup.Result != null)
				candidates = lookup.Result.Count;

			AssertResults("US_Street", candidates, 2);
		}

		private static void TestUSZIPCodeRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_ZIP")).RetryAtMost(0).BuildUsZipCodeApiClient();
			var lookup = new SmartyStreets.USZipCodeApi.Lookup(null, null, "38852");

			try
			{
				client.Send(lookup);
			}
			catch (Exception)
			{
				Console.Write("");
			}

			var citiesAmount = 0;
			if (lookup.Result.CityStates != null)
				citiesAmount = lookup.Result.CityStates.Length;

			AssertResults("US_ZIPCode", citiesAmount, 7);
		}

		private static void TestReturnsCorrectNumberOfResultsViaProxy(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_ZIP")).ViaProxy("http://proxy.api.smarty.com:80", "", "")
				.BuildUsZipCodeApiClient();
			var lookup = new SmartyStreets.USZipCodeApi.Lookup(null, null, "38852");

			try
			{
				client.Send(lookup);
			}
			catch (Exception)
			{
				Console.Write("");
			}

			var citiesAmount = 0;
			if (lookup.Result.CityStates != null)
				citiesAmount = lookup.Result.CityStates.Length;

			AssertResults("VIA_PROXY", citiesAmount, 7);
		}

		private static void TestUsEnrichmentPropertyPrincipalRequestReturnsCorrectNumberOfResults(ICredentials credentials){
			var client = new ClientBuilder(credentials).BuildUsEnrichmentApiClient();
			
			SmartyStreets.USEnrichmentApi.Property.Principal.Result[] results = null;
            try
            {
                results = client.SendPropertyPrincipalLookup("1682393594");
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
			AssertResults("ENRICHMENT_PROPERTY_PRINCIPAL", results.Length, 1);
		}

		private static void AssertResults(string apiType, int actualResultCount, int expectedResultCount)
		{
			if (actualResultCount == expectedResultCount)
				Console.Write(apiType + " - OK\n");
			else
				Console.Write(apiType + " - FAILED (Expected: " + expectedResultCount + ", Actual: " + actualResultCount + ")\n");
		}
	}
}