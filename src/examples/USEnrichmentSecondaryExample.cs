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

	internal static class USEnrichmentSecondaryExample
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
			
            // See the US Enrichment API documenation for all available datasets and data subsets https://www.smarty.com/docs/cloud/us-address-enrichment-api#data-sets
            SmartyStreets.USEnrichmentApi.Secondary.Result[] results = null;
            var lookup = new SmartyStreets.USEnrichmentApi.Secondary.Lookup("325023201");
            // Options available for Lookup
            // lookup.SetEtag("HAYDKMJXHA4DKNA");

            try {
                results = client.SendSecondaryLookup(lookup);
            }
            catch (NotModifiedException ex) {
                Console.WriteLine(ex.Message); // The Etag value provided represents the latest version of the requested record
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
            if (results is not null) {
                foreach (SmartyStreets.USEnrichmentApi.Secondary.Result result in results) {
                    PrintResult(result);
                    if (result.Aliases != null) {
                        Console.WriteLine("Aliases: {");
                        foreach (SmartyStreets.USEnrichmentApi.Secondary.Aliases alias in result.Aliases) {
                            PrintResult(alias);
                            if (indexOf(result.Aliases, alias)) {
                                
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("}\n");
                    }
                    Console.WriteLine("Secondaries: {");
                    foreach (SmartyStreets.USEnrichmentApi.Secondary.Secondaries secondary in result.Secondaries) {
                        PrintResult(secondary);
                        Console.WriteLine();
                    }
                    Console.WriteLine("}\n");
                }
            }
            else {
                Console.WriteLine("Result was null");
            }

            SmartyStreets.USEnrichmentApi.Secondary.Count.Result[] countResults = null;
            var countLookup = new SmartyStreets.USEnrichmentApi.Secondary.Count.Lookup("325023201");
            // Options available for Lookup
            // lookup.SetEtag("HAYDKMJXHA4DKNA");

            try {
                countResults = client.SendSecondaryCountLookup(countLookup);
            }
            catch (NotModifiedException ex) {
                Console.WriteLine(ex.Message); // The Etag value provided represents the latest version of the requested record
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
            if (countResults != null) {
                Console.WriteLine("Count: {");
                foreach (SmartyStreets.USEnrichmentApi.Secondary.Count.Result result in countResults) {
                    PrintResult(result);
                }
                Console.WriteLine("}");
            }
            else {
                Console.WriteLine("Result was null");
            }
        }


        private static void PrintResult(object obj){
            Type type = obj.GetType();
            
            foreach (PropertyInfo property in type.GetProperties()) {
                if (property.Name == "RootAddress") {
                    Console.WriteLine("Root Address: {");
                    PrintResult(property.GetValue(obj, null));
                    Console.WriteLine("}\n");
                }
                else if (property.GetValue(obj, null) != null && property.Name != "Aliases" && property.Name != "Secondaries") {
                    Console.WriteLine($"{property.Name}: {property.GetValue(obj, null)}");
                }
            }
        }
	}
}
