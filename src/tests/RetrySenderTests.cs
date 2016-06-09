using NUnit.Framework;
using System.IO;

namespace SmartyStreets
{
	[TestFixture]
	public class RetrySenderTests
	{
		private MockCrashingSender mockCrashingSender;

		[SetUp]
		public void Setup()
		{
			this.mockCrashingSender = new MockCrashingSender();
		}

		[Test]
		public void TestSuccessDoesNotRetry()
		{
			this.SendRequest(MockCrashingSender.DO_NOT_RETRY);

			Assert.AreEqual(1, this.mockCrashingSender.SendCount);
		}

		[Test]
		public void TestRetryUntilSuccess()
		{
			this.SendRequest(MockCrashingSender.RETRY_THREE_TIMES);

			Assert.AreEqual(4, this.mockCrashingSender.SendCount);
		}

		[Test]
		[ExpectedException(typeof(IOException))]
		public void TestRetryUntilMaxAttemps()
		{
			this.SendRequest(MockCrashingSender.RETRY_MAX_TIMES);
		}

		private void SendRequest(string requestBehavior)
		{
			var request = new Request(requestBehavior);
			var retrySender = new RetrySender(5, this.mockCrashingSender);

			retrySender.Send(request);
		}
	}
}

