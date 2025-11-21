namespace SmartyStreets.USEnrichmentApi
{
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
			this.urlSender = new URLPrefixSender("http://localhost", this.capturingSender);
		}

		//Property Principal Lookup Tests:

		[Test]
		public void TestSendingFullyPopulatedPrincipalLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/property/principal?";

			client.SendPropertyPrincipalLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedPrincipalComponentsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/property/principal?features=feature&street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new Property.Principal.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");
			lookup.SetFeatures("feature");

			client.SendPropertyPrincipalLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedPrincipalFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/property/principal?freeform=freeform";

			var lookup = new Property.Principal.Lookup();
			lookup.SetFreeform("freeform");

			client.SendPropertyPrincipalLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		//GeoReference Lookup Tests:

		[Test]
		public void TestSendingFullyPopulatedGeoReferenceLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/geo-reference?";

			client.SendGeoReferenceLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedGeoReferenceComponenetsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/geo-reference?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new GeoReference.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			client.SendGeoReferenceLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedGeoReferenceFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/geo-reference?freeform=freeform";

			var lookup = new GeoReference.Lookup();
			lookup.SetFreeform("freeform");

			client.SendGeoReferenceLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		//Risk Lookup Tests:

		[Test]
		public void TestSendingFullyPopulatedRiskLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/risk?";

			client.SendRiskLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedRiskComponenetsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/risk?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new Risk.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			client.SendRiskLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedRiskFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/risk?freeform=freeform";

			var lookup = new Risk.Lookup();
			lookup.SetFreeform("freeform");

			client.SendRiskLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		//Secondary Lookup Tests:

		[Test]
		public void TestSendingFullyPopulatedSecondaryLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/secondary?";

			client.SendSecondaryLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedSecondaryComponentsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/secondary?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new Secondary.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			client.SendSecondaryLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedSecondaryFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/secondary?freeform=freeform";

			var lookup = new Secondary.Lookup();
			lookup.SetFreeform("freeform");

			client.SendSecondaryLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		//Secondary Count Lookup Tests:

		[Test]
		public void TestSendingFullyPopulatedSecondaryCountLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/secondary/count?";

			client.SendSecondaryCountLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedSecondaryCountComponenetsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/secondary/count?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new Secondary.Count.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			client.SendSecondaryCountLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public void TestSendingFullyPopulatedSecondaryCountFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/secondary/count?freeform=freeform";

			var lookup = new Secondary.Count.Lookup();
			lookup.SetFreeform("freeform");

			client.SendSecondaryCountLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestRejectNullLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			string smartyKey = null;

			Assert.Throws<SmartyStreets.SmartyException>(() => client.SendPropertyPrincipalLookup(smartyKey));
		}
	}
}