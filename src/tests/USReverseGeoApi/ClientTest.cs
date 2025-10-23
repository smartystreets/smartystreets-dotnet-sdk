namespace SmartyStreets.USReverseGeo
{
	using USReverseGeoApi;
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
			var lookup = new Lookup(44.888888888, -111.111111111);

			client.Send(lookup);

			Assert.AreEqual("http://localhost/?latitude=44.88888889&longitude=-111.11111111", this.capturingSender.Request.GetUrl());
		}
	}
}