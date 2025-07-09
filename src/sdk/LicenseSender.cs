namespace SmartyStreets
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LicenseSender : ISender
    {
        private bool senderWasDisposed;
        private readonly List<string> licenses;
        private readonly ISender inner;

        public LicenseSender(List<string> licenses, ISender inner)
        {
            this.licenses = licenses;
            this.inner = inner;
        }

        public async Task<Response> Send(Request request)
        {
            request.SetParameter("license", String.Join(",", this.licenses.ToArray()));
            return await this.inner.Send(request);
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
            inner.EnableLogging();
        }
    }
}