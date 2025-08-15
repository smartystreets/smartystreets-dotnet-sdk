namespace Examples
{
	using System;
	using System.Net;
    using SmartyStreets;
    using System.Reflection;
    using System.Threading.Tasks;

    internal static class USEnrichmentGeoReferenceExample
	{
		public static void Run()
		{
            // var authId = "Your SmartyStreets Auth ID here";
            // var authToken = "Your SmartyStreets Auth Token here";

            // We recommend storing your keys in environment variables instead---it's safer!
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

			using var client = new ClientBuilder(authId, authToken).BuildUsEnrichmentApiClient();
			
			SmartyStreets.USEnrichmentApi.GeoReference.Result[] results = null;
            
            // Create a lookup with a smarty key using the line below
            var lookup = new SmartyStreets.USEnrichmentApi.GeoReference.Lookup("325023201");
            
            // Create a lookup with address components using the lines below
            var componentsLookup = new SmartyStreets.USEnrichmentApi.GeoReference.Lookup();
            componentsLookup.SetStreet("56 Union Ave");
            componentsLookup.SetCity("Somerville");
            componentsLookup.SetState("NJ");
            componentsLookup.SetZipcode("08876");

            //uncomment the below line to add a custom parameter
            //componentsLookup.AddCustomParameter("zipcode", "08876");

            // Create a lookup with a single line address using the line below
            var freeformLookup = new SmartyStreets.USEnrichmentApi.GeoReference.Lookup();
            freeformLookup.SetFreeform("56 Union Ave Somerville NJ 08876");

            // Options available for the GeoReference Lookup
            // lookup.SetEtag("GEZDSNBUHE3DEMQ");
    
            try {
                // results = client.SendGeoReferenceLookup("325023201");  // simple call with just a SmartyKey

                // Send a lookup using the line below
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