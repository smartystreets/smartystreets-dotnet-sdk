using System.Threading.Tasks;

namespace SmartyStreets
{
	using System.IO;
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
		public void TestSuccessDoesNotRetry()
		{
			this.SendRequest(MockCrashingSender.DoNotRetry);

			Assert.AreEqual(1, this.mockCrashingSender.SendCount);
		}

		[Test]
		public void TestRetryUntilSuccess()
		{
			this.SendRequest(MockCrashingSender.RetryThreeTimes);

			Assert.AreEqual(4, this.mockCrashingSender.SendCount);
		}

		[Test]
		public void TestRetryUntilMaxAttemps()
		{
			Assert.Throws<IOException>(() => this.SendRequest(MockCrashingSender.RetryMaxTimes));
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
        public async Task TestRetryUntilMaxAttempsAsync()
        {
            Assert.Throws<IOException>(async () => await this.SendRequestAsync(MockCrashingSender.RetryMaxTimes));
        }

        private void SendRequest(string requestBehavior)
		{
			var request = new Request(requestBehavior);
			var retrySender = new RetrySender(5, this.mockCrashingSender);

			retrySender.Send(request);
        }

        private Task SendRequestAsync(string requestBehavior)
        {
            var request = new Request(requestBehavior);
            var retrySender = new RetrySender(5, this.mockCrashingSender);

            return retrySender.SendAsync(request);
        }
    }
}