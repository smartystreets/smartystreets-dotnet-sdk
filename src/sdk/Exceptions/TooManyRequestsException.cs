using System;

namespace SmartyStreets
{
	public class TooManyRequestsException : SmartyException
	{
		public Int64 RetryAfterInSeconds;
		public TooManyRequestsException()
		{
		}

		public TooManyRequestsException(string message)
			: base(message)
		{
		}

		public TooManyRequestsException(string message, Int64 retry)
			: base(message)
		{
			RetryAfterInSeconds = retry;
		}
	}
}