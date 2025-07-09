using System.Threading.Tasks;

namespace SmartyStreets
{
	public class URLPrefixSender : ISender
	{
		private bool senderWasDisposed; 
		private readonly string urlPrefix;
		private readonly ISender inner;

		public URLPrefixSender(string urlPrefix, ISender inner)
		{
			this.urlPrefix = urlPrefix;
			this.inner = inner;
		}

		public async Task<Response> Send(Request request)
		{
			request.SetUrlPrefix(this.urlPrefix);
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
			this.inner.EnableLogging();
		}
	}
}