namespace SmartyStreets.USAutocompletePro
{
	using USAutocompleteProApi;
	using NUnit.Framework;
    using System.Threading.Tasks;

    [TestFixture]
	public class ClientTests
	{
		private RequestCapturingSender capturingSender;
		private URLPrefixSender sender;


		[SetUp]
		public void Setup()
		{
			this.capturingSender = new RequestCapturingSender();
			this.sender = new URLPrefixSender("http://localhost/", this.capturingSender);
		}

		[Test]
		public void TestSendingLookup()
		{
			var serializer = new FakeSerializer(null);
			var client = new Client(this.sender, serializer);
			var lookup = new Lookup("test");

			client.Send(lookup);

			Assert.AreEqual("http://localhost/?search=test&prefer_geolocation=city", this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSourceNotIncludedWhenNotSet()
		{
			var client = new Client(this.sender, new FakeSerializer(null));
			var lookup = new Lookup("test");

			client.Send(lookup);

			StringAssert.DoesNotContain("source", this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSourceAll()
		{
			var client = new Client(this.sender, new FakeSerializer(null));
			var lookup = new Lookup("test") { Source = SourceType.ALL };

			client.Send(lookup);

			Assert.AreEqual("http://localhost/?search=test&prefer_geolocation=city&source=all", this.capturingSender.Request.GetUrl());
		}

		[Test]
		public void TestSourcePostal()
		{
			var client = new Client(this.sender, new FakeSerializer(null));
			var lookup = new Lookup("test") { Source = SourceType.POSTAL };

			client.Send(lookup);

			Assert.AreEqual("http://localhost/?search=test&prefer_geolocation=city&source=postal", this.capturingSender.Request.GetUrl());
		}
	}
}
