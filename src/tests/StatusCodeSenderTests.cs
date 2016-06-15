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
		[ExpectedException(typeof(BadCredentialsException))]
		public void Test401ResponseThrowsBadCredentialsException()
		{
			AssertSend(401);
		}

		[Test]
		[ExpectedException(typeof(PaymentRequiredException))]
		public void Test402ResponsePThrowsPaymentRequiredException()
		{
			AssertSend(402);
		}

		[Test]
		[ExpectedException(typeof(RequestEntityTooLargeException))]
		public void Test413ResponseThrowsRequestEntityTooLargeException()
		{
			AssertSend(413);
		}

		[Test]
		[ExpectedException(typeof(BadRequestException))]
		public void Test400ResponseThrowsBadRequestException()
		{
			AssertSend(400);
		}

		[Test]
		[ExpectedException(typeof(TooManyRequestsException))]
		public void Test429ResponseThrowsTooManyRequestsException()
		{
			AssertSend(429);
		}

		[Test]
		[ExpectedException(typeof(InternalServerErrorException))]
		public void Test500ResponseThrowsInternalServerErrorException()
		{
			AssertSend(500);
		}

		[Test]
		[ExpectedException(typeof(ServiceUnavailableException))]
		public void Test503ResponseThrowsServiceUnavailableException()
		{
			AssertSend(503);
		}

		private static void AssertSend(int statusCode)
		{
			var sender = new StatusCodeSender(new MockStatusCodeSender(statusCode));
			sender.Send(new Request());
		}
	}
}