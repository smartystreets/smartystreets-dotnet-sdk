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

	internal static class USEnrichmentExample
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
            try
            {
                results = client.SendPropertyPrincipalLookup("1682393594");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
            if (results != null)
            {
                foreach (SmartyStreets.USEnrichmentApi.Property.Principal.Result result in results) {
                    printResult(result);
                }
            }
            else
            {
                Console.WriteLine("Result was null");
            }


            SmartyStreets.USEnrichmentApi.Property.Financial.Result[] financialResults = null;
            try
            {
                financialResults = client.SendPropertyFinancialLookup("1682393594");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

            if (financialResults != null)
            {
                foreach (SmartyStreets.USEnrichmentApi.Property.Financial.Result result in financialResults) {
                    printResult(result);
                }
            }
            else
            {
                Console.WriteLine("Result was null");
            }
		}

        private static void printResult(object obj){
            Type type = obj.GetType();

            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.Name == "Attributes" ){
                    printResult(property.GetValue(obj, null));
                }
                if (property.GetValue(obj, null) != null) {
                    Console.WriteLine($"{property.Name}: {property.GetValue(obj, null)}");
                }
            }
        }
	}
}