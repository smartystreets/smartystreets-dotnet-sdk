using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartyStreets
{
    public class CustomHeaderSender : ISender
    {
        private bool senderWasDisposed;
        private readonly Dictionary<string, string> headers;
        private readonly Dictionary<string, AppendedHeader> appendHeaders;
        private readonly ISender inner;

        public CustomHeaderSender(Dictionary<string, string> headers, ISender inner)
            : this(headers, null, inner)
        {
        }

        public CustomHeaderSender(Dictionary<string, string> headers, Dictionary<string, AppendedHeader> appendHeaders, ISender inner)
        {
            this.headers = headers;
            this.appendHeaders = appendHeaders ?? new Dictionary<string, AppendedHeader>();
            this.inner = inner;
        }

        public Response Send(Request request)
        {
            return SendAsync(request).GetAwaiter().GetResult();
        }

        public async Task<Response> SendAsync(Request request)
        {
            foreach (var entry in this.headers)
                request.SetHeader(entry.Key, entry.Value);

            foreach (var entry in this.appendHeaders)
            {
                if (request.Headers.TryGetValue(entry.Key, out var existing))
                    request.SetHeader(entry.Key, existing + entry.Value.Separator + entry.Value.Value);
                else
                    request.SetHeader(entry.Key, entry.Value.Value);
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