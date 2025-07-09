using System.Threading.Tasks;

namespace SmartyStreets
{
	public class SigningSender : ISender
	{
		private bool senderWasDisposed; 
		private readonly ICredentials signer;
		private readonly ISender inner;

		public SigningSender(ICredentials signer, ISender inner)
		{
			this.signer = signer;
			this.inner = inner;
		}

		public async Task<Response> Send(Request request)
		{
			this.signer.Sign(request);
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