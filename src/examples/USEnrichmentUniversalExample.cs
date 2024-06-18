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
            try {
                // See the US Enrichment API documenation for all available datasets and data subsets https://www.smarty.com/docs/cloud/us-address-enrichment-api#data-sets
                var lookup = new SmartyStreets.USEnrichmentApi.Universal.Lookup("1682393594","property","principal"); 
                results = client.SendUniversalLookup(lookup);
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