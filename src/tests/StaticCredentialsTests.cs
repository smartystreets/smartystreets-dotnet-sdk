namespace SmartyStreets
{
	using NUnit.Framework;

	[TestFixture]
	public class StaticCredentialsTests
	{
		[Test]
		public void TestStandardCredentials()
		{
			AssertSignedRequest(
				"f83280df-s83d-f82j-d829-kd02l9tis7ek",
				"S9Djk63k2Ilj67vN82Km",
				"https://us-street.api.smarty.com/street-address?" +
				"auth-id=f83280df-s83d-f82j-d829-kd02l9tis7ek&auth-token=S9Djk63k2Ilj67vN82Km");
		}

		[Test]
		public void TestUrlEncoding()
		{
			AssertSignedRequest(
				"as3$d8+56d9",
				"d8j#ds'dfe2",
				"https://us-street.api.smarty.com/street-address?" +
				"auth-id=as3%24d8%2B56d9&auth-token=d8j%23ds%27dfe2");
		}

		private static void AssertSignedRequest(string id, string secret, string expected)
		{
			var credentials = new StaticCredentials(id, secret);
			var request = new Request();
			request.SetUrlPrefix("https://us-street.api.smarty.com/street-address?");

			credentials.Sign(request);

			Assert.AreEqual(expected, request.GetUrl());
		}
	}
}