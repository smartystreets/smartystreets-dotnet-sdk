﻿namespace SmartyStreets
{
    using System.Threading.Tasks;
	public class MockSender : ISender
	{
		private readonly Response response;
		public Request Request { get; private set; }

		public MockSender(Response response)
		{
			this.response = response;
		}

		public Response Send(Request request)
		{
			return SendAsync(request).GetAwaiter().GetResult();
		}

		public async Task<Response> SendAsync(Request request)
		{
			await Task.Delay(1); // Simulate minimal async delay
			this.Request = request;
			return this.response;
		}

		public void Dispose()
		{
			
		}
		
		public void EnableLogging()
		{
			
		}
	}
}