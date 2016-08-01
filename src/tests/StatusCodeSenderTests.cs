namespace SmartyStreets
{
	using NUnit.Framework;

	[TestFixture]
	public class StatusCodeSenderTests
	{
		[Test]
		public void Test200Response()
		{
			var sender = new StatusCodeSender(new MockStatusCodeSender(200));

			var response = sender.Send(new Request());

			Assert.AreEqual(200, response.StatusCode);
		}

		[Test]
		public void Test401ResponseThrowsBadCredentialsException()
		{
			Assert.Throws<BadCredentialsException>(() => AssertSend(401));
		}

		[Test]
		public void Test402ResponsePThrowsPaymentRequiredException()
		{
			Assert.Throws<PaymentRequiredException>(() => AssertSend(402));
		}

		[Test]
		public void Test413ResponseThrowsRequestEntityTooLargeException()
		{
			Assert.Throws<RequestEntityTooLargeException>(() => AssertSend(413));
		}

		[Test]
		public void Test400ResponseThrowsBadRequestException()
		{
			Assert.Throws<BadRequestException>(() => AssertSend(400));
		}

		[Test]
		public void Test429ResponseThrowsTooManyRequestsException()
		{
			Assert.Throws<TooManyRequestsException>(() => AssertSend(429));
		}

		[Test]
		public void Test500ResponseThrowsInternalServerErrorException()
		{
			Assert.Throws<InternalServerErrorException>(() => AssertSend(500));
		}

		[Test]
		public void Test503ResponseThrowsServiceUnavailableException()
		{
			Assert.Throws<ServiceUnavailableException>(() => AssertSend(503));
		}

		private static void AssertSend(int statusCode)
		{
			var sender = new StatusCodeSender(new MockStatusCodeSender(statusCode));
			sender.Send(new Request());
		}
	}
}