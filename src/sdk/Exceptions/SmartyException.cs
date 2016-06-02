using System;

namespace SmartyStreets
{
	public class SmartyException : Exception
	{
		public SmartyException()
		{
		}

		public SmartyException(string message) : base(message)
		{
		}
	}
}

