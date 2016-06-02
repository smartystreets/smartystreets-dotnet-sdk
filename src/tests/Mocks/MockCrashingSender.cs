using System;
using System.IO;

namespace SmartyStreets
{
	public class MockCrashingSender : ISender
	{
		private readonly int STATUS_CODE = 200;
		public const string DO_NOT_RETRY = "Do Not Retry";
		public const string RETRY_THREE_TIMES = "Retry Three Times";
		public const string RETRY_MAX_TIMES = "Retry Max Times";
		public int SendCount { get; private set; }

		public MockCrashingSender()
		{
			this.SendCount = 0;

		}

		public Response Send(Request request)
		{
			this.SendCount++;

			if (request.GetUrl().Contains(RETRY_THREE_TIMES))
			{
				if (this.SendCount <= 3)
				{
					throw new IOException("You need to retry");
				}
			}

			if (request.GetUrl().Contains(RETRY_MAX_TIMES))
			{
				throw new IOException("Retrying won't help");
			}

			return new Response(this.STATUS_CODE, new byte[]{ });
		}
	}
}

