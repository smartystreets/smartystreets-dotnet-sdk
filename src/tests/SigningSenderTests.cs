namespace SmartyStreets
{
	using NUnit.Framework;

	[TestFixture]
	public class SigningSenderTests
	{
		private StaticCredentials signer;

		[SetUp]
		public void SetUp()
		{
			this.signer = new StaticCredentials("id", "secret");
		}

		[Test]
		public void TestSigningOfRequest()
		{
			var mockSender = new MockSender(null);
			var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
			var sender = new SigningSender(this.signer, urlPrefixSender);

			sender.Send(new Request());

			Assert.AreEqual(
				"http://localhost/?auth-id=id&auth-token=secret",
				mockSender.Request.GetUrl());
		}

		[Test]
		public void TestResponseReturnedCorrectly()
		{
			var expectedResponse = new Response(200, null);
			var mockSender = new MockSender(expectedResponse);
			var sender = new SigningSender(this.signer, mockSender);

			Assert.AreEqual(
				expectedResponse,
				sender.Send(new Request()));
		}
	}
}