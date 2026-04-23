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

		[Test]
		public void TestNotModifiedExceptionCarriesResponseEtag()
		{
			var response = new Response(304, null);
			response.HeaderInfo["Etag"] = "server-refreshed-etag";
			var sender = new StatusCodeSender(new MockSender(response));

			var ex = Assert.Throws<NotModifiedException>(() => sender.Send(new Request()));
			Assert.AreEqual("server-refreshed-etag", ex.ResponseEtag);
		}

		[Test]
		public void TestNotModifiedExceptionResponseEtagIsCaseInsensitive()
		{
			var response = new Response(304, null);
			response.HeaderInfo["ETag"] = "case-insensitive-etag";
			var sender = new StatusCodeSender(new MockSender(response));

			var ex = Assert.Throws<NotModifiedException>(() => sender.Send(new Request()));
			Assert.AreEqual("case-insensitive-etag", ex.ResponseEtag);
		}

		[Test]
		public void TestNotModifiedExceptionResponseEtagNullWhenHeaderAbsent()
		{
			var response = new Response(304, null);
			var sender = new StatusCodeSender(new MockSender(response));

			var ex = Assert.Throws<NotModifiedException>(() => sender.Send(new Request()));
			Assert.IsNull(ex.ResponseEtag);
		}

		private static async Task Send(int statusCode)
		{
			var inner = new MockStatusCodeSender(statusCode);
			var sender = new StatusCodeSender(inner);
			await sender.SendAsync(new Request());
		}
	}
}
