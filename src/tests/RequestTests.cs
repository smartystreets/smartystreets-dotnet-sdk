namespace SmartyStreets
{
	using NUnit.Framework;

	[TestFixture]
	public class RequestTests
	{
		[Test]
		public void TestNullNameQueryStringParameterNotAdded()
		{
			AssertQueryStringParameters(null, "value", "?");
		}

		[Test]
		public void TestEmptyNameQueryStringParameterNotAdded()
		{
			AssertQueryStringParameters(string.Empty, "value", "?");
		}

		[Test]
		public void TestNullValueQueryStringParameterNotAdded()
		{
			AssertQueryStringParameters("name", null, "?");
		}

		[Test]
		public void TestEmptyValueQueryStringParameterIsAdded()
		{
			AssertQueryStringParameters("name", string.Empty, "?");
		}

		private static void AssertQueryStringParameters(string name, string value, string expected)
		{
			var request = new Request();

			request.SetParameter(name, value);

			Assert.AreEqual(expected, request.GetUrl());
		}

		[Test]
		public void AssertMultipleQueryStringParametersAreAdded()
		{
			var request = new Request();

			request.SetParameter("name1", "value1");
			request.SetParameter("name2", "value2");
			request.SetParameter("name3", "value3");

			const string Expected = "?name1=value1&name2=value2&name3=value3";
			Assert.AreEqual(Expected, request.GetUrl());
		}

		[Test]
		public void AssertUrlEncodingOfQueryStringParameters()
		{
			var request = new Request();

			request.SetParameter("name&", "value");
			request.SetParameter("name1", "other !value$");

			const string Expected = "?name%26=value&name1=other%20%21value%24";
			Assert.AreEqual(Expected, request.GetUrl());
		}

		[Test]
		public void TestUrlEncodingOfUnicodeCharacters()
		{
			var request = new Request();

			request.SetParameter("needs_encoding", "&foo=bar");
			request.SetParameter("unicode", "Sjömadsvägen");

			const string Expected = "?needs_encoding=%26foo%3Dbar&unicode=Sj%C3%B6madsv%C3%A4gen";
			Assert.AreEqual(Expected, request.GetUrl());
		}

		[Test]
		public void TestUrlWithoutTrailingQuestionMark()
		{
			var request = new Request();
			request.SetUrlPrefix("http://localhost/?");

			const string Expected = "http://localhost/?";
			Assert.AreEqual(Expected, request.GetUrl());
		}

		[Test]
		public void TestHeadersAddedToRequest()
		{
			var request = new Request();

			request.SetHeader("header1", "value1");
			request.SetHeader("header2", "value2");

			Assert.AreEqual("value1", request.Headers["header1"]);
			Assert.AreEqual("value2", request.Headers["header2"]);
		}

		[Test]
		public void TestGet()
		{
			var request = new Request();

			Assert.AreEqual("GET", request.Method);
			Assert.IsNull(request.Payload);
		}

		[Test]
		public void TestPost()
		{
			var request = new Request
			{
				Payload = new byte[] {0, 1, 2}
			};

			var actualPayload = request.Payload;

			Assert.AreEqual("POST", request.Method);
			Assert.AreEqual(new byte[] {0, 1, 2}, actualPayload);
		}
	}
}