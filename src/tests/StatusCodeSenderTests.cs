using System.Threading.Tasks;

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

        [Test]
        public async Task Test200ResponseAsync()
        {
            var sender = new StatusCodeSender(new MockStatusCodeSender(200));

            var response = await sender.SendAsync(new Request());

            Assert.AreEqual(200, response.StatusCode);
        }

        [Test]
        public async Task Test401ResponseThrowsBadCredentialsExceptionAsync()
        {
            Assert.Throws<BadCredentialsException>(async () =>await AssertSendAsync(401));
        }

        [Test]
        public async Task Test402ResponsePThrowsPaymentRequiredExceptionAsync()
        {
            Assert.Throws<PaymentRequiredException>(async () => await AssertSendAsync(402));
        }

        [Test]
        public async Task Test413ResponseThrowsRequestEntityTooLargeExceptionAsync()
        {
            Assert.Throws<RequestEntityTooLargeException>(async () => await AssertSendAsync(413));
        }

        [Test]
        public async Task Test400ResponseThrowsBadRequestExceptionAsync()
        {
            Assert.Throws<BadRequestException>(async () => await AssertSendAsync(400));
        }

        [Test]
        public async Task Test429ResponseThrowsTooManyRequestsExceptionAsync()
        {
            Assert.Throws<TooManyRequestsException>(async () => await AssertSendAsync(429));
        }

        [Test]
        public async Task Test500ResponseThrowsInternalServerErrorExceptionAsync()
        {
            Assert.Throws<InternalServerErrorException>(async () => await AssertSendAsync(500));
        }

        [Test]
        public async Task Test503ResponseThrowsServiceUnavailableExceptionAsync()
        {
            Assert.Throws<ServiceUnavailableException>(async () => await AssertSendAsync(503));
        }
        private static void AssertSend(int statusCode)
		{
			var sender = new StatusCodeSender(new MockStatusCodeSender(statusCode));
			sender.Send(new Request());
        }
        private static Task AssertSendAsync(int statusCode)
        {
            var sender = new StatusCodeSender(new MockStatusCodeSender(statusCode));
            return sender.SendAsync(new Request());
        }
    }
}