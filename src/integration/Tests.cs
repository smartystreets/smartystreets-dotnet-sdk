namespace IntegrationTests
{
	using System;
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
			TestUSAutocompleteRequestReturnsWithCorrectNumberOfResults(credentials);
			TestUSAutocompleteProRequestReturnsWithCorrectNumberOfResults(shared);
			TestUSExtractRequestReturnsWithCorrectNumberOfResults(credentials);
			TestUSStreetRequestReturnsWithCorrectNumberOfResults(credentials);
			TestUSZIPCodeRequestReturnsWithCorrectNumberOfResults(credentials);
			TestReturnsCorrectNumberOfResultsViaProxy(credentials);
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

		private static void TestUSAutocompleteRequestReturnsWithCorrectNumberOfResults(ICredentials credentials)
		{
			var client = new ClientBuilder(credentials).WithCustomBaseUrl(Environment.GetEnvironmentVariable("SMARTY_URL_US_AUTOCOMPLETE")).RetryAtMost(0).BuildUsAutocompleteApiClient();
			var lookup = new SmartyStreets.USAutocompleteApi.Lookup("4770 Lincoln Ave O");
			lookup.AddStateFilter("IL");

			try
			{
				client.Send(lookup);
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

		private static void AssertResults(string apiType, int actualResultCount, int expectedResultCount)
		{
			if (actualResultCount == expectedResultCount)
				Console.Write(apiType + " - OK\n");
			else
				Console.Write(apiType + " - FAILED (Expected: " + expectedResultCount + ", Actual: " + actualResultCount + ")\n");
		}
	}
}