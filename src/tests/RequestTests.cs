using System;
using NUnit.Framework;

namespace SmartyStreets
{
	[TestFixture]
	public class RequestTests
	{
		[Test]
		public void TestNullNameQueryStringParameterNotAdded()
		{
			this.AssertQueryStringParameters(null, "value", "http://localhost/?");
		}

		[Test]
		public void TestEmptyNameQueryStringParameterNotAdded()
		{
			this.AssertQueryStringParameters("", "value", "http://localhost/?");
		}

		[Test]
		public void TestNullValueQueryStringParameterNotAdded()
		{
			this.AssertQueryStringParameters("name", null, "http://localhost/?");
		}

		[Test]
		public void TestEmptyValueQueryStringParameterIsAdded()
		{
			this.AssertQueryStringParameters("name", "", "http://localhost/?name=");
		}

		private void AssertQueryStringParameters(string name, string value, string expected)
		{
			var request = new Request("http://localhost/");

			request.PutParameter(name, value);

			Assert.AreEqual(expected, request.GetUrl());
		}

		[Test]

	
	}
}

