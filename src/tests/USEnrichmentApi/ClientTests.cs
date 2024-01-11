namespace SmartyStreets.USEnrichmentApi
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
		public void TestSendingFullyPopulatedPrincipalLookup(string matchStrategy)
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrlTemplate = "http://localhost/1/property/principal";
			var expectedUrl = string.Format(expectedUrlTemplate, matchStrategy);

			client.SendPropertyPrincipalLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

        [Test]
		public void TestSendingFullyPopulatedFinancialLookup(string matchStrategy)
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);
			const string expectedUrlTemplate = "http://localhost/1/property/financial";
			var expectedUrl = string.Format(expectedUrlTemplate, matchStrategy);

			client.SendPropertyPrincipalLookup("1");

			Assert.AreEqual(expectedUrl, this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestRejectNullLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.urlSender, serializer);

			Assert.Throws<ArgumentNullException>(() => client.SendPropertyFinancialLookup(null));
		}
	}
}