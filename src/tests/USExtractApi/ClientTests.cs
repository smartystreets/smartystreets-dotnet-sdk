namespace SmartyStreets.USExtractApi
{
	using System;
	using System.Text;
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
		public void TestSendingBodyOnlyLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/?aggressive=false&addr_line_breaks=true&addr_per_line=0";
			var expectedPayload = Encoding.ASCII.GetBytes("Hello, World!");

			client.Send(new Lookup("Hello, World!"));

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
			Assert.AreEqual(expectedPayload, this.capturingSender.Request.Payload);
		}

		[TestCase(Lookup.ENHANCED)]
		[TestCase(Lookup.INVALID)]
		public void TestSendingFullyPopulatedLookup(string matchStrategy)
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrlTemplate = "http://localhost/?html=true&aggressive=true&addr_line_breaks=false&addr_per_line=2&match={0}";
			var expectedUrl = string.Format(expectedUrlTemplate, matchStrategy);
			var lookup = new Lookup("1");
			lookup.SpecifyHtmlInput(true);
			lookup.IsAggressive = true;
			lookup.AddressesHaveLineBreaks = false;
			lookup.AddressesPerLine = 2;
			lookup.MatchStrategy = matchStrategy;

			client.Send(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestRejectNullLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			Assert.Throws<ArgumentNullException>(() => client.Send(null));
		}

		[Test]
		public void TestDeserializeCalledWithResponseBody()
		{
			var response = new Response(0, Encoding.ASCII.GetBytes("Hello, World!"));
			var sender = new MockSender(response);
			var deserializer = new FakeDeserializer(null);
			var client = new Client(sender, deserializer);

			client.Send(new Lookup("Hello, World!"));

			Assert.AreEqual(response.Payload, deserializer.Payload);
		}

		[Test]
		public void TestResultCorrectlyAssignedToCorrespondingLookup()
		{
			var expectedResult = new Result();
			var lookup = new Lookup("Hello, World!");

			var sender = new MockSender(new Response(0, Encoding.ASCII.GetBytes("[]")));
			var deserializer = new FakeDeserializer(expectedResult);
			var client = new Client(sender, deserializer);

			client.Send(lookup);

			Assert.AreEqual(expectedResult, lookup.Result);
		}

		[Test]
		public void TestContentTypeSetCorrectly()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			var lookup = new Lookup("Hello, World!");

			client.Send(lookup);

			Assert.AreEqual("text/plain", this.capturingSender.Request.ContentType);
		}
	}
}