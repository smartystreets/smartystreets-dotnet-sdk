using System.Threading.Tasks;

namespace Examples
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                // If no arguments, run all examples (default behavior)
                await RunAllExamples();
                return;
            }

            foreach (var arg in args)
            {
                switch (arg.ToLowerInvariant())
                {
                    case "us_street_single":
                        await USStreetSingleAddressExample.Run();
                        break;
                    case "us_street_multiple":
                        await USStreetMultipleAddressesExample.Run();
                        break;
                    case "us_zipcode_single":
                        await USZipCodeSingleLookupExample.Run();
                        break;
                    case "us_zipcode_multiple":
                        await USZipCodeMultipleLookupsExample.Run();
                        break;
                    case "international_street":
                        await InternationalStreetExample.Run();
                        break;
                    case "international_autocomplete":
                        await InternationalAutocompleteExample.Run();
                        break;
                    case "us_extract":
                        await USExtractExample.Run();
                        break;
                    case "us_autocomplete_pro":
                        await USAutocompleteProExample.Run();
                        break;
                    case "us_reverse_geo":
                        await USReverseGeoExample.Run();
                        break;
                    case "us_enrichment":
                        await USEnrichmentPropertyExample.Run();
                        await USEnrichmentGeoReferenceExample.Run();
                        await USEnrichmentSecondaryExample.Run();
                        await USEnrichmentUniversalExample.Run();
                        break;
                }
            }
        }

        private static async Task RunAllExamples()
        {
            await USStreetSingleAddressExample.Run();
            await USStreetLookupsWithMatchStrategyExamples.Run();
            await USStreetMultipleAddressesExample.Run();
            await USZipCodeSingleLookupExample.Run();
            await USZipCodeMultipleLookupsExample.Run();
            await InternationalStreetExample.Run();
            await InternationalAutocompleteExample.Run();
            await USExtractExample.Run();
            await USAutocompleteProExample.Run();
            await USReverseGeoExample.Run();
            await USEnrichmentPropertyExample.Run();
            await USEnrichmentGeoReferenceExample.Run();
            await USEnrichmentSecondaryExample.Run();
            await USEnrichmentUniversalExample.Run();
        }
    }
}
