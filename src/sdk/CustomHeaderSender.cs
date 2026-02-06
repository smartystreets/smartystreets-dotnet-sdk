using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartyStreets
{
    public class CustomHeaderSender : ISender
    {
        private bool senderWasDisposed;
        private readonly Dictionary<string, string> headers;
        private readonly Dictionary<string, string> appendHeaders;
        private readonly ISender inner;

        public CustomHeaderSender(Dictionary<string, string> headers, ISender inner)
            : this(headers, null, inner)
        {
        }

        public CustomHeaderSender(Dictionary<string, string> headers, Dictionary<string, string> appendHeaders, ISender inner)
        {
            this.headers = headers;
            this.appendHeaders = appendHeaders ?? new Dictionary<string, string>();
            this.inner = inner;
        }

        public Response Send(Request request)
        {
            return SendAsync(request).GetAwaiter().GetResult();
        }

        public async Task<Response> SendAsync(Request request)
        {
            foreach (var entry in this.headers)
            {
                if (this.appendHeaders.TryGetValue(entry.Key, out var separator))
                {
                    if (request.Headers.TryGetValue(entry.Key, out var existing))
                        request.SetHeader(entry.Key, existing + separator + entry.Value);
                    else
                        request.SetHeader(entry.Key, entry.Value);
                }
                else
                {
                    request.SetHeader(entry.Key, entry.Value);
                }
            }

            return await this.inner.SendAsync(request);
        }

        public void Dispose()
        {
            if (!senderWasDisposed)
            {
                this.inner.Dispose();
                this.senderWasDisposed = true;
            }
        }

        public void EnableLogging()
        {
            this.inner.EnableLogging();
        }
    }
}