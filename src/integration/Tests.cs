namespace IntegrationTests
{
	using System;
    using System.Threading.Tasks;
    using SmartyStreets;
	using SmartyStreets.InternationalStreetApi;

	internal static class Tests
	{
		public static async Task RunAllApiIntegrationTests()
		{
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var credentials = new StaticCredentials(authId, authToken);

			var key = Environment.GetEnvironmentVariable("SMARTY_AUTH_WEB");
			var hostname = Environment.GetEnvironmentVariable("SMARTY_WEBSITE_DOMAIN");
			var shared = new SharedCredentials(key, hostname);

			await TestInternationalStreetRequestReturnsWithCorrectNumberOfResults(credentials);
			await TestUSAutocompleteProRequestReturnsWithCorrectNumberOfResults(shared);
			await TestUSExtractRequestReturnsWithCorrectNumberOfResults(credentials);
			await TestUSStreetRequestReturnsWithCorrectNumberOfResults(credentials);
			await TestUSZIPCodeRequestReturnsWithCorrectNumberOfResults(credentials);
			await TestReturnsCorrectNumberOfResultsViaProxy(credentials);
			await TestUsEnrichmentPropertyPrincipalRequestReturnsCorrectNumberOfResults(credentials);
			await TestUsEnrichmentPropertyFinancialRequestReturnsCorrectNumberOfResults(credentials);
		}

		private static async Task TestInternationalStreetRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_INTERNATIONAL_STREET")).RetryAtMost(0).BuildInternationalStreetApiClient();
			var lookup = new Lookup("Rua Padre Antonio D'Angelo 121 Casa Verde, Sao Paulo", "Brazil");

			try
			{
				await client.Send(lookup);
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

		private static async Task TestUSAutocompleteProRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_AUTOCOMPLETE_PRO")).RetryAtMost(0).BuildUsAutocompleteProApiClient();
			var lookup = new SmartyStreets.USAutocompleteProApi.Lookup("4770 Lincoln Ave O");
			lookup.AddStateFilter("IL");

			try
			{
				await client.Send(lookup);
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

		private static async Task TestUSExtractRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_EXTRACT")).RetryAtMost(0).BuildUsExtractApiClient();
			const string text = "Here is some text.\r\nMy address is 3785 Las Vegs Av." +
			                    "\r\nLos Vegas, Nevada." +
			                    "\r\nMeet me at 1 Rosedale Baltimore Maryland, not at 123 Phony Street, Boise Idaho.";

			var lookup = new SmartyStreets.USExtractApi.Lookup(text);

			try
			{
				await client.Send(lookup);
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

		private static async Task TestUSStreetRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_STREET")).RetryAtMost(0).BuildUsStreetApiClient();
			var lookup = new SmartyStreets.USStreetApi.Lookup("1 Rosedale, Baltimore, Maryland") {MaxCandidates = 10};

			try
			{
				await client.Send(lookup);
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

		private static async Task TestUSZIPCodeRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_ZIP")).RetryAtMost(0).BuildUsZipCodeApiClient();
			var lookup = new SmartyStreets.USZipCodeApi.Lookup(null, null, "38852");

			try
			{
				await client.Send(lookup);
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

		private static async Task TestReturnsCorrectNumberOfResultsViaProxy(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_ZIP")).ViaProxy("http://proxy.api.smarty.com:80", "", "")
				.BuildUsZipCodeApiClient();
			var lookup = new SmartyStreets.USZipCodeApi.Lookup(null, null, "38852");

			try
			{
				await client.Send(lookup);
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

		private static async Task TestUsEnrichmentPropertyPrincipalRequestReturnsCorrectNumberOfResults(ICredentials credentials){
			var client = new ClientBuilder(credentials).BuildUsEnrichmentApiClient();
			
			SmartyStreets.USEnrichmentApi.Property.Principal.Result[] results = null;
            try
            {
                results = await client.SendPropertyPrincipalLookup("1682393594");
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
			AssertResults("ENRICHMENT_PROPERTY_PRINCIPAL", results.Length, 1);
		}

		private static async Task TestUsEnrichmentPropertyFinancialRequestReturnsCorrectNumberOfResults(ICredentials credentials){
			var client = new ClientBuilder(credentials).BuildUsEnrichmentApiClient();
			
			SmartyStreets.USEnrichmentApi.Property.Financial.Result[] results = null;
            try
            {
                results = await client.SendPropertyFinancialLookup("1682393594");
            }
            catch (Exception)
            {
                Console.WriteLine("");
            }

			AssertResults("ENRICHMENT_FINANCIAL_PRINCIPAL", results.Length, 1);
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