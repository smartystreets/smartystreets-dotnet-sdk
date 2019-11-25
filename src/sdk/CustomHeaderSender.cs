using System.Collections.Generic;

namespace SmartyStreets
{
    public class CustomHeaderSender : ISender
    {
        private readonly Dictionary<string, string> headers;
        private readonly ISender inner;

        public CustomHeaderSender(Dictionary<string, string> headers, ISender inner)
        {
            this.headers = headers;
            this.inner = inner;
        }

        public Response Send(Request request)
        {
            foreach (var entry in this.headers)
            {
                request.SetHeader(entry.Key, entry.Value);
            }

            return this.inner.Send(request);
        }
    }
}