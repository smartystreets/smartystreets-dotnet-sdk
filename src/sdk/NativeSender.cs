namespace SmartyStreets
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text;
    using System.Threading.Tasks;

    public class NativeSender : ISender
    {
        private HttpClient client = new HttpClient();

        public NativeSender()
        {
        }

        public NativeSender(TimeSpan timeout, Proxy proxy = null)
        {
            
        }

        public async Task<Response> Send(Request request)
        {
            foreach (var item in request.Headers)
            {
                if (item.Key == "Referer")
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
                else
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }

            var payload = new byte[] { };
            HttpResponseMessage response; 

            HttpRequestMessage httpRqeuest = new HttpRequestMessage(HttpMethod.Post, request.GetUrl());
            httpRqeuest.Content = new StreamContent(new MemoryStream(request.Payload));

            response = await client.SendAsync(httpRqeuest);

            var statusCode = (int) response.StatusCode;

            payload = await response.Content.ReadAsByteArrayAsync();

            return new Response(200, payload);
        }

        private string BuildRequestURI(Request request)
        {
            return null;
        }

        private int GetResponseHeader(HttpResponseMessage response)
        {
            return 0;
        }
        
         private byte[] GetResponseBody(HttpResponseMessage response) {
            return null; 
        }



	}
}