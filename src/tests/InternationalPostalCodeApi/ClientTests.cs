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
				""postal_code"": ""7"",
				""thoroughfare"": ""8""
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
			Assert.AreEqual("8", candidate.Thoroughfare);
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
				Language = LanguageMode.Native,
				Locality = "Toronto",
				AdministrativeArea = "ON",
				PostalCode = "M5H 2N2",
				MaxResults = 25
			};

			client.Send(lookup);

			Assert.AreEqual("http://localhost/lookup?input_id=1234&country=CAN&language=native&locality=Toronto" +
			                "&administrative_area=ON&postal_code=M5H%202N2&max_results=25",
				this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingLookupWithLatinLanguage()
		{
			var client = new Client(this.sender, new FakeSerializer(null));
			var lookup = new Lookup { Country = "CAN", Language = LanguageMode.Latin };

			client.Send(lookup);

			Assert.AreEqual("http://localhost/lookup?country=CAN&language=latin", this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingLookupWithLanguageParsedFromMixedCaseValue()
		{
			var client = new Client(this.sender, new FakeSerializer(null));
			var lookup = new Lookup { Country = "CAN", Language = LanguageModeExtensions.FromValue("NATIVE") };

			client.Send(lookup);

			Assert.AreEqual("http://localhost/lookup?country=CAN&language=native", this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingLookupWithNoLanguage()
		{
			var client = new Client(this.sender, new FakeSerializer(null));
			var lookup = new Lookup { Country = "CAN" };

			client.Send(lookup);

			Assert.That(this.capturingSender.Request.GetUrl(), Does.Not.Contain("language="));
		}

		[Test]
		public void TestLanguageModeParseRejectsInvalidValue()
		{
			Assert.Throws<UnprocessableEntityException>(() => LanguageModeExtensions.FromValue("Klingon"));
		}

		[Test]
		public void TestSendingLookupWithMaxResults()
		{
			var client = new Client(this.sender, new FakeSerializer(null));
			var lookup = new Lookup { Country = "CAN", MaxResults = 1000 };

			client.Send(lookup);

			Assert.AreEqual("http://localhost/lookup?country=CAN&max_results=1000", this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingLookupWithNoMaxResults()
		{
			var client = new Client(this.sender, new FakeSerializer(null));
			var lookup = new Lookup { Country = "CAN" };

			client.Send(lookup);

			Assert.That(this.capturingSender.Request.GetUrl(), Does.Not.Contain("max_results="));
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

