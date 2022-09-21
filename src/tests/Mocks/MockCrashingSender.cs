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
		public const string RequestTimeout = "Request Timeout";
		public const string BadGateway = "Bad Gateway";
		public const string InternalServer = "Internal Server error";
		public const string ServiceUnavailable = "Service Unavailable";
		public const string GatewayTimeout = "Gateway Timeout";

		public int SendCount { get; private set; }
		
		public int FailCount { get; set; }

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
			
			// These exceptions should be retried until max is hit 
			if (request.GetUrl().Contains(BadGateway))
				if (this.SendCount < this.FailCount)
					throw new BadGatewayException("Bad Gateway. Retrying...");
			if (request.GetUrl().Contains(RequestTimeout))
				if (this.SendCount < this.FailCount)
					throw new RequestTimeoutException("Request Timeout. Retrying...");
			if (request.GetUrl().Contains(InternalServer))
				if (this.SendCount < this.FailCount)
					throw new InternalServerErrorException("Internal Server error. Retrying...");
			if (request.GetUrl().Contains(ServiceUnavailable))
				if (this.SendCount < this.FailCount)
					throw new ServiceUnavailableException("Service Unavailable. Retrying...");
			if (request.GetUrl().Contains(GatewayTimeout))
				if (this.SendCount < this.FailCount)
					throw new GatewayTimeoutException("Gateway Timeout. Retrying...");
			
			if (request.GetUrl().Contains(RetryThreeTimes))
				if (this.SendCount <= 3)
					throw new IOException("You need to retry");

			if (request.GetUrl().Contains(RetryMaxTimes))
				throw new IOException("Retrying won't help");

			return new Response(StatusCode, new byte[] {});
		}
	}
}