namespace IntegrationTests
{
	using System;
    using System.Threading.Tasks;
    using SmartyStreets;
	using SmartyStreets.InternationalStreetApi;

	internal static class Tests
	{
		public static async Task RunAllApiIntegrationTestsAsync()
		{
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var credentials = new StaticCredentials(authId, authToken);

			await TestInternationalStreetRequestReturnsWithCorrectNumberOfResultsAsync(credentials);
			await TestUSAutocompleteRequestReturnsWithCorrectNumberOfResultsAsync(credentials);
			await TestUSExtractRequestReturnsWithCorrectNumberOfResultsAsync(credentials);
			await TestUSStreetRequestReturnsWithCorrectNumberOfResultsAsync(credentials);
			await TestUSZIPCodeRequestReturnsWithCorrectNumberOfResultsAsync(credentials);
			await TestReturnsCorrectNumberOfResultsViaProxyAsync(credentials);
		}

		private static async Task TestInternationalStreetRequestReturnsWithCorrectNumberOfResultsAsync(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_INTERNATIONAL_STREET")).RetryAtMost(0).BuildInternationalStreetApiClient();
			var lookup = new Lookup("Rua Padre Antonio D'Angelo 121 Casa Verde, Sao Paulo", "Brazil");

			try
			{
				await client.SendAsync(lookup);
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

		private static async Task TestUSAutocompleteRequestReturnsWithCorrectNumberOfResultsAsync(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_AUTOCOMPLETE")).RetryAtMost(0).BuildUsAutocompleteApiClient();
			var lookup = new SmartyStreets.USAutocompleteApi.Lookup("4770 Lincoln Ave O");
			lookup.AddStateFilter("IL");

			try
			{
				await client.SendAsync(lookup);
			}
			catch (Exception)
			{
				Console.Write("");
			}

			var suggestions = 0;
			if (lookup.Result != null)
				suggestions = lookup.Result.Length;

			AssertResults("US_Autocomplete", suggestions, 9);
		}

		private static async Task TestUSExtractRequestReturnsWithCorrectNumberOfResultsAsync(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_EXTRACT")).RetryAtMost(0).BuildUsExtractApiClient();
			const string text = "Here is some text.\r\nMy address is 3785 Las Vegs Av." +
			                    "\r\nLos Vegas, Nevada." +
			                    "\r\nMeet me at 1 Rosedale Baltimore Maryland, not at 123 Phony Street, Boise Idaho.";

			var lookup = new SmartyStreets.USExtractApi.Lookup(text);

			try
			{
				await client.SendAsync(lookup);
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

		private static async Task TestUSStreetRequestReturnsWithCorrectNumberOfResultsAsync(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_STREET")).RetryAtMost(0).BuildUsStreetApiClient();
			var lookup = new SmartyStreets.USStreetApi.Lookup("1 Rosedale, Baltimore, Maryland") {MaxCandidates = 10};

			try
			{
				await client.SendAsync(lookup);
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

		private static async Task TestUSZIPCodeRequestReturnsWithCorrectNumberOfResultsAsync(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_ZIP")).RetryAtMost(0).BuildUsZipCodeApiClient();
			var lookup = new SmartyStreets.USZipCodeApi.Lookup(null, null, "38852");

			try
			{
				await client.SendAsync(lookup);
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

		private static async Task TestReturnsCorrectNumberOfResultsViaProxyAsync(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_ZIP")).ViaProxy("http://proxy.api.smartystreets.com:80", "", "")
				.BuildUsZipCodeApiClient();
			var lookup = new SmartyStreets.USZipCodeApi.Lookup(null, null, "38852");

			try
			{
				await client.SendAsync(lookup);
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

		private static void AssertResults(string apiType, int actualResultCount, int expectedResultCount)
		{
			if (actualResultCount == expectedResultCount)
				Console.Write(apiType + " - OK\n");
			else
				Console.Write(apiType + " - FAILED (Expected: " + expectedResultCount + ", Actual: " + actualResultCount + ")\n");
		}
	}
}