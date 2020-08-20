using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartyStreets
{
    public class LicenseSender : ISender
    {
        private readonly List<string> licenses;
        private readonly ISender inner;

        public LicenseSender(List<string> licenses, ISender inner)
        {
            this.licenses = licenses;
            this.inner = inner;
        }

        public Response Send(Request request)
        {
            request.SetParameter("license", String.Join(",", this.licenses));
            return this.inner.Send(request);
        }
    }
}