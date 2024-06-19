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

	internal static class USEnrichmentPropertyExample
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
			

			SmartyStreets.USEnrichmentApi.Property.Principal.Result[] results = null;
            var lookup = new SmartyStreets.USEnrichmentApi.Property.Principal.Lookup("1682393594");
            // See the US Enrichment API documenation for available lookup properties https://www.smarty.com/docs/cloud/us-address-enrichment-api#http-request-input-fields
            // Options available for the Property Lookup
            // lookup.SetEtag("GU4TINZRHA4TQMY");
            // lookup.SetIncludeFields("assessed_value,assessor_last_update");
            // lookup.SetExcludeFields("tax_fiscal_year,tax_jurisdiction");
            try {
                // results = client.SendPropertyPrincipalLookup("1682393594"); // simple call with just a SmartyKey
                results = client.SendPropertyPrincipalLookup(lookup); // more flexible call to set other lookup options
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
            var financialLookup = new SmartyStreets.USEnrichmentApi.Property.Financial.Lookup("1682393594");
            // Options available for the Property Lookup
            // financialLookup.SetEtag("GU4TINZRHA4TQMY");
            // financialLookup.SetIncludeFields("assessed_value,assessor_last_update");
            // financialLookup.SetExcludeFields("tax_fiscal_year,tax_jurisdiction");
            try {
                // financialResults = client.SendPropertyFinancialLookup("1682393594"); // simple call with just a SmartyKey
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
                if (property.Name == "Attributes" ){
                    PrintResult(property.GetValue(obj, null));
                }
                if (property.GetValue(obj, null) != null) {
                    Console.WriteLine($"{property.Name}: {property.GetValue(obj, null)}");
                }
            }
            Console.WriteLine();
        }
	}
}