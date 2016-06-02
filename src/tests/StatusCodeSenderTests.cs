using System;
using NUnit.Framework;

namespace SmartyStreets
{
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
			this.AssertSend(401);
		}

		[Test]
		[ExpectedException(typeof(PaymentRequiredException))]
		public void Test402ResponsePThrowsPaymentRequiredException() {
			this.AssertSend(402);
		}

		[Test]
		[ExpectedException(typeof(RequestEntityTooLargeException))]
		public void Test413ResponseThrowsRequestEntityTooLargeException() {
			this.AssertSend(413);
		}

		[Test]
		[ExpectedException(typeof(BadRequestException))]
		public void Test400ResponseThrowsBadRequestException() {
			this.AssertSend(400);
		}

		[Test]
		[ExpectedException(typeof(TooManyRequestsException))]
		public void Test429ResponseThrowsTooManyRequestsException() {
			this.AssertSend(429);
		}

		[Test]
		[ExpectedException(typeof(InternalServerErrorException))]
		public void Test500ResponseThrowsInternalServerErrorException() {
			this.AssertSend(500);
		}

		[Test]
		[ExpectedException(typeof(ServiceUnavailableException))]
		public void Test503ResponseThrowsServiceUnavailableException() {
			this.AssertSend(503);
		}

		private void AssertSend(int statusCode)
		{
			StatusCodeSender sender = new StatusCodeSender(new MockStatusCodeSender(statusCode));

			sender.Send(new Request());
		}
	}
}

