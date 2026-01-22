namespace Examples
{
	using System;
    using System.IO;
    using System.Net;
    using SmartyStreets;
	using SmartyStreets.InternationalAutocompleteApi;

    public class InternationalAutocompleteExample
    {
        public static void Run()
		{
            // We recommend storing your secret keys in environment variables.
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

			using var client = new ClientBuilder(new BasicAuthCredentials(authId, authToken)).BuildInternationalAutocompleteApiClient();
			
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
            
            if (candidates == null)
            {
                Console.WriteLine("No candidates. This means the address is not valid.");
                return;
            }
            
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