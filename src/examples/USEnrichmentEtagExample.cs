namespace Examples
{
    using System;
    using SmartyStreets;
    using SummaryLookup = SmartyStreets.USEnrichmentApi.Business.Summary.Lookup;
    using SummaryResult = SmartyStreets.USEnrichmentApi.Business.Summary.Result;
    using DetailLookup = SmartyStreets.USEnrichmentApi.Business.Detail.Lookup;
    using EnrichmentClient = SmartyStreets.USEnrichmentApi.Client;

    internal static class USEnrichmentEtagExample
    {
        public static void Run()
        {
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
            var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

            using var client = new ClientBuilder(new BasicAuthCredentials(authId, authToken)).BuildUsEnrichmentApiClient();

            const string smartyKey = "1962995076";

            var businessId = ExerciseSummaryEtag(client, smartyKey);
            if (businessId == null)
                return;

            ExerciseDetailEtag(client, businessId);
        }

        private static string ExerciseSummaryEtag(EnrichmentClient client, string smartyKey)
        {
            Console.WriteLine("=== Business.Summary ETag round trip ===");

            var first = new SummaryLookup(smartyKey);
            try { client.SendBusinessLookup(first); }
            catch (Exception ex) { Console.WriteLine("  Initial Summary call failed: " + ex.Message); return null; }

            var initialResults = first.GetResults();
            var capturedEtag = first.GetResponseEtag();
            Console.WriteLine($"  Call 1 (no Etag): captured Etag={Display(capturedEtag)}, results={initialResults?.Length ?? 0}");

            if (string.IsNullOrEmpty(capturedEtag))
            {
                Console.WriteLine("  Server did not return an Etag header; skipping conditional calls.");
                return FirstBusinessId(initialResults);
            }

            var second = new SummaryLookup(smartyKey);
            second.SetRequestEtag(capturedEtag);
            try
            {
                client.SendBusinessLookup(second);
                Console.WriteLine($"  Call 2 (matching Etag): 200 — server did NOT honor the conditional. Results={second.GetResults()?.Length ?? 0}, Etag={Display(second.GetResponseEtag())}");
            }
            catch (NotModifiedException ex)
            {
                Console.WriteLine($"  Call 2 (matching Etag): 304 NotModifiedException — caller treats this as cache-valid. Refreshed Etag={Display(ex.ResponseEtag)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Call 2 unexpected failure: " + ex.GetType().Name + ": " + ex.Message);
                return null;
            }

            var third = new SummaryLookup(smartyKey);
            third.SetRequestEtag(capturedEtag + "X");
            try
            {
                client.SendBusinessLookup(third);
                Console.WriteLine($"  Call 3 (mutated Etag): 200 as expected. Results={third.GetResults()?.Length ?? 0}, Etag={Display(third.GetResponseEtag())}");
            }
            catch (NotModifiedException)
            {
                Console.WriteLine("  Call 3 (mutated Etag): 304 — UNEXPECTED. Server treated a different Etag as matching.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Call 3 unexpected failure: " + ex.GetType().Name + ": " + ex.Message);
            }

            return FirstBusinessId(initialResults);
        }

        private static void ExerciseDetailEtag(EnrichmentClient client, string businessId)
        {
            Console.WriteLine();
            Console.WriteLine($"=== Business.Detail ETag round trip (businessId: {businessId}) ===");

            var first = new DetailLookup(businessId);
            try { client.SendBusinessDetailLookup(first); }
            catch (Exception ex) { Console.WriteLine("  Initial Detail call failed: " + ex.Message); return; }

            var initial = first.GetResult();
            var capturedEtag = first.GetResponseEtag();
            Console.WriteLine($"  Call 1 (no Etag): captured Etag={Display(capturedEtag)}, businessId={initial?.BusinessId ?? "<null>"}");

            if (string.IsNullOrEmpty(capturedEtag))
            {
                Console.WriteLine("  Server did not return an Etag header; skipping conditional calls.");
                return;
            }

            var second = new DetailLookup(businessId);
            second.SetRequestEtag(capturedEtag);
            try
            {
                client.SendBusinessDetailLookup(second);
                Console.WriteLine($"  Call 2 (matching Etag): 200 — server did NOT honor the conditional. businessId={second.GetResult()?.BusinessId ?? "<null>"}, Etag={Display(second.GetResponseEtag())}");
            }
            catch (NotModifiedException ex)
            {
                Console.WriteLine($"  Call 2 (matching Etag): 304 NotModifiedException — caller treats this as cache-valid. Refreshed Etag={Display(ex.ResponseEtag)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Call 2 unexpected failure: " + ex.GetType().Name + ": " + ex.Message);
                return;
            }

            var third = new DetailLookup(businessId);
            third.SetRequestEtag(capturedEtag + "X");
            try
            {
                client.SendBusinessDetailLookup(third);
                Console.WriteLine($"  Call 3 (mutated Etag): 200 as expected. businessId={third.GetResult()?.BusinessId ?? "<null>"}, Etag={Display(third.GetResponseEtag())}");
            }
            catch (NotModifiedException)
            {
                Console.WriteLine("  Call 3 (mutated Etag): 304 — UNEXPECTED. Server treated a different Etag as matching.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("  Call 3 unexpected failure: " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static string FirstBusinessId(SummaryResult[] results)
        {
            if (results == null || results.Length == 0) return null;
            var businesses = results[0].Businesses;
            if (businesses == null || businesses.Length == 0) return null;
            return businesses[0].BusinessId;
        }

        private static string Display(string s) => string.IsNullOrEmpty(s) ? "<none>" : s;
    }
}
