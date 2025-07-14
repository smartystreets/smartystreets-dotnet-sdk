namespace SmartyStreets
{
	using System.Threading.Tasks;

	public class RequestCapturingSender : ISender
	{
		public Request Request { get; private set; }
		
		public Response Send(Request request)
		{
			return SendAsync(request).GetAwaiter().GetResult();
		}
		
		public async Task<Response> SendAsync(Request request)
		{
			// await something so that this function signature matches the ISender.Send signature
			await Task.Delay(1); 

			this.Request = request;

			return new Response(200, new byte[0]);
		}

		public void Dispose()
		{
			
		}
		
		public void EnableLogging()
		{
			
		}
	}
}