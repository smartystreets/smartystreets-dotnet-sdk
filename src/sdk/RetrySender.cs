namespace SmartyStreets
{
	using System;

	public class RetrySender : ISender
	{
		private readonly int maxRetries;
		private readonly ISender inner;
		private Action<int> sleep;

		public RetrySender(int maxRetries, ISender inner, Action<int> sleep)
		{
			this.maxRetries = maxRetries;
			this.inner = inner;
			this.sleep = sleep;
		}

		public Response Send(Request request)
		{
			for (var i = 0; i <= this.maxRetries; i++)
			{
				var response = this.TrySend(request, i);
				if (response != null)
					return response;
			}

			return null;
		}

		private Response TrySend(Request request, int attempt)
		{
			try
			{
				return this.inner.Send(request);
			}
			catch (TooManyRequestsException)
			{
				if (attempt >= this.maxRetries)
					throw;
				this.sleep(5000);
			}
			catch (Exception) // TODO: catch HTTP 400, 413, 422 and just throw.
			{
				if (attempt >= this.maxRetries)
					throw;
			}

			return null;
		}
	}
}