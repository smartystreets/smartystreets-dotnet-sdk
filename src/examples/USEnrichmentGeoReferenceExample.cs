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

	internal static class USEnrichmentGeoReferenceExample
	{
		public static void Run()
		{
            // specifies the TLS protocol to use - this is TLS 1.2
            const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

            // var authId = "Your SmartyStreets Auth ID here";
            // var authToken = "Your SmartyStreets Auth Token here";

            // We recommend storing your keys in environment variables instead---it's safer!
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			ServicePointManager.SecurityProtocol = tlsProtocol1_2;

			var client = new ClientBuilder(authId, authToken).BuildUsEnrichmentApiClient();
			
			SmartyStreets.USEnrichmentApi.GeoReference.Result[] results = null;
            var lookup = new SmartyStreets.USEnrichmentApi.GeoReference.Lookup("1682393594");
            // Options available for the GeoReference Lookup
            // lookup.SetEtag("GEZTSMZYHE3DMNA");
            try {
                // results = client.SendGeoReferenceLookup("1682393594");  // simple call with just a SmartyKey
                results = client.SendGeoReferenceLookup(lookup); // more flexible call to set other lookup options
            }
            catch (NotModifiedException ex) {
                Console.WriteLine(ex.Message); // The Etag value provided represents the latest version of the requested record
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
            
            if (results != null) {
                foreach (SmartyStreets.USEnrichmentApi.GeoReference.Result result in results) {
                    Console.WriteLine("SmartyKey: " +result.SmartyKey);
                    Console.WriteLine("DataSet: " +result.DataSetName);
                    Console.WriteLine("Etag: " +result.Etag);
                    Console.WriteLine("CensusBlock");
                    PrintObjectAttributes(result.Attributes.CensusBlock, 4);
                    Console.WriteLine("CensusCountyDivision");
                    PrintObjectAttributes(result.Attributes.CensusCountyDivision, 4);
                    Console.WriteLine("CensusTract");
                    PrintObjectAttributes(result.Attributes.CensusTract, 4);
                    Console.WriteLine("CoreBasedStatArea");
                    PrintObjectAttributes(result.Attributes.CoreBasedStatArea, 4);
                    Console.WriteLine("Place");
                    PrintObjectAttributes(result.Attributes.Place, 4);
                }
            }
            else {
                Console.WriteLine("Result was null");
            }
		}

        private static void PrintObjectAttributes(object obj, int indent){
            if (obj == null) {
                Console.WriteLine(new string(' ', indent) + "No attributes are available for this object.");
                return;
            }
            
            Type type = obj.GetType();

            foreach (PropertyInfo property in type.GetProperties()) {
                if (property.GetValue(obj, null) != null) {
                    Console.WriteLine(new string(' ',indent) + $"{property.Name}: {property.GetValue(obj, null)}");
                }
            }
        }
	}
}