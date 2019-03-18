namespace Examples
{
	using System;
	using SmartyStreets;
	using SmartyStreets.USAutocompleteApi;

	internal static class USAutocompleteExample
	{
		public static void Run()
		{
			// We recommend storing your secret keys in environment variables.
			var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var client = new ClientBuilder(authId, authToken).BuildUsAutocompleteApiClient();
			var lookup = new Lookup("4770 Lincoln Ave O");
			lookup.GeolocateType = "null";

			client.Send(lookup);

			Console.WriteLine("*** Result with no filter ***");
			Console.WriteLine();
			foreach (var suggestion in lookup.Result)
				Console.WriteLine(suggestion.Text);
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/cloud/us-autocomplete-api#http-request-input-fields

			lookup.AddCityFilter("Ogden");
			lookup.AddStateFilter("IL");
			lookup.AddPrefer("Ogden, IL");
			lookup.MaxSuggestions = 5;
			lookup.PreferRatio = 0.3333333;

			client.Send(lookup);

			var suggestions = lookup.Result;

			Console.WriteLine();
			Console.WriteLine("*** Result with some filters ***");
			foreach (var suggestion in suggestions)
				Console.WriteLine(suggestion.Text);
		}
	}
}