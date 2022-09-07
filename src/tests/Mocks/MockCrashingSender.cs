namespace SmartyStreets
{
	using System.IO;

	public class MockCrashingSender : ISender
	{
		private const int StatusCode = 200;
		public const string DoNotRetry = "Do Not Retry";
		public const string RetryThreeTimes = "Retry Three Times";
		public const string RetryMaxTimes = "Retry Max Times";
		public const string TooManyRequests = "Too Many Requests";
		public const string BadRequest = "Bad Request";
		public const string RequestEntityTooLarge = "Request Entity Too Large";
		public const string UnprocessableEntity = "Unprocessable Entity";

		public int SendCount { get; private set; }

		public MockCrashingSender()
		{
			this.SendCount = 0;
		}

		public Response Send(Request request)
		{
			this.SendCount++;

			if (request.GetUrl().Contains(TooManyRequests))
				if (this.SendCount == 1)
					throw new TooManyRequestsException("Too many requests. Sleeping...");
			if (request.GetUrl().Contains(BadRequest))
				if (this.SendCount == 1)
					throw new BadRequestException("Bad Request. Sleeping...");
			if (request.GetUrl().Contains(RequestEntityTooLarge))
				if (this.SendCount == 1)
					throw new RequestEntityTooLargeException("Request Entity Too Large. Sleeping...");
			if (request.GetUrl().Contains(UnprocessableEntity))
				if (this.SendCount == 1)
					throw new UnprocessableEntityException("Unprocessable Entity. Sleeping...");
			if (request.GetUrl().Contains(RetryThreeTimes))
				if (this.SendCount <= 3)
					throw new IOException("You need to retry");

			if (request.GetUrl().Contains(RetryMaxTimes))
				throw new IOException("Retrying won't help");

			return new Response(StatusCode, new byte[] {});
		}
	}
}