namespace Examples
{
	using System;
	using System.Net;
    using SmartyStreets;
    using System.Reflection;
    using System.Threading.Tasks;

    internal static class USEnrichmentSecondaryExample
	{
		public static void Run()
		{
            // var authId = "Your SmartyStreets Auth ID here";
            // var authToken = "Your SmartyStreets Auth Token here";

            // We recommend storing your keys in environment variables instead---it's safer!
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

			using var client = new ClientBuilder(new BasicAuthCredentials(authId, authToken)).BuildUsEnrichmentApiClient();
			
            // See the US Enrichment API documenation for all available datasets and data subsets https://www.smarty.com/docs/cloud/us-address-enrichment-api#data-sets
            SmartyStreets.USEnrichmentApi.Secondary.Result[] results = null;

            // Create a lookup with a smarty key using the line below
            var lookup = new SmartyStreets.USEnrichmentApi.Secondary.Lookup("325023201");
            
            // Create a lookup with address components using the lines below
            var componentsLookup = new SmartyStreets.USEnrichmentApi.Secondary.Lookup();
            componentsLookup.SetStreet("56 Union Ave");
            componentsLookup.SetCity("Somerville");
            componentsLookup.SetState("NJ");
            componentsLookup.SetZipcode("08876");

            //uncomment the below line to add a custom parameter
            //componentsLookup.AddCustomParameter("zipcode", "08876");

            // Create a lookup with a single line address using the line below
            var freeformLookup = new SmartyStreets.USEnrichmentApi.Secondary.Lookup();
            freeformLookup.SetFreeform("56 Union Ave Somerville NJ 08876");

            // Options available for Lookup
            // lookup.SetEtag("HAYDKMJXHA4DKNA");

            try {
                // results = client.SendSecondaryLookup("325023201"); // simple call with just a SmartyKey

                // Send a lookup using the line below
                results = client.SendSecondaryLookup(lookup);
            }
            catch (NotModifiedException ex) {
                Console.WriteLine(ex.Message); // The Etag value provided represents the latest version of the requested record
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
            if (!(results is null)) {
                foreach (SmartyStreets.USEnrichmentApi.Secondary.Result result in results) {
                    PrintResult(result);
                    if (!(result.Aliases is null)) {
                        Console.WriteLine("Aliases: {");
                        foreach (SmartyStreets.USEnrichmentApi.Secondary.Aliases alias in result.Aliases) {
                            PrintResult(alias);
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

            // Create a lookup with a smarty key using the line below
            var countLookup = new SmartyStreets.USEnrichmentApi.Secondary.Count.Lookup("325023201");
            
            // Create a lookup with address components using the lines below
            var countComponentsLookup = new SmartyStreets.USEnrichmentApi.Secondary.Lookup();
            countComponentsLookup.SetStreet("56 Union Ave");
            countComponentsLookup.SetCity("Somerville");
            countComponentsLookup.SetState("NJ");
            countComponentsLookup.SetZipcode("08876");

            //uncomment the below line to add a custom parameter
            //countComponentsLookup.AddCustomParameter("zipcode", "08876");

            // Create a lookup with a single line address using the line below
            var countFreeformLookup = new SmartyStreets.USEnrichmentApi.Secondary.Count.Lookup();
            countFreeformLookup.SetFreeform("56 Union Ave Somerville NJ 08876");

            // Options available for Lookup
            // lookup.SetEtag("HAYDKMJXHA4DKNA");

            try {
                // results = client.SendSecondaryCountLookup("325023201"); // simple call with just a SmartyKey

                // Send a lookup using the line below
                countResults = client.SendSecondaryCountLookup(countLookup);
            }
            catch (NotModifiedException ex) {
                Console.WriteLine(ex.Message); // The Etag value provided represents the latest version of the requested record
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
            if (!(countResults is null)) {
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
                else if (!(property.GetValue(obj, null) is null) && property.Name != "Aliases" && property.Name != "Secondaries") {
                    Console.WriteLine($"{property.Name}: {property.GetValue(obj, null)}");
                }
            }
        }
	}
}
