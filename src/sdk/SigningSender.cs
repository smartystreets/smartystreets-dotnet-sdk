namespace SmartyStreets
{
    using System.Threading.Tasks;

    public class SigningSender : ISender
	{
		private readonly ICredentials signer;
		private readonly ISender inner;

		public SigningSender(ICredentials signer, ISender inner)
		{
			this.signer = signer;
			this.inner = inner;
		}

		public Response Send(Request request)
		{
			this.signer.Sign(request);
			return this.inner.Send(request);
		}

	    public Task<Response> SendAsync(Request request)
	    {
            this.signer.Sign(request);
            return this.inner.SendAsync(request);
        }
	}
}