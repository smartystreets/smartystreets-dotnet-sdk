namespace SmartyStreets
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class NativeSender : ISender
    {
        private static readonly Version AssemblyVersion = typeof(NativeSender).Assembly.GetName().Version;
        private static readonly string UserAgent = string.Format("smartystreets (sdk:dotnet@{0}.{1}.{2})",
            AssemblyVersion.Major, AssemblyVersion.Minor, AssemblyVersion.Build);
        private HttpClient client;
        private readonly bool ownsClient;

        private bool logHttpRequestAndResponse;

        public NativeSender()
        {
            client = new HttpClient();
            ownsClient = true;

            client.Timeout = TimeSpan.FromSeconds(10);
            client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
        }

        public NativeSender(TimeSpan timeout, Proxy proxy = null)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.Proxy = (proxy ?? new Proxy()).NativeProxy;

            client = new HttpClient(httpClientHandler);
            ownsClient = true;
            client.Timeout = timeout;
            client.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
        }

        /// <summary>
        ///     Wraps an externally-managed <see cref="HttpClient"/> (e.g. one resolved from
        ///     <c>IHttpClientFactory</c>). The sender will not dispose the client, and will
        ///     not modify its <c>Timeout</c> or <c>DefaultRequestHeaders</c>; attach
        ///     <see cref="DelegatingHandler"/>s or configure the client externally instead.
        ///     The SDK User-Agent is added per-request, unless the caller has already set one
        ///     on the client's default headers.
        /// </summary>
        /// <param name="client">An HttpClient whose lifecycle is managed by the caller.</param>
        public NativeSender(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.ownsClient = false;
        }

        public Response Send(Request request)
        {
            return SendAsync(request).GetAwaiter().GetResult();
        }

        public async Task<Response> SendAsync(Request request)
        {
            HttpRequestMessage httpRequest;
            if (request.Payload != null)
            {
                // POST request with payload
                httpRequest = new HttpRequestMessage(HttpMethod.Post, request.GetUrl());
                httpRequest.Content = new StreamContent(new MemoryStream(request.Payload));
            }
            else
            {
                // GET request
                httpRequest = new HttpRequestMessage(HttpMethod.Get, request.GetUrl());
            }

            // Copy headers to the request (not DefaultRequestHeaders to avoid persistence issues)
            foreach (var item in request.Headers)
            {
                if (item.Key == "Referer")
                {
                    httpRequest.Headers.Referrer = new Uri(item.Value);
                }
                else
                {
                    httpRequest.Headers.Add(item.Key, item.Value);
                }
            }

            // For injected clients we don't mutate DefaultRequestHeaders; set UA per-request
            // unless the caller has already configured one on the client.
            if (!ownsClient && !client.DefaultRequestHeaders.UserAgent.Any())
            {
                httpRequest.Headers.UserAgent.ParseAdd(UserAgent);
            }

            HttpResponseMessage response = await client.SendAsync(httpRequest);

            if (this.logHttpRequestAndResponse)
            {
                await PrintRequestAndResponse(response);
            }
            
            var statusCode = (int)response.StatusCode;
            var payload = await response.Content.ReadAsByteArrayAsync();

            var retVal = new Response(statusCode, payload);
            // retrieve the etag header for enrichment api 
            string headerValue = GetHeaderValue(response, "Etag");
            if (headerValue != "")
            {
                retVal.HeaderInfo.Add("Etag", headerValue);
            }

            if (statusCode == 429)
            {
                string retryValue = GetHeaderValue(response, "Retry-After");
                if (!string.IsNullOrEmpty(retryValue))
                {
                    retVal.HeaderInfo.Add("Retry-After", retryValue);
                }
            }

            return retVal;
        }

        private static string GetHeaderValue(HttpResponseMessage response, string headerName)
        {
            string headerValue = string.Empty;
            if (response.Headers.TryGetValues(headerName, out IEnumerable<string> values))
            {
                headerValue = values.FirstOrDefault();
            }
            return headerValue;
        }

        public void EnableLogging()
        {
            this.logHttpRequestAndResponse = true;
        }

        public void Dispose()
        {
            if (this.client != null && this.ownsClient)
            {
                this.client.Dispose();
            }
            this.client = null;
        }

        private async Task PrintRequestAndResponse(HttpResponseMessage response)
        {
            Console.WriteLine("HTTP Request: ");
            var request = response.RequestMessage;
            Console.WriteLine($"Method: {request.Method}");
            Console.WriteLine($"Request URI: {request.RequestUri}");
            Console.WriteLine("Headers: ");
            foreach (var header in request.Headers)
            {
                Console.WriteLine($"  {header.Key}: {string.Join(", ", header.Value)}");
            }
            Console.WriteLine("Content: ");
            var requestContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(requestContent);
            Console.WriteLine();
            Console.WriteLine("HTTP Response: ");
            Console.WriteLine($"Status: {response.StatusCode} - {response.ReasonPhrase}");
            Console.WriteLine("Headers:");
            foreach (var header in response.Headers)
            {
                Console.WriteLine($"  {header.Key}: {string.Join(", ", header.Value)}");
            }
            foreach (var header in response.Content.Headers)
            {
                Console.WriteLine($"  {header.Key}: {string.Join(", ", header.Value)}");
            }
            Console.WriteLine("Content: ");
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.Write(responseContent);
            Console.WriteLine();
        }
    }
}