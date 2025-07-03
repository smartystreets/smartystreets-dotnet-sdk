namespace SmartyStreets
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
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
            HttpResponseMessage response = await client.GetAsync(request.GetUrl());

            // var statusCode = GetResponseHeader(response);
            // var payload = GetResponseBody(response);
            // var retVal = new Response(statusCode, payload);
            // return retVal;

            Console.WriteLine(response.ToString());
            return new Response(200, new Byte[64]);

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