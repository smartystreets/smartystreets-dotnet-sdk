namespace Examples
{
	using System;
	using System.Net;
    using SmartyStreets;
    using System.Reflection;
    using System.Threading.Tasks;

    internal static class USEnrichmentRiskExample
	{
		public static void Run()
		{

            // var authId = "Your SmartyStreets Auth ID here";
            // var authToken = "Your SmartyStreets Auth Token here";

            // We recommend storing your keys in environment variables instead---it's safer!
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

			using var client = new ClientBuilder(authId, authToken).BuildUsEnrichmentApiClient();
			
			SmartyStreets.USEnrichmentApi.Risk.Result[] results = null;
            
            // Create a lookup with a smarty key using the line below
            var lookup = new SmartyStreets.USEnrichmentApi.Risk.Lookup("325023201");
            
            // Create a lookup with address components using the lines below
            var componentsLookup = new SmartyStreets.USEnrichmentApi.Risk.Lookup();
            componentsLookup.SetStreet("56 Union Ave");
            componentsLookup.SetCity("Somerville");
            componentsLookup.SetState("NJ");
            componentsLookup.SetZipcode("08876");

            //uncomment the below line to add a custom parameter
            //componentsLookup.AddCustomParameter("zipcode", "08876");

            // Create a lookup with a single line address using the line below
            var freeformLookup = new SmartyStreets.USEnrichmentApi.Risk.Lookup();
            freeformLookup.SetFreeform("56 Union Ave Somerville NJ 08876");

            // Options available for the Risk Lookup
            // lookup.SetEtag("GEZDSNBUHE3DEMQ");
    
            try {
                // results = client.SendRiskLookup("325023201");  // simple call with just a SmartyKey

                // Send a lookup using the line below
                results = client.SendRiskLookup(freeformLookup); // more flexible call to set other lookup options
            }
            catch (NotModifiedException ex) {
                Console.WriteLine(ex.Message); // The Etag value provided represents the latest version of the requested record
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
            if (results != null) {
                foreach (SmartyStreets.USEnrichmentApi.Risk.Result result in results) {
                    PrintResult(result);
                }
            }
            else {
                Console.WriteLine("Result was null");
            }
		}

        private static void PrintResult(object obj){
            Type type = obj.GetType();

            foreach (PropertyInfo property in type.GetProperties()) {
                if (property.Name == "Attributes" || property.Name == "MatchedAddress" ){
                    if (property.GetValue(obj, null) != null) {
                        PrintResult(property.GetValue(obj, null));
                    }
                }
                if (property.GetValue(obj, null) != null) {
                    Console.WriteLine($"{property.Name}: {property.GetValue(obj, null)}");
                }
            }
            Console.WriteLine();
        }
	}
}