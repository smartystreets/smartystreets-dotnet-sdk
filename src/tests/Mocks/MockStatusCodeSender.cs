namespace SmartyStreets
{
	public class MockStatusCodeSender : ISender
	{
		private readonly int statusCode;

		public MockStatusCodeSender(int statusCode)
		{
			this.statusCode = statusCode;
		}

		public Response Send(Request request)
		{
			if (this.statusCode == 0)
				return null;

			return new Response(this.statusCode, null);
		}
	}
}