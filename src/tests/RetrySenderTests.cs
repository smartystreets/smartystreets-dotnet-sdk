namespace SmartyStreets
{
	using System.IO;
    using System.Threading.Tasks;
    using NUnit.Framework;

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
		public async Task TestSuccessDoesNotRetryAsync()
		{
			await this.SendRequestAsync(MockCrashingSender.DoNotRetry);

			Assert.AreEqual(1, this.mockCrashingSender.SendCount);
		}

		[Test]
		public async Task TestRetryUntilSuccessAsync()
		{
			await this.SendRequestAsync(MockCrashingSender.RetryThreeTimes);

			Assert.AreEqual(4, this.mockCrashingSender.SendCount);
		}

		[Test]
		public void TestRetryUntilMaxAttemps()
		{
			Assert.ThrowsAsync<IOException>(async () => await this.SendRequestAsync(MockCrashingSender.RetryMaxTimes));
		}

		private async Task SendRequestAsync(string requestBehavior)
		{
			var request = new Request();
			request.SetUrlPrefix(requestBehavior);
			var retrySender = new RetrySender(5, this.mockCrashingSender);

			await retrySender.SendAsync(request);
		}
	}
}