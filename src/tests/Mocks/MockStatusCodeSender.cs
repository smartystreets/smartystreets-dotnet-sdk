namespace SmartyStreets
{
	using System.Threading.Tasks;

	public class MockStatusCodeSender : ISender
	{
		private readonly int statusCode;

		public MockStatusCodeSender(int statusCode)
		{
			this.statusCode = statusCode;
		}

		public async Task<Response> Send(Request request)
		{
			// await something so that this function signature matches the ISender.Send signature
			await Task.Delay(1); 

			if (this.statusCode == 0)
				return null;

			return new Response(this.statusCode, null);
		}

		public void Dispose()
		{
			
		}
	}
}