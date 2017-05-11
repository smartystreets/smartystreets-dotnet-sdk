using System;
using System.Text;

namespace SmartyStreets.USExtractApi
{
    public class Client
    {
        private readonly ISender sender;
        private ISerializer serializer;

        public Client(ISender sender, ISerializer serializer) {
            this.sender = sender;
            this.serializer = serializer;
        }

        public Result Send(Lookup lookup)
        {
            var request = BuildRequest(lookup);
            this.sender.Send(request);

            return new Result();
        }

        private static Request BuildRequest(Lookup lookup)
        {
            var request = new Request
            {
                ContentType = "text/plain",
                Payload = Encoding.ASCII.GetBytes(lookup.Text)
            };

            request.SetParameter("html", lookup.IsHtml());
            request.SetParameter("aggressive", lookup.IsAggressive.ToString().ToLower());
            request.SetParameter("addr_line_breaks", lookup.AddressesHaveLineBreaks.ToString().ToLower());
            request.SetParameter("addr_per_line", lookup.AddressesPerLine.ToString());

            return request;
        }
    }
}