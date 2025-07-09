using System.IO;

namespace SmartyStreets
{
	using System;
    using System.Threading.Tasks;

    public class RetrySender : ISender
    {
	    private bool senderWasDisposed;
		private readonly int maxRetries;
		private readonly ISender inner;
		private Action<int> sleep;
		private readonly IRandomGenerator randomNumGenerator;

		private const int BackOffRateLimit = 5;
		private const int MaxBackOffDuration = 10;

		public RetrySender(int maxRetries, ISender inner, Action<int> sleep, IRandomGenerator generator)
		{
			this.maxRetries = maxRetries;
			this.inner = inner;
			this.sleep = sleep;
			this.randomNumGenerator = generator;
		}

		private bool BackOff(int attempt)
		{
			if (attempt == 0)
			{
				return true;
			}
			if (attempt > this.maxRetries)
			{
				return false;
			}

			var backOffCap = Math.Max(0, Math.Min(MaxBackOffDuration, attempt));
			var backOff = this.randomNumGenerator.Next(backOffCap) * 1000;
			this.sleep(backOff);
			return true;
		}

		public Response Send(Request request)
		{
			return SendAsync(request).GetAwaiter().GetResult();
		}

		public async Task<Response> SendAsync(Request request)
		{
			for (var attempts = 0; BackOff(attempts); attempts++)
			{
				var response = await this.TrySend(request, attempts);
				if (response != null)
					return response;
			}

			return null;
		}

		private async Task<Response> TrySend(Request request, int attempts)
		{
			try
			{
				return await this.inner.SendAsync(request);
			}
			catch (TooManyRequestsException e)
			{
				attempts = 0;
				int sleepDurationInMilliseconds = (int)e.RetryAfterInSeconds*1000;
					if (sleepDurationInMilliseconds == 0)
						sleepDurationInMilliseconds= randomNumGenerator.Next(BackOffRateLimit)*1000;
				this.sleep(sleepDurationInMilliseconds);
			}
			catch (Exception ex) when ((ex is InternalServerErrorException) || (ex is ServiceUnavailableException) || (ex is GatewayTimeoutException) || (ex is RequestTimeoutException) || (ex is BadGatewayException) || (ex is IOException))
			{
				if (attempts >= this.maxRetries)
					throw;
			}
			// all other exceptions are just allowed to be caught by the caller
			return null;
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