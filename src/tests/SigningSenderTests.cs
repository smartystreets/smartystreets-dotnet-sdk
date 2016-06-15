namespace SmartyStreets
{
	using NUnit.Framework;

	[TestFixture]
	public class SigningSenderTests
	{
		[Test]
		public void TestSigningOfRequest()
		{
			var signer = new StaticCredentials("id", "secret");
			var mockSender = new MockSender(null);
			var sender = new SigningSender(signer, mockSender);

			sender.Send(new Request("http://localhost/"));

			var url = mockSender.Request.GetUrl();

			Assert.AreEqual("http://localhost/?auth-id=id&auth-token=secret", url);
		}

		[Test]
		public void TestResponseReturnedCorrectly()
		{
			var signer = new StaticCredentials("id", "secret");
			var expectedResponse = new Response(200, null);
			var mockSender = new MockSender(expectedResponse);
			var sender = new SigningSender(signer, mockSender);

			var actualResponse = sender.Send(new Request("http://localhost/"));

			Assert.AreEqual(expectedResponse, actualResponse);
		}
	}
}