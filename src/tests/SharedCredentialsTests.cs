namespace SmartyStreets
{
	using NUnit.Framework;

	[TestFixture]
	public class SharedCredentialsTests
	{
		[Test]
		public void AssertSignedRequest()
		{
			var request = CreateSignedRequest();
			const string expected = "https://us-street.api.smarty.com/street-address?key=3516378604772256";

			Assert.AreEqual(expected, request.GetUrl());
		}

		[Test]
		public void AssertReferringHeader()
		{
			var request = CreateSignedRequest();

			Assert.AreEqual("https://example.com", request.Headers["Referer"]);
		}

		private static Request CreateSignedRequest()
		{
			var mobile = new SharedCredentials("3516378604772256", "example.com");
			var request = new Request();
			request.SetUrlPrefix("https://us-street.api.smarty.com/street-address?");
			mobile.Sign(request);
			return request;
		}
	}
}