namespace Examples
{
	using System;
	using System.Net;
	using System.Collections.Generic;
	using System.IO;
    using System.Linq;
    using SmartyStreets;
	using SmartyStreets.USEnrichmentApi;
    using System.Reflection;
    using System.Text;

	internal static class USEnrichmentUniversalExample
	{
		public static void Run()
		{
            // specifies the TLS protocoll to use - this is TLS 1.2
            const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

            // var authId = "Your SmartyStreets Auth ID here";
            // var authToken = "Your SmartyStreets Auth Token here";

            // We recommend storing your keys in environment variables instead---it's safer!
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			ServicePointManager.SecurityProtocol = tlsProtocol1_2;

			var client = new ClientBuilder(authId, authToken).BuildUsEnrichmentApiClient();

			byte[] results = null;
            // See the US Enrichment API documenation for all available datasets and data subsets https://www.smarty.com/docs/cloud/us-address-enrichment-api#data-sets

            // Create a lookup with a smarty key using the line below
            var lookup = new SmartyStreets.USEnrichmentApi.Universal.Lookup("325023201","property","principal"); 

            // Create a lookup with address components using the lines below
            var componentsLookup = new SmartyStreets.USEnrichmentApi.Universal.Lookup();
            componentsLookup.SetDatasetName("property");
            componentsLookup.SetDataSubsetName("principal");
            componentsLookup.SetStreet("56 Union Ave");
            componentsLookup.SetCity("Somerville");
            componentsLookup.SetState("NJ");
            componentsLookup.SetZipcode("08876");

            //uncomment the line below to add a custom parameter
            //componentsLookup.AddCustomParameter("zipcode", "08876");

            // Create a lookup with a single line address using the lines below
            var freeformLookup = new SmartyStreets.USEnrichmentApi.Universal.Lookup();
            freeformLookup.SetDatasetName("property");
            freeformLookup.SetDataSubsetName("principal");
            freeformLookup.SetFreeform("56 Union Ave Somerville NJ 08876");

            // Options available for Lookup
            // lookup.SetEtag("AIDAIAQCAIEQKAIC");
            // lookup.SetIncludeFields("assessed_value,assessor_last_update"); // applicable to Property lookups only
            // lookup.SetExcludeFields("tax_fiscal_year,tax_jurisdiction"); // applicable to Property lookups only

            try {
                // results = client.SendUniversalLookup("325023201", "property", "principal"); // simple call with just a SmartyKey and Dataset info

                // Send a lookup using the line below
                results = client.SendUniversalLookup(componentsLookup);
            }
            catch (NotModifiedException ex) {
                Console.WriteLine(ex.Message); // The Etag value provided represents the latest version of the requested record
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
            if (results != null) {
                // results is the JSON response from the API
                Console.WriteLine(Encoding.UTF8.GetString(results));
            }
            else {
                Console.WriteLine("Result was null");
            }
        }
	}
}