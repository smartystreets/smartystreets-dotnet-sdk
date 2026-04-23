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

		//Business Summary Lookup Tests:

		[Test]
		public void TestSendingFullyPopulatedBusinessLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/1/business?";

			client.SendBusinessLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedBusinessComponentsLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/search/business?street=street&city=city&state=state&zipcode=zipcode";

			var lookup = new Business.Summary.Lookup();
			lookup.SetStreet("street");
			lookup.SetCity("city");
			lookup.SetState("state");
			lookup.SetZipcode("zipcode");

			client.SendBusinessLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSendingFullyPopulatedBusinessFreeformLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/search/business?freeform=freeform";

			var lookup = new Business.Summary.Lookup();
			lookup.SetFreeform("freeform");

			client.SendBusinessLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		//Business Detail Lookup Tests:

		[Test]
		public void TestSendingFullyPopulatedBusinessDetailLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/business/ABC123?";

			client.SendBusinessDetailLookup("ABC123");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestBusinessDetailUrlEncodesReservedChars()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/business/a%2Fb%3Fc%23d?";

			client.SendBusinessDetailLookup("a/b?c#d");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestBusinessDetailSendsEtagHeader()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			var lookup = new Business.Detail.Lookup("ABC123");
			lookup.SetRequestEtag("xyz-789");

			client.SendBusinessDetailLookup(lookup);

			Assert.IsTrue(this.capturingSender.Request.Headers.ContainsKey("Etag"));
			Assert.AreEqual("xyz-789", this.capturingSender.Request.Headers["Etag"]);
		}

		[Test]
		public void TestBusinessDetailIncludeFieldsLandInUrl()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/business/ABC123?include=phone";

			var lookup = new Business.Detail.Lookup("ABC123");
			lookup.SetIncludeFields("phone");

			client.SendBusinessDetailLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestBusinessDetailExcludeFieldsLandInUrl()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/business/ABC123?exclude=credit_score";

			var lookup = new Business.Detail.Lookup("ABC123");
			lookup.SetExcludeFields("credit_score");

			client.SendBusinessDetailLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestBusinessDetailCustomParametersLandInUrl()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/business/ABC123?experimental=1&trace=on";

			var lookup = new Business.Detail.Lookup("ABC123");
			lookup.AddCustomParameter("experimental", "1");
			lookup.AddCustomParameter("trace", "on");

			client.SendBusinessDetailLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestBusinessDetailIncludeExcludeAndCustomCombined()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrl = "http://localhost/business/ABC123?include=phone&exclude=credit_score&trace=on";

			var lookup = new Business.Detail.Lookup("ABC123");
			lookup.SetIncludeFields("phone");
			lookup.SetExcludeFields("credit_score");
			lookup.AddCustomParameter("trace", "on");

			client.SendBusinessDetailLookup(lookup);

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestRejectEmptyBusinessId()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			Assert.Throws<SmartyStreets.SmartyException>(() => client.SendBusinessDetailLookup(""));
		}

		[Test]
		public void TestRejectNullBusinessId()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			string businessId = null;

			Assert.Throws<SmartyStreets.SmartyException>(() => client.SendBusinessDetailLookup(businessId));
		}

		[Test]
		public void TestRejectWhitespaceBusinessId()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			Assert.Throws<SmartyStreets.SmartyException>(() => client.SendBusinessDetailLookup("   "));
		}

		[Test]
		public void TestRejectWhitespaceSmartyKeyOnSummaryLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			Assert.Throws<SmartyStreets.SmartyException>(() => client.SendBusinessLookup("   "));
		}

		[Test]
		public void TestRejectWhitespaceOnAllStandardLookupFields()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			var lookup = new Business.Summary.Lookup("   ");
			lookup.SetStreet("   ");
			lookup.SetFreeform("   ");

			Assert.Throws<SmartyStreets.SmartyException>(() => client.SendBusinessLookup(lookup));
		}

		[Test]
		public void TestBusinessDetailRejectsMultipleResults()
		{
			var lookup = new Business.Detail.Lookup("ABC");
			var json = "[{\"smarty_key\":\"1\"},{\"smarty_key\":\"2\"}]";
			var serializer = new NativeSerializer();
			using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json))) {
				Assert.Throws<SmartyStreets.SmartyException>(() => lookup.DeserializeAndSetResults(serializer, stream));
			}
			Assert.IsNull(lookup.GetResult());
		}

		[Test]
		public void TestBusinessDetailAcceptsSingleResult()
		{
			var lookup = new Business.Detail.Lookup("ABC");
			var json = "[{\"smarty_key\":\"7\",\"data_set_name\":\"business\",\"business_id\":\"ABC\",\"attributes\":{\"company_name\":\"Acme Corp\"}}]";
			var serializer = new NativeSerializer();
			using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json))) {
				lookup.DeserializeAndSetResults(serializer, stream);
			}
			var result = lookup.GetResult();
			Assert.IsNotNull(result);
			Assert.AreEqual("ABC", result.BusinessId);
			Assert.IsNotNull(result.Attributes);
			Assert.AreEqual("Acme Corp", result.Attributes.CompanyName);
		}

		[Test]
		public void TestBusinessDetailAcceptsEmptyResults()
		{
			var lookup = new Business.Detail.Lookup("ABC");
			var json = "[]";
			var serializer = new NativeSerializer();
			using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json))) {
				lookup.DeserializeAndSetResults(serializer, stream);
			}
			Assert.IsNull(lookup.GetResult());
		}

		[Test]
		public void TestEnrichmentSummaryLookupSendsEtagHeader()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			var lookup = new Property.Principal.Lookup("1");
			lookup.SetRequestEtag("abc-123");

			client.SendPropertyPrincipalLookup(lookup);

			Assert.IsTrue(this.capturingSender.Request.Headers.ContainsKey("Etag"));
			Assert.AreEqual("abc-123", this.capturingSender.Request.Headers["Etag"]);
		}

		//ETag response-capture tests (200 path; 304 path is owned by StatusCodeSenderTests since it throws upstream):

		[Test]
		public void TestBusinessDetailCapturesResponseEtagOnLookup()
		{
			var response = new Response(200, new byte[0]);
			response.HeaderInfo["Etag"] = "server-etag-1";
			var client = new Client(new MockSender(response), new FakeSerializer(null));

			var lookup = new Business.Detail.Lookup("ABC");
			client.SendBusinessDetailLookup(lookup);

			Assert.AreEqual("server-etag-1", lookup.GetResponseEtag());
		}

		[Test]
		public void TestResponseEtagDoesNotClobberRequestEtag()
		{
			var response = new Response(200, new byte[0]);
			response.HeaderInfo["Etag"] = "server-etag-2";
			var client = new Client(new MockSender(response), new FakeSerializer(null));

			var lookup = new Business.Detail.Lookup("ABC");
			lookup.SetRequestEtag("caller-etag");

			client.SendBusinessDetailLookup(lookup);

			Assert.AreEqual("caller-etag", lookup.GetRequestEtag());
			Assert.AreEqual("server-etag-2", lookup.GetResponseEtag());
		}

		[Test]
		public void TestBusinessDetailCaseInsensitiveResponseEtagHeader()
		{
			var response = new Response(200, new byte[0]);
			response.HeaderInfo["ETag"] = "standard-cased-etag";
			var client = new Client(new MockSender(response), new FakeSerializer(null));

			var lookup = new Business.Detail.Lookup("ABC");
			client.SendBusinessDetailLookup(lookup);

			Assert.AreEqual("standard-cased-etag", lookup.GetResponseEtag());
		}

		[Test]
		public void TestSummaryCapturesResponseEtagOnLookup()
		{
			var response = new Response(200, new byte[0]);
			response.HeaderInfo["Etag"] = "server-etag-summary";
			var client = new Client(new MockSender(response), new FakeSerializer(null));

			var lookup = new Business.Summary.Lookup("1");
			client.SendBusinessLookup(lookup);

			Assert.AreEqual("server-etag-summary", lookup.GetResponseEtag());
		}

		[Test]
		public void TestResponseEtagNullWhenHeaderAbsent()
		{
			var response = new Response(200, new byte[0]);
			var client = new Client(new MockSender(response), new FakeSerializer(null));

			var lookup = new Business.Detail.Lookup("ABC");
			lookup.SetRequestEtag("caller-etag");

			client.SendBusinessDetailLookup(lookup);

			Assert.AreEqual("caller-etag", lookup.GetRequestEtag());
			Assert.IsNull(lookup.GetResponseEtag());
		}

	}
}