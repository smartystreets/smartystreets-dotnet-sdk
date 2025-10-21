using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartyStreets
{
    public class CustomQuerySender : ISender
    {
        private bool senderWasDisposed;
        private readonly Dictionary<string, string> queries;
        private readonly ISender inner;

        public CustomQuerySender(Dictionary<string, string> queries, ISender inner)
        {
            this.queries = queries;
            this.inner = inner;
        }

        public Response Send(Request request)
        {
            return SendAsync(request).GetAwaiter().GetResult();
        }

        public async Task<Response> SendAsync(Request request)
        {
            foreach (var query  in this.queries)
            {
                request.SetParameter(query.Key, query.Value);
            }
            return await this.inner.SendAsync(request);
        }

        public void Dispose()
        {
            if (!senderWasDisposed)
            {
                this.senderWasDisposed = true;
                this.inner.Dispose();
            }
        }

        public void EnableLogging()
        {
            this.inner.EnableLogging();
        }
    }
}