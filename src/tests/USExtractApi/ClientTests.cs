namespace SmartyStreets.USExtractApi
{
	using System;
	using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

	[TestFixture]
	public class ClientTests
	{
		private RequestCapturingSender capturingSender;
		private URLPrefixSender urlSender;

		[SetUp]
		public void Setup()
		{
			this.capturingSender = new RequestCapturingSender();
			this.urlSender = new URLPrefixSender("http://localhost/", this.capturingSender);
		}

		[Test]
		public async Task TestSendingBodyOnlyLookupAsync()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/?aggressive=false&addr_line_breaks=true&addr_per_line=0";
			var expectedPayload = Encoding.ASCII.GetBytes("Hello, World!");

			await client.SendAsync(new Lookup("Hello, World!"));

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
			Assert.AreEqual(expectedPayload, this.capturingSender.Request.Payload);
		}

		[Test]
		public async Task TestSendingFullyPopulatedLookupAsync()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/?html=true&aggressive=true&addr_line_breaks=false&addr_per_line=2";
			var lookup = new Lookup("1");
			lookup.SpecifyHtmlInput(true);
			lookup.IsAggressive = true;
			lookup.AddressesHaveLineBreaks = false;
			lookup.AddressesPerLine = 2;

			await client.SendAsync(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestRejectNullLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			Assert.ThrowsAsync<ArgumentNullException>(async () => await client.SendAsync(null));
		}

		[Test]
		public async Task TestDeserializeCalledWithResponseBodyAsync()
		{
			var response = new Response(0, Encoding.ASCII.GetBytes("Hello, World!"));
			var sender = new MockSender(response);
			var deserializer = new FakeDeserializer(null);
			var client = new Client(sender, deserializer);

			await client.SendAsync(new Lookup("Hello, World!"));

			Assert.AreEqual(response.Payload, deserializer.Payload);
		}

		[Test]
		public async Task TestResultCorrectlyAssignedToCorrespondingLookupAsync()
		{
			var expectedResult = new Result();
			var lookup = new Lookup("Hello, World!");

			var sender = new MockSender(new Response(0, Encoding.ASCII.GetBytes("[]")));
			var deserializer = new FakeDeserializer(expectedResult);
			var client = new Client(sender, deserializer);

			await client.SendAsync(lookup);

			Assert.AreEqual(expectedResult, lookup.Result);
		}

		[Test]
		public async Task TestContentTypeSetCorrectlyAsync()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			var lookup = new Lookup("Hello, World!");

			await client.SendAsync(lookup);

			Assert.AreEqual("text/plain", this.capturingSender.Request.ContentType);
		}
	}
}