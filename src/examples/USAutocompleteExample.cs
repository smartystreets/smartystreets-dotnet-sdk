namespace Examples
{
	using System;
    using System.IO;
    using SmartyStreets;
	using SmartyStreets.USAutocompleteApi;

	// This example is for US Autocomplete (V2). It has the same name as a previous product
	// which has been deprecated since 2022, which we refer to as US Autocomplete Basic.
	// If you are still using US Autocomplete Basic, this SDK will not work.
	internal static class USAutocompleteExample
	{
		public static void Run()
		{
            //var key = Environment.GetEnvironmentVariable("SMARTY_AUTH_WEB");
			//var hostname = Environment.GetEnvironmentVariable("SMARTY_WEBSITE_DOMAIN");
			//var credentials = new SharedCredentials(key, hostname);

            // We recommend storing your secret keys in environment variables.
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

            using var client = new ClientBuilder(new BasicAuthCredentials(authId, authToken)).BuildUsAutocompleteApiClient();

			var lookup = new Lookup("1042 W Center");
			lookup.PreferGeolocation = GeolocateType.NONE;

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

            if (lookup.Result == null)
            {
                Console.WriteLine("No suggestions.");
                return;
            }

            Console.WriteLine("*** Result with no filter ***");
			Console.WriteLine();
			foreach (var suggestion in lookup.Result)
				Console.WriteLine(suggestion.Street + " " + suggestion.City + ", " + suggestion.State);

			// Documentation for input fields can be found at:
			// https://www.smarty.com/docs/apis/us-autocomplete-v2/reference#http-request-input-fields

			lookup.AddCityFilter("Denver,Aurora,CO");
			lookup.AddCityFilter("Orem,UT");
			lookup.AddPreferState("CO");
			//lookup.Selected = "1042 W Center St Apt A (24) Orem UT 84057";
			lookup.MaxResults = 5;
			lookup.PreferGeolocation = GeolocateType.NONE;
			lookup.PreferRatio = 4;
			lookup.Source = SourceType.ALL;

			//uncomment the below line to add a custom parameter
            //lookup.AddCustomParameter("parameter", "value");

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

            if (lookup.Result == null)
            {
                Console.WriteLine("No suggestions.");
                return;
            }

            Console.WriteLine();
			Console.WriteLine("*** Result with some filters ***");
			string entryId = null;
			foreach (var suggestion in lookup.Result)
			{
				Console.WriteLine(suggestion.Street + " " + suggestion.City + ", " + suggestion.State);
				if (!string.IsNullOrEmpty(suggestion.EntryId))
					entryId = suggestion.EntryId;
			}

			// Expand the secondaries of a result that has an entry_id by passing it back as the selected address.
			if (!string.IsNullOrEmpty(entryId))
			{
				lookup.Selected = entryId;

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

				Console.WriteLine();
				Console.WriteLine("*** Secondaries ***");
				foreach (var suggestion in lookup.Result)
					Console.WriteLine(suggestion.Street + " " + suggestion.City + ", " + suggestion.State);
			}
		}
	}
}
