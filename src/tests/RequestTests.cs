namespace SmartyStreets
{
	using NUnit.Framework;

	[TestFixture]
	public class RequestTests
	{
		[Test]
		public void TestNullNameQueryStringParameterNotAdded()
		{
			AssertQueryStringParameters(null, "value", "http://localhost/?");
		}

		[Test]
		public void TestEmptyNameQueryStringParameterNotAdded()
		{
			AssertQueryStringParameters(string.Empty, "value", "http://localhost/?");
		}

		[Test]
		public void TestNullValueQueryStringParameterNotAdded()
		{
			AssertQueryStringParameters("name", null, "http://localhost/?");
		}

		[Test]
		public void TestEmptyValueQueryStringParameterIsAdded()
		{
			AssertQueryStringParameters("name", string.Empty, "http://localhost/?name=");
		}

		private static void AssertQueryStringParameters(string name, string value, string expected)
		{
			var request = new Request("http://localhost/?");

			request.SetParameter(name, value);

			Assert.AreEqual(expected, request.GetUrl());
		}

		[Test]
		public void AssertMultipleQueryStringParametersAreAdded()
		{
			var request = new Request("http://localhost/?");

			request.SetParameter("name1", "value1");
			request.SetParameter("name2", "value2");
			request.SetParameter("name3", "value3");

			const string Expected = "http://localhost/?name1=value1&name2=value2&name3=value3";
			Assert.AreEqual(Expected, request.GetUrl());
		}

		[Test]
		public void AssertUrlEncodingOfQueryStringParameters()
		{
			var request = new Request("http://localhost/?");

			request.SetParameter("name&", "value");
			request.SetParameter("name1", "other !value$");

			const string Expected = "http://localhost/?name%26=value&name1=other+!value%24";
			Assert.AreEqual(Expected, request.GetUrl());
		}

		[Test]
		public void TestUrlWithoutTrailingQuestionMark()
		{
			var request = new Request("http://localhost/");

			const string Expected = "http://localhost/?";
			Assert.AreEqual(Expected, request.GetUrl());
		}

		[Test]
		public void TestHeadersAddedToRequest()
		{
			var request = new Request("http://localhost/");

			request.SetHeader("header1", "value1");
			request.SetHeader("header2", "value2");

			Assert.AreEqual("value1", request.Headers["header1"]);
			Assert.AreEqual("value2", request.Headers["header2"]);
		}

		[Test]
		public void TestGet()
		{
			var request = new Request("http://localhost/");

			Assert.AreEqual("GET", request.Method);
			Assert.IsNull(request.Payload);
		}

		[Test]
		public void TestPost()
		{
			var request = new Request("http://localhost/")
			{
				Payload = new byte[] { 0, 1, 2 }
			};

			var actualPayload = request.Payload;

			Assert.AreEqual("POST", request.Method);
			Assert.AreEqual(new byte[]{0,1,2}, actualPayload);
		}
	}
}
