using System.Threading.Tasks;

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

		public async Task<Response> SendAsync(Request request)
		{
			request.SetUrlPrefix(this.urlPrefix);
			return await this.inner.SendAsync(request);
		}
	}
}