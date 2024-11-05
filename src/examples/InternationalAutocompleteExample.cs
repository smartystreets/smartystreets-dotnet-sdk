namespace Examples
{
	using System;
	using System.Collections.Generic;
    using System.Net;
    using SmartyStreets;
	using SmartyStreets.InternationalAutocompleteApi;

    public class InternationalAutocompleteExample
    {
        public static void Run()
		{
            // specifies the TLS protocoll to use - this is TLS 1.2
            const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

            // We recommend storing your secret keys in environment variables.
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			ServicePointManager.SecurityProtocol = tlsProtocol1_2;

			// The appropriate license values to be used for your subscriptions
			// can be found on the Subscriptions page the account dashboard.
			// https://www.smartystreets.com/docs/cloud/licensing
			var client = new ClientBuilder(authId, authToken).WithLicense(new List<string>{"international-autocomplete-v2-cloud"})
				.BuildInternationalAutocompleteApiClient();
			
			// Documentation for input fields can be found at:
			// https://smartystreetscom/docs/cloud/international-street-api#http-input-fields

			// Geocoding must be expressly set to get latitude and longitude.
			var lookup = new Lookup("Louis")
			{
				Country = "FRA",
				Locality = "Paris",
			};

			//uncomment the line below to add a custom parameter
			//lookup.AddCustomParameter("max_results", "3");

			client.Send(lookup);

			var candidates = lookup.Result;
			Console.WriteLine();
			Console.WriteLine("*** Results ***");
			foreach (var candidate in candidates)
			{
				if (candidate.AddressText != null) {
					Console.Write(candidate.Entries);
					Console.Write(" ");
					Console.Write(candidate.AddressText);
					Console.Write(", ");
					Console.WriteLine(candidate.AddressID);
				} else {
					Console.Write(candidate.Street);
					Console.Write(" ");
					Console.Write(candidate.Locality);
					Console.Write(", ");
					Console.WriteLine(candidate.CountryISO3);
				}
			}
		}
				
    }
}