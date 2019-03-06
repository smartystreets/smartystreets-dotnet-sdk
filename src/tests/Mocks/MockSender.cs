using System.Threading.Tasks;

namespace SmartyStreets
{
	public class MockSender : ISender
	{
		private readonly Response response;
		public Request Request { get; private set; }

		public MockSender(Response response)
		{
			this.response = response;
		}

		public async Task<Response> SendAsync(Request request)
		{
			this.Request = request;
			return this.response;
		}
	}
}