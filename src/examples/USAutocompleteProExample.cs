namespace Examples
{
	using System;
	using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using SmartyStreets;
	using SmartyStreets.USAutocompleteProApi;

	internal static class USAutocompleteProExample
	{
		public static void Run()
		{
            // specifies the TLS protocoll to use - this is TLS 1.2
            const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

            //var key = Environment.GetEnvironmentVariable("SMARTY_AUTH_WEB");
			//var hostname = Environment.GetEnvironmentVariable("SMARTY_WEBSITE_DOMAIN");
			//var credentials = new SharedCredentials(key, hostname);

            // We recommend storing your secret keys in environment variables.
            var id = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var token = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			var credentials = new StaticCredentials(id, token);
            ServicePointManager.SecurityProtocol = tlsProtocol1_2;

            var client = new ClientBuilder(credentials).BuildUsAutocompleteProApiClient();

			var lookup = new Lookup("1042 W Center");
			lookup.PreferGeolocation = "none";

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

            var suggestions = lookup.Result;

            if (suggestions == null)
            {
                Console.WriteLine("No suggestions.");
                return;
            }

            Console.WriteLine("*** Result with no filter ***");
			Console.WriteLine();
			foreach (var suggestion in lookup.Result)
				Console.WriteLine(suggestion.Street, suggestion.City, ", ", suggestion.State);
				
				
			
			// Documentation for input fields can be found at:
			// https://smartystreets.com/docs/cloud/us-autocomplete-api#http-request-input-fields

			lookup.AddCityFilter("Denver,Aurora,CO");
			lookup.AddCityFilter("Orem,UT");
			lookup.AddPreferState("CO");
			lookup.AddPreferState("UT");
			//lookup.Selected = "1042 W Center St Apt A (24) Orem UT 84057";
			lookup.MaxResults = 5;
			lookup.PreferGeolocation = GeolocateType.NONE;
			lookup.PreferRatio = 4;
			lookup.Source = "all";

			//uncomment the below line to add a custom parameter
			//lookup.AddCustomParameter("source", "all");

            try
            {
                client.Send(lookup);
            }
            catch (SmartyException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                //return;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return;
            }

            suggestions = lookup.Result;

            if (suggestions == null)
            {
                Console.WriteLine("No suggestions.");
                return;
            }

            Console.WriteLine();
			Console.WriteLine("*** Result with some filters ***");
			foreach (var suggestion in suggestions)
				Console.WriteLine(suggestion.Street + " " + suggestion.City + ", " + suggestion.State);
		}
	}
}