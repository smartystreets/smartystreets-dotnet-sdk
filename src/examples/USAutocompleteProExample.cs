namespace Examples
{
	using System;
	using SmartyStreets;
	using SmartyStreets.USAutocompleteProApi;

	internal static class USAutocompleteProExample
	{
		public static void Run()
		{
			// We recommend storing your secret keys in environment variables.
			var key = Environment.GetEnvironmentVariable("SMARTY_AUTH_WEB");
			var hostname = Environment.GetEnvironmentVariable("SMARTY_WEBSITE_DOMAIN");
			var credentials = new SharedCredentials(key, hostname);
			var client = new ClientBuilder(credentials).BuildUsAutocompleteProApiClient();
			var lookup = new Lookup("4770 Lincoln Ave O");
			lookup.PreferGeolocation = "null";

			client.Send(lookup);

			Console.WriteLine("*** Result with no filter ***");
			Console.WriteLine();
			foreach (var suggestion in lookup.Result)
				Console.WriteLine(suggestion.StreetLine, suggestion.City, ", ", suggestion.State);
				
				
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/cloud/us-autocomplete-api#http-request-input-fields

			lookup.AddCityFilter("Ogden");
			lookup.AddStateFilter("IL");
			lookup.AddPreferCity("Ogden");
			lookup.AddPreferState("IL");
			lookup.MaxResults = 5;
			lookup.PreferRatio = 3;

			client.Send(lookup);

			var suggestions = lookup.Result;

			Console.WriteLine();
			Console.WriteLine("*** Result with some filters ***");
			foreach (var suggestion in suggestions)
				Console.WriteLine(suggestion.StreetLine, suggestion.City, ", ", suggestion.State);
		}
	}
}