using System;

namespace SmartyStreets
{
	public class RequestCapturingSender : ISender
	{
		public Request Request { get; private set; }

		public RequestCapturingSender()
		{
		}

		public Response Send(Request request)
		{
			this.Request = request;

			return new Response(200, new byte[0]);
		}
	}
}

