namespace SmartyStreets.InternationalPostalCodeApi
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using NUnit.Framework;
	using SmartyStreets;

	[TestFixture]
	public class ClientTests
	{
		private RequestCapturingSender capturingSender;
		private URLPrefixSender sender;

		[SetUp]
		public void Setup()
		{
			this.capturingSender = new RequestCapturingSender();
			this.sender = new URLPrefixSender("http://localhost/lookup", this.capturingSender);
		}

		[Test]
		public void TestLookupSerializedAndSent_ResponseCandidatesIncorporatedIntoLookup()
		{
			var responsePayload = Encoding.UTF8.GetBytes(@"[
				{""input_id"": ""1""},
				{""administrative_area"": ""2""},
				{""locality"": ""3""},
				{""postal_code"": ""4""}
			]");
			var response = new Response(200, responsePayload);
			var mockSender = new MockSender(response);
			var serializer = new NativeSerializer();
			var client = new Client(new URLPrefixSender("http://localhost/lookup", mockSender), serializer);
			var lookup = new Lookup
			{
				AdministrativeArea = "42"
			};

			client.Send(lookup);

			var request = mockSender.Request;
			Assert.IsNotNull(request);
			Assert.AreEqual("GET", request.Method);
			Assert.IsTrue(request.GetUrl().Contains("/lookup"));
			Assert.IsTrue(request.GetUrl().Contains("administrative_area=42"));
			Assert.AreEqual(4, lookup.Result.Count);
			Assert.AreEqual("1", lookup.Result[0].InputId);
			Assert.AreEqual("2", lookup.Result[1].AdministrativeArea);
			Assert.AreEqual("3", lookup.Result[2].Locality);
			Assert.AreEqual("4", lookup.Result[3].PostalCode);
		}

		[Test]
		public void TestNilLookupThrowsArgumentNullException()
		{
			var crashSender = new MockCrashingSender();
			var serializer = new NativeSerializer();
			var client = new Client(crashSender, serializer);

			Assert.Throws<ArgumentNullException>(() => client.Send(null));
		}

		[Test]
		public void TestFullJSONResponseDeserialization()
		{
			var responsePayload = Encoding.UTF8.GetBytes(@"[{
				""input_id"": ""1"",
				""country_iso_3"": ""2"",
				""locality"": ""3"",
				""administrative_area"": ""4"",
				""sub_administrative_area"": ""5"",
				""super_administrative_area"": ""6"",
				""postal_code"": ""7""
			}]");
			var response = new Response(200, responsePayload);
			var mockSender = new MockSender(response);
			var serializer = new NativeSerializer();
			var client = new Client(mockSender, serializer);
			var lookup = new Lookup();

			client.Send(lookup);

			Assert.AreEqual(1, lookup.Result.Count);
			var candidate = lookup.Result[0];
			Assert.AreEqual("1", candidate.InputId);
			Assert.AreEqual("2", candidate.CountryIso3);
			Assert.AreEqual("3", candidate.Locality);
			Assert.AreEqual("4", candidate.AdministrativeArea);
			Assert.AreEqual("5", candidate.SubAdministrativeArea);
			Assert.AreEqual("6", candidate.SuperAdministrativeArea);
			Assert.AreEqual("7", candidate.PostalCode);
		}

		[Test]
		public void TestSendingSingleFullyPopulatedLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.sender, serializer);
			var lookup = new Lookup
			{
				InputId = "1234",
				Country = "CAN",
				Locality = "Toronto",
				AdministrativeArea = "ON",
				PostalCode = "M5H 2N2"
			};

			client.Send(lookup);

			var url = this.capturingSender.Request.GetUrl();
			Assert.IsTrue(url.Contains("input_id=1234"));
			Assert.IsTrue(url.Contains("country=CAN"));
			Assert.IsTrue(url.Contains("locality=Toronto"));
			Assert.IsTrue(url.Contains("administrative_area=ON"));
			Assert.IsTrue(url.Contains("postal_code=M5H%202N2"));
		}

		[Test]
		public void TestCandidatesCorrectlyAssignedToLookup()
		{
			var expectedCandidates = new List<Candidate>
			{
				new Candidate { InputId = "1" },
				new Candidate { InputId = "2" }
			};
			var lookup = new Lookup();

			var mockSender = new MockSender(new Response(200, Encoding.ASCII.GetBytes("[]")));
			var deserializer = new FakeDeserializer(expectedCandidates);
			var client = new Client(mockSender, deserializer);

			client.Send(lookup);

			Assert.AreEqual(2, lookup.Result.Count);
			Assert.AreEqual("1", lookup.Result[0].InputId);
			Assert.AreEqual("2", lookup.Result[1].InputId);
		}

		[Test]
		public void TestDeserializeCalledWithResponseBody()
		{
			var response = new Response(200, Encoding.ASCII.GetBytes("Hello, World!"));
			var mockSender = new MockSender(response);
			var deserializer = new FakeDeserializer(null);
			var client = new Client(mockSender, deserializer);

			client.Send(new Lookup());

			Assert.AreEqual(response.Payload, deserializer.Payload);
		}
	}
}

