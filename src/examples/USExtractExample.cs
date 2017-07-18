using System;
using SmartyStreets;
using Lookup = SmartyStreets.USExtractApi.Lookup;

namespace Examples
{
    public class USExtractExample
    {
        public static void Run()
        {
            // We recommend storing your secret keys in environment variables.
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
            var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");
            var client = new ClientBuilder(authId, authToken).BuildUsExtractApiClient();
            var text = "Here is some text.\r\nMy address is 3785 Las Vegs Av." +
                          "\r\nLos Vegas, Nevada." +
                          "\r\nMeet me at 1 Rosedale Baltimore Maryland, not at 123 Phony Street, Boise Idaho.";
            var lookup = new Lookup(text);

            client.Send(lookup);

            var result = lookup.Result;
            var metadata = result.Metadata;
            Console.WriteLine("Found " + metadata.AddressCount + " addresses.");
            Console.WriteLine(metadata.VerifiedCount + " of them were valid.");
            Console.WriteLine();

            var addresses = result.Addresses;

            Console.WriteLine("Addresses: \r\n**********************\r\n");
            foreach (var address in addresses)
            {
                Console.WriteLine("\"" + address.Text + "\"\n");
                Console.WriteLine("Verified? " + address.Verified);
                if (address.Candidates.Length > 0)
                {
                    Console.WriteLine("\nMatches:");

                    foreach (var candidate in address.Candidates)
                    {
                        Console.WriteLine(candidate.DeliveryLine1);
                        Console.WriteLine(candidate.LastLine);
                        Console.WriteLine();
                    }
                } else Console.WriteLine();

                Console.WriteLine("**********************\n");
            }
        }
    }
}