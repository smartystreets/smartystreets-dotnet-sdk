using System.Threading.Tasks;

namespace Examples
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // If no arguments, run all examples (default behavior)
                RunAllExamples();
                return;
            }

            foreach (var arg in args)
            {
                switch (arg.ToLowerInvariant())
                {
                    case "us_street_single":
                        USStreetSingleAddressExample.Run();
                        break;
                    case "us_street_multiple":
                        USStreetMultipleAddressesExample.Run();
                        break;
                    case "us_zipcode_single":
                        USZipCodeSingleLookupExample.Run();
                        break;
                    case "us_zipcode_multiple":
                        USZipCodeMultipleLookupsExample.Run();
                        break;
                    case "international_street":
                        InternationalStreetExample.Run();
                        break;
                    case "international_autocomplete":
                        InternationalAutocompleteExample.Run();
                        break;
                    case "us_extract":
                        USExtractExample.Run();
                        break;
                    case "us_autocomplete_pro":
                        USAutocompleteProExample.Run();
                        break;
                    case "us_reverse_geo":
                        USReverseGeoExample.Run();
                        break;
                    case "us_enrichment":
                        USEnrichmentPropertyExample.Run();
                        USEnrichmentGeoReferenceExample.Run();
                        USEnrichmentRiskExample.Run();
                        USEnrichmentSecondaryExample.Run();
                        USEnrichmentUniversalExample.Run();
                        break;
                }
            }
        }

        private static void RunAllExamples()
        {
            USStreetSingleAddressExample.Run();
            USStreetLookupsWithMatchStrategyExamples.Run();
            USStreetMultipleAddressesExample.Run();
            USZipCodeSingleLookupExample.Run();
            USZipCodeMultipleLookupsExample.Run();
            InternationalStreetExample.Run();
            InternationalAutocompleteExample.Run();
            USExtractExample.Run();
            USAutocompleteProExample.Run();
            USReverseGeoExample.Run();
            USEnrichmentPropertyExample.Run();
            USEnrichmentGeoReferenceExample.Run();
            USEnrichmentSecondaryExample.Run();
            USEnrichmentUniversalExample.Run();
        }
    }
}
