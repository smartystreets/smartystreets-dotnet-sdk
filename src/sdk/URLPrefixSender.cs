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
			if (request.GetUrlPrefix() != null) {
				request.SetUrlPrefix(this.urlPrefix + request.GetUrlPrefix());
			} else {
				request.SetUrlPrefix(this.urlPrefix);
			}
			return this.inner.Send(request);
		}
	}
}