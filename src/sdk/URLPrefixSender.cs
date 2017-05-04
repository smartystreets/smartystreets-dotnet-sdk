namespace SmartyStreets
{
    public class URLPrefixSender : ISender
    {
        private readonly string urlPrefix;
        private readonly ISender inner;

        public URLPrefixSender(string urlPrefix, ISender inner)
        {
            this.urlPrefix = urlPrefix;
            this.inner = inner;
        }

        public Response Send(Request request)
        {
            request.SetUrlPrefix(urlPrefix);
            return inner.Send(request);
        }
    }
}