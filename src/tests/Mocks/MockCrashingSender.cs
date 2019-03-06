namespace SmartyStreets
{
	using System.IO;
    using System.Threading.Tasks;

    public class MockCrashingSender : ISender
	{
		private const int StatusCode = 200;
		public const string DoNotRetry = "Do Not Retry";
		public const string RetryThreeTimes = "Retry Three Times";
		public const string RetryMaxTimes = "Retry Max Times";

		public int SendCount { get; private set; }

		public MockCrashingSender()
		{
			this.SendCount = 0;
		}

		public async Task<Response> SendAsync(Request request)
		{
			this.SendCount++;

			if (request.GetUrl().Contains(RetryThreeTimes))
				if (this.SendCount <= 3)
					throw new IOException("You need to retry");

			if (request.GetUrl().Contains(RetryMaxTimes))
				throw new IOException("Retrying won't help");

			return new Response(StatusCode, new byte[] {});
		}
	}
}