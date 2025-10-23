namespace SmartyStreets
{
    using System.Threading.Tasks;
    using NUnit.Framework;

	[TestFixture]
	public class StatusCodeSenderTests
	{
		[Test]
		public void TestThrowsOnNon200Reponse()
		{
			Assert.DoesNotThrowAsync(async () => await Send(200));
			Assert.ThrowsAsync<BadCredentialsException>(async () => await Send(401));
			Assert.ThrowsAsync<PaymentRequiredException>(async () => await Send(402));
			Assert.ThrowsAsync<RequestEntityTooLargeException>(async () => await Send(413));
			Assert.ThrowsAsync<BadRequestException>(async () => await Send(400));
			Assert.ThrowsAsync<TooManyRequestsException>(async () => await Send(429));
			Assert.ThrowsAsync<InternalServerErrorException>(async () => await Send(500));
			Assert.ThrowsAsync<ServiceUnavailableException>(async () => await Send(503));
		}

		private static async Task Send(int statusCode)
		{
			var inner = new MockStatusCodeSender(statusCode);
			var sender = new StatusCodeSender(inner);
			await sender.SendAsync(new Request());
		}
	}
}