namespace Examples
{
	using System;
	using System.Net;
    using SmartyStreets;
    using System.Reflection;

    internal static class USEnrichmentPropertyExample
	{
		public static void Run()
		{
            // var authId = "Your SmartyStreets Auth ID here";
            // var authToken = "Your SmartyStreets Auth Token here";

            // We recommend storing your keys in environment variables instead---it's safer!
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

			using var client = new ClientBuilder(authId, authToken).BuildUsEnrichmentApiClient();
			

			SmartyStreets.USEnrichmentApi.Property.Principal.Result[] results = null;

            // Create a lookup with a smarty key using the line below
            var lookup = new SmartyStreets.USEnrichmentApi.Property.Principal.Lookup("325023201");
            
            // Create a lookup with address components using the lines below
            var componentsLookup = new SmartyStreets.USEnrichmentApi.Property.Principal.Lookup();
            componentsLookup.SetStreet("56 Union Ave");
            componentsLookup.SetCity("Somerville");
            componentsLookup.SetState("NJ");
            componentsLookup.SetZipcode("08876");

            //uncomment the below line to add a custom parameter
            //componentsLookup.AddCustomParameter("zipcode", "08876");

            // Create a lookup with a single line address using the line below
            var freeformLookup = new SmartyStreets.USEnrichmentApi.Property.Principal.Lookup();
            freeformLookup.SetFreeform("56 Union Ave Somerville NJ 08876");

            // See the US Enrichment API documenation for available lookup properties https://www.smarty.com/docs/cloud/us-address-enrichment-api#http-request-input-fields
            // Options available for the Property Lookup
            // lookup.SetEtag("AIDAIAQCAIEQKAIC");
            // lookup.SetIncludeFields("assessed_value,assessor_last_update");
            // lookup.SetExcludeFields("tax_fiscal_year,tax_jurisdiction");

            try {
                // results = client.SendPropertyPrincipalLookup("325023201"); // simple call with just a SmartyKey

                // Send a lookup using the line below
                results = client.SendPropertyPrincipalLookup(freeformLookup); // more flexible call to set other lookup options
            }
            catch (NotModifiedException ex) {
                Console.WriteLine(ex.Message); // The Etag value provided represents the latest version of the requested record
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
            if (results != null) {
                foreach (SmartyStreets.USEnrichmentApi.Property.Principal.Result result in results) {
                    PrintResult(result);
                }
            }
            else {
                Console.WriteLine("Result was null");
            }

            SmartyStreets.USEnrichmentApi.Property.Financial.Result[] financialResults = null;

            // Create a lookup with a smarty key using the line below
            var financialLookup = new SmartyStreets.USEnrichmentApi.Property.Financial.Lookup("325023201");

            // Create a lookup with address components using the lines below
            var financialComponentsLookup = new SmartyStreets.USEnrichmentApi.Property.Financial.Lookup();
            financialComponentsLookup.SetStreet("56 Union Ave");
            financialComponentsLookup.SetCity("Somerville");
            financialComponentsLookup.SetState("NJ");
            financialComponentsLookup.SetZipcode("08876");

            //uncomment the below line to add a custom parameter
            //financialComponentsLookup.AddCustomParameter("zipcode", "08876");

            // Create a lookup with a single line address using the line below
            var financialFreeformLookup = new SmartyStreets.USEnrichmentApi.Property.Financial.Lookup();
            financialFreeformLookup.SetFreeform("56 Union Ave Somerville NJ 08876");

            // Options available for the Property Lookup
            // financialLookup.SetEtag("AIDAIAQCAIEQKAIC");
            // financialLookup.SetIncludeFields("assessed_value,assessor_last_update");
            // financialLookup.SetExcludeFields("tax_fiscal_year,tax_jurisdiction");
            try {
                // financialResults = client.SendPropertyFinancialLookup("325023201"); // simple call with just a SmartyKey

                // Send a lookup using the line below
                financialResults = client.SendPropertyFinancialLookup(financialLookup); // more flexible call to set other lookup options
            }
            catch (NotModifiedException ex) {
                Console.WriteLine(ex.Message); // The Etag value provided represents the latest version of the requested record
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            if (financialResults != null) {
                foreach (SmartyStreets.USEnrichmentApi.Property.Financial.Result result in financialResults) {
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