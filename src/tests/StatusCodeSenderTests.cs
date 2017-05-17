namespace SmartyStreets
{
	using NUnit.Framework;

	[TestFixture]
	public class StatusCodeSenderTests
	{
		[Test]
		public void TestThrowsOnNon200Reponse()
		{
			Assert.DoesNotThrow(() => Send(200));

			Assert.Throws<BadCredentialsException>(() => Send(401));
			Assert.Throws<PaymentRequiredException>(() => Send(402));
			Assert.Throws<RequestEntityTooLargeException>(() => Send(413));
			Assert.Throws<BadRequestException>(() => Send(400));
			Assert.Throws<TooManyRequestsException>(() => Send(429));
			Assert.Throws<InternalServerErrorException>(() => Send(500));
			Assert.Throws<ServiceUnavailableException>(() => Send(503));
		}

		private static void Send(int statusCode)
		{
			var inner = new MockStatusCodeSender(statusCode);
			var sender = new StatusCodeSender(inner);
			sender.Send(new Request());
		}
	}
}