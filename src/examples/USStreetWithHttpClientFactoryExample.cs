namespace Examples
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using SmartyStreets;
    using SmartyStreets.USStreetApi;

    /// <summary>
    ///     Demonstrates the recommended enterprise integration pattern: resolve an
    ///     <see cref="HttpClient"/> from <c>IHttpClientFactory</c> (avoiding socket
    ///     exhaustion and stale DNS), attach a <see cref="DelegatingHandler"/> for
    ///     cross-cutting concerns (logging, tracing, Polly policies, corporate proxy
    ///     auth, etc.), and hand the configured client to <c>ClientBuilder.WithHttpClient</c>.
    ///
    ///     Notes for enterprise integrators:
    ///       - RetryAtMost(0): if the injected handler pipeline owns retries (e.g. a
    ///         Polly policy registered via AddPolicyHandler), disable the SDK's retry
    ///         layer to avoid compounded retries (SDK 5x * Polly Nx).
    ///       - Timeout &amp; proxy: configure these on the injected HttpClient /
    ///         HttpClientHandler; WithMaxTimeout and ViaProxy are rejected when an
    ///         HttpClient is supplied.
    ///       - Disposal: the SDK will not dispose a caller-owned HttpClient.
    /// </summary>
    internal static class USStreetWithHttpClientFactoryExample
    {
        private const string SmartyClientName = "smarty";

        public static void Run()
        {
            var authId = Environment.GetEnvironmentVariable("SMARTY_AUTH_ID");
            var authToken = Environment.GetEnvironmentVariable("SMARTY_AUTH_TOKEN");

            var services = new ServiceCollection();

            services.AddTransient<CorrelationIdHandler>();
            services.AddHttpClient(SmartyClientName)
                .AddHttpMessageHandler<CorrelationIdHandler>();
            // In a real app you'd also add a Polly retry policy here, e.g.:
            //   .AddPolicyHandler(HttpPolicyExtensions.HandleTransientHttpError()
            //       .WaitAndRetryAsync(3, attempt => TimeSpan.FromMilliseconds(200 * attempt)));
            // When you do, call RetryAtMost(0) below to prevent compounded retries.

            using var provider = services.BuildServiceProvider();
            var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient(SmartyClientName);

            using var client = new ClientBuilder(authId, authToken)
                .WithHttpClient(httpClient)
                .RetryAtMost(0) // Polly (or the injected pipeline) owns retries in this setup.
                .BuildUsStreetApiClient();

            var lookup = new Lookup
            {
                Street = "1600 Amphitheatre Pkwy",
                City = "Mountain View",
                State = "CA",
                MaxCandidates = 1,
                MatchStrategy = Lookup.ENHANCED
            };

            try
            {
                client.Send(lookup);
            }
            catch (SmartyException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (lookup.Result.Count == 0)
            {
                Console.WriteLine("No candidates returned.");
                return;
            }

            var first = lookup.Result[0];
            Console.WriteLine("ZIP Code: " + first.Components.ZipCode);
            Console.WriteLine("County:   " + first.Metadata.CountyName);
        }

        private sealed class CorrelationIdHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                request.Headers.TryAddWithoutValidation(
                    "X-Correlation-Id", Guid.NewGuid().ToString("N"));
                return base.SendAsync(request, cancellationToken);
            }
        }
    }
}
