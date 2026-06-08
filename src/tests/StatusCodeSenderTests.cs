namespace SmartyStreets
{
    using System.Text;
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
			Assert.ThrowsAsync<ForbiddenException>(async () => await Send(403));
			Assert.ThrowsAsync<RequestTimeoutException>(async () => await Send(408));
			Assert.ThrowsAsync<RequestEntityTooLargeException>(async () => await Send(413));
			Assert.ThrowsAsync<BadRequestException>(async () => await Send(400));
			Assert.ThrowsAsync<UnprocessableEntityException>(async () => await Send(422));
			Assert.ThrowsAsync<TooManyRequestsException>(async () => await Send(429));
			Assert.ThrowsAsync<InternalServerErrorException>(async () => await Send(500));
			Assert.ThrowsAsync<ServiceUnavailableException>(async () => await Send(503));
		}

		[Test]
		public void TestSurfacesApiErrorMessageOn422()
		{
			var payload = Encoding.UTF8.GetBytes("{\"errors\":[{\"message\":\"Specific error from the API.\"}]}");
			var sender = new StatusCodeSender(new MockSender(new Response(422, payload)));

			var ex = Assert.Throws<UnprocessableEntityException>(() => sender.Send(new Request()));
			Assert.AreEqual("Specific error from the API.", ex.Message);
		}

		[Test]
		public void TestFallsBackToCannedMessageOn422WhenBodyUnusable()
		{
			var payload = Encoding.UTF8.GetBytes("not valid json with no message field");
			var sender = new StatusCodeSender(new MockSender(new Response(422, payload)));

			var ex = Assert.Throws<UnprocessableEntityException>(() => sender.Send(new Request()));
			Assert.AreEqual("GET request lacked required fields.", ex.Message);
		}

		[Test]
		public void TestFallsBackToCannedMessageOn422WhenBodyEmpty()
		{
			var sender = new StatusCodeSender(new MockSender(new Response(422, null)));

			var ex = Assert.Throws<UnprocessableEntityException>(() => sender.Send(new Request()));
			Assert.AreEqual("GET request lacked required fields.", ex.Message);
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
