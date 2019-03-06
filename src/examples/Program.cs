using System;

namespace Examples
{
	internal static class Program
	{
		private static void Main()
		{
            // TODO: Optionally you can set your ID/Token values here
            Environment.SetEnvironmentVariable("SMARTY_AUTH_ID", "Your Auth ID here");
            Environment.SetEnvironmentVariable("SMARTY_AUTH_TOKEN", "Your Auth Token here");

            var missingIdOrToken = false;
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SMARTY_AUTH_ID")))
            {
                missingIdOrToken = true;
                Console.WriteLine("Missing SMARTY_AUTH_ID. Please create an environment variable named SMARTY_AUTH_ID with your Auth ID.");
            }
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN")))
            {
                missingIdOrToken = true;
                Console.WriteLine("Missing SMARTY_AUTH_TOKEN. Please create an environment variable named SMARTY_AUTH_TOKEN with your Auth Token.");
            }
            // Run the examples
            if (!missingIdOrToken)
            {
                USStreetSingleAddressExample.RunAsync().Wait();
                USStreetLookupsWithMatchStrategyExamples.RunAsync().Wait();
                USStreetMultipleAddressesExample.RunAsync().Wait();
                USZipCodeSingleLookupExample.RunAsync().Wait();
                USZipCodeMultipleLookupsExample.RunAsync().Wait();

                // TODO: This example will fail if you do not have an international subscription.
                // InternationalStreetExample.RunAsync().Wait();

                USExtractExample.RunAsync().Wait();
                USAutocompleteExample.RunAsync().Wait();
            }
            // Leave the terminal open
            Console.ReadLine();
        }
	}
}