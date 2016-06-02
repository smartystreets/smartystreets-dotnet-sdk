using System;
using System.Net;

namespace SmartyStreets
{
	public interface ISender
	{
		Response Send(Request request);
	}
}