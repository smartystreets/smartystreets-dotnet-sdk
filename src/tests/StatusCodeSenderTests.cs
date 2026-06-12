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
			Assert.ThrowsAsync<BadGatewayException>(async () => await Send(502));
			Assert.ThrowsAsync<ServiceUnavailableException>(async () => await Send(503));
			Assert.ThrowsAsync<GatewayTimeoutException>(async () => await Send(504));
			Assert.ThrowsAsync<SmartyException>(async () => await Send(418));
		}

		[Test]
		public void TestFallsBackToStandardMessages()
		{
			AssertFallbackMessage<BadRequestException>(400,
				"Bad Request (Malformed Payload): A GET request lacked a required field or the request body of a POST request contained malformed JSON.");
			AssertFallbackMessage<ForbiddenException>(403,
				"Forbidden: The request contained valid data and was understood by the server, but the server is refusing action.");
			AssertFallbackMessage<TooManyRequestsException>(429,
				"Too Many Requests: The rate limit for your account has been exceeded.");
			AssertFallbackMessage<InternalServerErrorException>(500, "Internal Server Error.");
			AssertFallbackMessage<BadGatewayException>(502, "Bad Gateway error.");
			AssertFallbackMessage<ServiceUnavailableException>(503, "Service Unavailable. Try again later.");
			AssertFallbackMessage<GatewayTimeoutException>(504,
				"The upstream data provider did not respond in a timely fashion and the request failed. A serious, yet rare occurrence indeed.");
			AssertFallbackMessage<SmartyException>(418,
				"The server returned an unexpected HTTP status code: 418");
		}

		[Test]
		public void TestSurfacesApiErrorMessageOn500()
		{
			var payload = Encoding.UTF8.GetBytes("{\"errors\":[{\"message\":\"API broke.\"}]}");
			var sender = new StatusCodeSender(new MockSender(new Response(500, payload)));

			var ex = Assert.Throws<InternalServerErrorException>(() => sender.Send(new Request()));
			Assert.AreEqual("API broke.", ex.Message);
		}

		[Test]
		public void TestSurfacesApiErrorMessageOnUnexpectedStatusCode()
		{
			var payload = Encoding.UTF8.GetBytes("{\"errors\":[{\"message\":\"API teapot message.\"}]}");
			var sender = new StatusCodeSender(new MockSender(new Response(418, payload)));

			var ex = Assert.Throws<SmartyException>(() => sender.Send(new Request()));
			Assert.AreEqual("API teapot message.", ex.Message);
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
		public void TestJoinsMultipleApiErrorMessages()
		{
			var payload = Encoding.UTF8.GetBytes("{\"errors\":[{\"message\":\"First problem.\"},{\"message\":\"Second problem.\"}]}");
			var sender = new StatusCodeSender(new MockSender(new Response(422, payload)));

			var ex = Assert.Throws<UnprocessableEntityException>(() => sender.Send(new Request()));
			Assert.AreEqual("First problem. Second problem.", ex.Message);
		}

		[Test]
		public void TestFallbackAppendsBodyWhenErrorsCarryNoMessages()
		{
			var payload = Encoding.UTF8.GetBytes("{\"errors\":[]}");
			var sender = new StatusCodeSender(new MockSender(new Response(422, payload)));

			var ex = Assert.Throws<UnprocessableEntityException>(() => sender.Send(new Request()));
			Assert.AreEqual("GET request lacked required fields. Body: {\"errors\":[]}", ex.Message);
		}

		[Test]
		public void TestFallsBackAndAppendsBodyOn422WhenBodyUnusable()
		{
			var payload = Encoding.UTF8.GetBytes("not valid json with no message field");
			var sender = new StatusCodeSender(new MockSender(new Response(422, payload)));

			var ex = Assert.Throws<UnprocessableEntityException>(() => sender.Send(new Request()));
			Assert.AreEqual("GET request lacked required fields. Body: not valid json with no message field", ex.Message);
		}

		[Test]
		public void TestWhitespaceOnlyBodyYieldsEmptyBodyLabel()
		{
			var payload = Encoding.UTF8.GetBytes("   \n  ");
			var sender = new StatusCodeSender(new MockSender(new Response(422, payload)));

			var ex = Assert.Throws<UnprocessableEntityException>(() => sender.Send(new Request()));
			Assert.AreEqual("GET request lacked required fields. Body:", ex.Message);
		}

		[Test]
		public void TestFallsBackToCannedMessageOn422WhenBodyEmpty()
		{
			var sender = new StatusCodeSender(new MockSender(new Response(422, null)));

			var ex = Assert.Throws<UnprocessableEntityException>(() => sender.Send(new Request()));
			Assert.AreEqual("GET request lacked required fields. Body:", ex.Message);
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

		private static void AssertFallbackMessage<TException>(int statusCode, string expectedMessage)
			where TException : SmartyException
		{
			var sender = new StatusCodeSender(new MockSender(new Response(statusCode, null)));

			var ex = Assert.Throws<TException>(() => sender.Send(new Request()));
			Assert.AreEqual(expectedMessage + " Body:", ex.Message);
		}
	}
}
