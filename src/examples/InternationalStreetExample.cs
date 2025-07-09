namespace Examples
{
	using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using SmartyStreets;
	using SmartyStreets.InternationalStreetApi;

	internal static class InternationalStreetExample
	{
		public static async Task Run()
		{
            // specifies the TLS protocoll to use - this is TLS 1.2
            const SecurityProtocolType tlsProtocol1_2 = (SecurityProtocolType)3072;

            // We recommend storing your secret keys in environment variables.
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
			var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
			ServicePointManager.SecurityProtocol = tlsProtocol1_2;

			var client = new ClientBuilder(authId, authToken).BuildInternationalStreetApiClient();
			
			// Documentation for input fields can be found at:
			// https://smartystreetscom/docs/cloud/international-street-api#http-input-fields

			// Geocoding must be expressly set to get latitude and longitude.
			var lookup = new Lookup("Rua Padre Antonio D'Angelo 121 Casa Verde, Sao Paulo", "Brazil")
			{
				InputId = "ID-8675309", // Optional ID from your system
				Geocode = true,
				Organization = "John Doe",
				Address1 = "Rua Padre Antonio D'Angelo 121",
				Address2 = "Casa Verde",
				Locality = "Sao Paulo",
				AdministrativeArea = "SP",
				Country = "Brazil",
				PostalCode = "02516-050"
			};
			
			//uncomment the line below to add a custom parameter
			//lookup.AddCustomParameter("input_id", "ID-8675309");

            try
            {
                await client.Send(lookup);
            }
            catch (SmartyException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return;
            }

            var candidates = lookup.Result;

            if (candidates.Count == 0)
            {
                Console.WriteLine("No candidates. This means the address is not valid.");
                return;
            }

            var firstCandidate = candidates[0];
			Console.WriteLine("Input ID: " + firstCandidate.InputId);
			Console.WriteLine("Address is " + firstCandidate.Analysis.VerificationStatus);
			Console.WriteLine("Address precision: " + firstCandidate.Analysis.AddressPrecision + "\n");

			Console.WriteLine("First Line: " + firstCandidate.Address1);
			Console.WriteLine("Second Line: " + firstCandidate.Address2);
			Console.WriteLine("Third Line: " + firstCandidate.Address3);
			Console.WriteLine("Fourth Line: " + firstCandidate.Address4);
			Console.WriteLine("Address Format: " + firstCandidate.Metadata.AddressFormat);
			Console.WriteLine("Latitude: " + firstCandidate.Metadata.Latitude);
			Console.WriteLine("Longitude: " + firstCandidate.Metadata.Longitude);
		}
	}
}
