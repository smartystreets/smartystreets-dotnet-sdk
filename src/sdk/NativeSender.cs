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
        private HttpClient client;

        public NativeSender()
        {
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
        }

        public NativeSender(TimeSpan timeout, Proxy proxy = null)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.Proxy = (proxy ?? new Proxy()).NativeProxy;
            client = new HttpClient(httpClientHandler);
            client.Timeout = timeout;
        }

        public NativeSender(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Response> Send(Request request)
        {
            foreach (var item in request.Headers)
            {
                client.DefaultRequestHeaders.Add(item.Key, item.Value);
            }

            HttpResponseMessage response;
            if (request.Payload != null)
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, request.GetUrl());
                httpRequest.Content = new StreamContent(new MemoryStream(request.Payload));
                response = await client.SendAsync(httpRequest);
            }
            else
            {
                response = await client.GetAsync(request.GetUrl());
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
                if ((retryValue != null) && (retryValue.Length != 0))
                {
                    retVal.HeaderInfo.Add("Retry-After", retryValue);
                }
            }

            return retVal;
        }

        private static string GetHeaderValue(HttpResponseMessage response, string headerName)
        {
            IEnumerable<string> values;
            string headerValue = string.Empty;
            if (response.Headers.TryGetValues(headerName, out values))
            {
                headerValue = values.FirstOrDefault();
            }
            return headerValue;
        }
    
	}
}