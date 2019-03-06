namespace SmartyStreets
{
	using NUnit.Framework;
    using System.Threading.Tasks;

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
		public async Task TestSigningOfRequestAsync()
		{
			var mockSender = new MockSender(null);
			var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
			var sender = new SigningSender(this.signer, urlPrefixSender);

			await sender.SendAsync(new Request());

			Assert.AreEqual(
				"http://localhost/?auth-id=id&auth-token=secret",
				mockSender.Request.GetUrl());
		}

		[Test]
		public async Task TestResponseReturnedCorrectlyAsync()
		{
			var expectedResponse = new Response(200, null);
			var mockSender = new MockSender(expectedResponse);
			var sender = new SigningSender(this.signer, mockSender);
            var result = await sender.SendAsync(new Request());
			Assert.AreEqual(expectedResponse, result);
		}
	}
}