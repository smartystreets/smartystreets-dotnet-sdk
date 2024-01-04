namespace Examples
{
	using System;
	using System.Net;
	using System.Collections.Generic;
	using System.IO;
    using SmartyStreets;
	using SmartyStreets.USEnrichmentApi;

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

			// The appropriate license values to be used for your subscriptions
			// can be found on the Subscriptions page the account dashboard.
			// https://www.smartystreets.com/docs/cloud/licensing
			var client = new ClientBuilder(authId, authToken).WithLicense(new List<string>{"us-geocoding-cloud"})
				.BuildUsEnrichmentApiClient();
			
			PrincipalResponse[] results = null;
            try
            {
                results = client.sendPropertyPrincipalLookup("1682393594");
            }
            catch (SmartyException ex)
            {
                Console.WriteLine(ex.Message);
                ex.StackTrace();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                ex.StackTrace();
            }
            catch (InterruptedException ex)
            {
                Console.WriteLine(ex.Message);
                ex.StackTrace();
            }

            if (results != null)
            {
                Console.WriteLine(string.Join(", ", results));
            }
            else
            {
                Console.WriteLine("Result was null");
            }

            FinancialResponse[] financialResults = null;
            try
            {
                financialResults = client.sendPropertyFinancialLookup("1682393594");
            }
            catch (SmartyException ex)
            {
                Console.WriteLine(ex.Message);
                ex.StackTrace();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                ex.StackTrace();
            }
            catch (InterruptedException ex)
            {
                Console.WriteLine(ex.Message);
                ex.StackTrace();
            }

            if (financialResults != null)
            {
                Console.WriteLine(string.Join(", ", financialResults));
            }
            else
            {
                Console.WriteLine("Result was null");
            }


		}
	}
}