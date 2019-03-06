using System.Threading.Tasks;

namespace SmartyStreets
{
	public class RequestCapturingSender : ISender
	{
		public Request Request { get; private set; }

		public async Task<Response> SendAsync(Request request)
		{
			this.Request = request;

			return new Response(200, new byte[0]);
		}
	}
}