namespace SmartyStreets
{
	using System;
	using System.Text;
	using NUnit.Framework;

	[TestFixture]
	public class BasicAuthCredentialsTests
	{
		[Test]
		public void TestNewBasicAuthCredentialWithValidCredentials()
		{
			var cred = new BasicAuthCredentials("testID", "testToken");

			Assert.IsNotNull(cred);
		}

		[Test]
		public void TestNewBasicAuthCredentialWithEmptyAuthID()
		{
			Assert.Throws<ArgumentException>(() => new BasicAuthCredentials("", "testToken"));
		}

		[Test]
		public void TestNewBasicAuthCredentialWithEmptyAuthToken()
		{
			Assert.Throws<ArgumentException>(() => new BasicAuthCredentials("testID", ""));
		}

		[Test]
		public void TestNewBasicAuthCredentialWithBothEmpty()
		{
			Assert.Throws<ArgumentException>(() => new BasicAuthCredentials("", ""));
		}

		[Test]
		public void TestNewBasicAuthCredentialWithNullAuthID()
		{
			Assert.Throws<ArgumentException>(() => new BasicAuthCredentials(null, "testToken"));
		}

		[Test]
		public void TestNewBasicAuthCredentialWithNullAuthToken()
		{
			Assert.Throws<ArgumentException>(() => new BasicAuthCredentials("testID", null));
		}

		[Test]
		public void TestNewBasicAuthCredentialWithSpecialCharacters()
		{
			var cred = new BasicAuthCredentials("test@id#123", "token!@#$%^&*()");

			Assert.IsNotNull(cred);
		}

		[Test]
		public void TestSignWithValidCredentials()
		{
			var cred = new BasicAuthCredentials("myID", "myToken");
			var request = new Request();

			cred.Sign(request);

			var expectedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("myID:myToken"));
			Assert.AreEqual($"Basic {expectedCredentials}", request.Headers["Authorization"]);
		}

		[Test]
		public void TestSignWithPasswordContainingColon()
		{
			var cred = new BasicAuthCredentials("validUserID", "password:with:colons");
			var request = new Request();

			cred.Sign(request);

			var expectedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("validUserID:password:with:colons"));
			Assert.AreEqual($"Basic {expectedCredentials}", request.Headers["Authorization"]);
		}

		[Test]
		public void TestSignWithSpecialCharacters()
		{
			var cred = new BasicAuthCredentials("user@domain.com", "p@ssw0rd!");
			var request = new Request();

			cred.Sign(request);

			var expectedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("user@domain.com:p@ssw0rd!"));
			Assert.AreEqual($"Basic {expectedCredentials}", request.Headers["Authorization"]);
		}

		[Test]
		public void TestSignWithUnicodeCharacters()
		{
			var cred = new BasicAuthCredentials("用户", "密码");
			var request = new Request();

			cred.Sign(request);

			var expectedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("用户:密码"));
			Assert.AreEqual($"Basic {expectedCredentials}", request.Headers["Authorization"]);
		}

		[Test]
		public void TestSignOverwritesExistingHeader()
		{
			var cred = new BasicAuthCredentials("newID", "newToken");
			var request = new Request();
			request.SetHeader("Authorization", "Bearer oldtoken");

			cred.Sign(request);

			var expectedCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes("newID:newToken"));
			Assert.AreEqual($"Basic {expectedCredentials}", request.Headers["Authorization"]);
		}

		[Test]
		public void TestSignDoesNotAddQueryParameters()
		{
			var cred = new BasicAuthCredentials("myID", "myToken");
			var request = new Request();
			request.SetUrlPrefix("https://example.com/api?");

			cred.Sign(request);

			Assert.AreEqual("https://example.com/api?", request.GetUrl());
		}
	}
}
