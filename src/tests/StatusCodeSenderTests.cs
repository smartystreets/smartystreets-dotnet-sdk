namespace SmartyStreets
{
	using NUnit.Framework;
    using System.Threading.Tasks;

    [TestFixture]
	public class StatusCodeSenderTests
	{
		[Test]
		public void TestThrowsOnNon200Reponse()
		{
			Assert.DoesNotThrowAsync(async () => await SendAsync(200));

			Assert.ThrowsAsync<BadCredentialsException>(async () => await SendAsync(401));
			Assert.ThrowsAsync<PaymentRequiredException>(async () => await SendAsync(402));
			Assert.ThrowsAsync<RequestEntityTooLargeException>(async () => await SendAsync(413));
			Assert.ThrowsAsync<BadRequestException>(async () => await SendAsync(400));
			Assert.ThrowsAsync<TooManyRequestsException>(async () => await SendAsync(429));
			Assert.ThrowsAsync<InternalServerErrorException>(async () => await SendAsync(500));
			Assert.ThrowsAsync<ServiceUnavailableException>(async () => await SendAsync(503));
		}

		private static async Task SendAsync(int statusCode)
		{
			var inner = new MockStatusCodeSender(statusCode);
			var sender = new StatusCodeSender(inner);
			await sender.SendAsync(new Request());
		}
	}
}