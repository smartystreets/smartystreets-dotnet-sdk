namespace Examples
{
    using System;
    using System.Reflection;
    using SmartyStreets;

    internal static class USEnrichmentBusinessNameSearchExample
    {
        public static void Run()
        {
            // var authId = "Your SmartyStreets Auth ID here";
            // var authToken = "Your SmartyStreets Auth Token here";

            // We recommend storing your keys in environment variables instead---it's safer!
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
            var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

            using var client = new ClientBuilder(new BasicAuthCredentials(authId, authToken)).BuildUsEnrichmentApiClient();

            // Step 1: business summary SEARCH by address freeform + business name (no smartyKey).
            var lookup = new SmartyStreets.USEnrichmentApi.Business.Summary.Lookup();
            lookup.SetFreeform("3214 N University Ave, Provo, UT");
            lookup.SetBusinessName("Smarty");
            lookup.SetCity("Provo");

            SmartyStreets.USEnrichmentApi.Business.Summary.Result[] summaryResults = null;
            try
            {
                summaryResults = client.SendBusinessLookup(lookup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return;
            }

            if (summaryResults == null || summaryResults.Length == 0)
            {
                Console.WriteLine("No response returned for business name search");
                return;
            }

            var summary = summaryResults[0];
            if (summary.Businesses == null || summary.Businesses.Length == 0)
            {
                Console.WriteLine("No matching businesses found");
                return;
            }

            Console.WriteLine("Matching businesses:");
            foreach (var biz in summary.Businesses)
            {
                Console.WriteLine($"  - {biz.CompanyName} (ID: {biz.BusinessId})");
            }

            // Step 2: take the first match's business ID and look up its details.
            var first = summary.Businesses[0];
            Console.WriteLine($"\nFetching details for business: {first.CompanyName} (ID: {first.BusinessId})");

            SmartyStreets.USEnrichmentApi.Business.Detail.Result detailResult = null;
            try
            {
                detailResult = client.SendBusinessDetailLookup(first.BusinessId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return;
            }

            if (detailResult != null)
            {
                Console.WriteLine("\nDetail result:");
                PrintResult(detailResult);
            }
            else
            {
                Console.WriteLine("\nNo detail result returned");
            }
        }

        private static void PrintResult(object obj)
        {
            Type type = obj.GetType();

            foreach (PropertyInfo property in type.GetProperties())
            {
                var value = property.GetValue(obj, null);
                if (value == null)
                    continue;
                if (property.Name == "Attributes")
                {
                    PrintResult(value);
                    continue;
                }
                Console.WriteLine($"{property.Name}: {value}");
            }
            Console.WriteLine();
        }
    }
}
