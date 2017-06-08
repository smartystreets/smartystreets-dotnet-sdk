using System;
using SmartyStreets;
using SmartyStreets.InternationalStreetApi;

namespace Examples
{
    public class InternationalStreetExample
    {
        public static void Run()
        {
            // We recommend storing your secret keys in environment variables.
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
            var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
            var client = new ClientBuilder(authId, authToken).BuildInternationalStreetApiClient();

            var lookup = new Lookup("Rua Padre Antonio D'Angelo 121 Casa Verde, Sao Paulo", "Brazil");
            lookup.Geocode = true; // Must be expressly set to get latitude and longitude.

            var candidates = client.Send(lookup); // The candidates are also stored in the lookup's 'result' field.

            var firstCandidate = candidates[0];
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