namespace SmartyStreets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LicenseSender : ISender
    {
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
            
        }
    }
}