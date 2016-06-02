using System;

namespace SmartyStreets
{
	public class RetrySender : ISender
	{
		private int maxRetries;
		private ISender inner;

		public RetrySender(int maxRetries, ISender inner)
		{
			this.maxRetries = maxRetries;
			this.inner = inner;
		}

		public Response Send(Request request)
		{
			for (int i = 0; i <= this.maxRetries; i++) 
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
			catch (Exception ex)
			{
				if (attempt >= this.maxRetries)
					throw ex;
			}
			return null;
		}
	}
}

