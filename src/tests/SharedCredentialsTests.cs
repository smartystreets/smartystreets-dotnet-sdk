using System;
using NUnit.Framework;
namespace SmartyStreets
{
	[TestFixture]
	public class SharedCredentialsTests
	{
		[Test]
		public void assertSignedRequest()
		{
			var request = createSignedRequest();
			const string expected = "https://us-street.api.smartystreets.com/street-address?auth-id=3516378604772256";

			Assert.AreEqual(expected, request.GetUrl());
		}

		[Test]
		public void assertReferringHeader()
		{
			var request = createSignedRequest();

			Assert.AreEqual("https://example.com", request.Headers["Referer"]);
		}

		private static Request createSignedRequest()
		{
			var mobile = new SharedCredentials("3516378604772256", "example.com");
			var request = new Request();
			request.SetUrlPrefix("https://us-street.api.smartystreets.com/street-address?");
			mobile.Sign(request);
			return request;
		}
	}
}

