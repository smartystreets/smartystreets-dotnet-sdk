namespace SmartyStreets.USEnrichmentApi
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
			this.urlSender = new URLPrefixSender("http://localhost", this.capturingSender);
		}

		//Property Principal Lookup Tests:

		[Test]
		public async Task TestSendingFullyPopulatedPrincipalLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/property/principal?";

			await client.SendPropertyPrincipalLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedPrincipalComponenetsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/property/principal?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new Property.Principal.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			await client.SendPropertyPrincipalLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedPrincipalFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/property/principal?freeform=freeform";

			var lookup = new Property.Principal.Lookup();
			lookup.SetFreeform("freeform");

			await client.SendPropertyPrincipalLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		//Property Financial Lookup Tests:

		[Test]
		public async Task TestSendingFullyPopulatedFinancialLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/property/financial?";

			await client.SendPropertyFinancialLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedFinancialComponenetsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/property/financial?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new Property.Financial.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			await client.SendPropertyFinancialLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedFinancialFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/property/financial?freeform=freeform";

			var lookup = new Property.Financial.Lookup();
			lookup.SetFreeform("freeform");

			await client.SendPropertyFinancialLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		//GeoReference Lookup Tests:

		[Test]
		public async Task TestSendingFullyPopulatedGeoReferenceLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/geo-reference?";

			await client.SendGeoReferenceLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedGeoReferenceComponenetsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/geo-reference?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new GeoReference.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			await client.SendGeoReferenceLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedGeoReferenceFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/geo-reference?freeform=freeform";

			var lookup = new GeoReference.Lookup();
			lookup.SetFreeform("freeform");

			await client.SendGeoReferenceLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		//Secondary Lookup Tests:

		[Test]
		public async Task TestSendingFullyPopulatedSecondaryLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/secondary?";

			await client.SendSecondaryLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedSecondaryComponenetsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/secondary?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new Secondary.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			await client.SendSecondaryLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedSecondaryFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/secondary?freeform=freeform";

			var lookup = new Secondary.Lookup();
			lookup.SetFreeform("freeform");

			await client.SendSecondaryLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		//Secondary Count Lookup Tests:

		[Test]
		public async Task TestSendingFullyPopulatedSecondaryCountLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/1/secondary/count?";

			await client.SendSecondaryCountLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedSecondaryCountComponenetsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/secondary/count?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new Secondary.Count.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			await client.SendSecondaryCountLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		public async Task TestSendingFullyPopulatedSecondaryCountFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl= "http://localhost/search/secondary/count?freeform=freeform";

			var lookup = new Secondary.Count.Lookup();
			lookup.SetFreeform("freeform");

			await client.SendSecondaryCountLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestRejectNullLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			string smartyKey = null;

			Assert.ThrowsAsync<SmartyStreets.SmartyException>(async () => await client.SendPropertyFinancialLookup(smartyKey));
		}
	}
}