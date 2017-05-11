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
			Request request = this.createSignedRequest();
			String expected = "https://us-street.api.smartystreets.com/street-address?auth-id=3516378604772256";

			Assert.AreEqual(expected, request.GetUrl());
		}

		[Test]
		public void assertReferringHeader()
		{
			Request request = this.createSignedRequest();

			Assert.AreEqual("https://example.com", request.Headers["Referer"]);
		}

		private Request createSignedRequest()
		{
			var mobile = new SharedCredentials("3516378604772256", "example.com");
			Request request = new Request();
			request.SetUrlPrefix("https://us-street.api.smartystreets.com/street-address?");
			mobile.Sign(request);
			return request;
		}
	}
}

