using System;

namespace SmartyStreets
{
	using System.IO;
    using System.Threading.Tasks;
    using NUnit.Framework;

	[TestFixture]
	public class RetrySenderTests
	{
		private MockCrashingSender mockCrashingSender;
		private int milliseconds;
		private int sleepCount;
		private FakeRandomNumberGenerator fakeRandomNumberGenerator;
		private int MaxRetries = 5;

		[SetUp]
		public void Setup()
		{
			this.mockCrashingSender = new MockCrashingSender();
			fakeRandomNumberGenerator = new FakeRandomNumberGenerator();
			this.mockCrashingSender.FailCount = 1;
			this.sleepCount = 0;
		}

		[Test]
		public async Task TestSuccessDoesNotRetry()
		{
			await this.SendRequest(MockCrashingSender.DoNotRetry);

			Assert.AreEqual(1, this.mockCrashingSender.SendCount);
		}

		[TestCase(typeof(BadRequestException), MockCrashingSender.BadRequest)]
		[TestCase(typeof(RequestEntityTooLargeException), MockCrashingSender.RequestEntityTooLarge)]
		[TestCase(typeof(UnprocessableEntityException), MockCrashingSender.UnprocessableEntity)]
		public void TestSpecificErrorThrowsExceptionAndDoesNotRetry(Type exceptionType, string requestBehavior)
		{
			Assert.ThrowsAsync(exceptionType, async () => await this.SendRequest(requestBehavior));
			Assert.AreEqual(1, this.mockCrashingSender.SendCount);
		}

		[TestCase(typeof(RequestTimeoutException), MockCrashingSender.RequestTimeout)]
		[TestCase(typeof(InternalServerErrorException), MockCrashingSender.InternalServer)]
		[TestCase(typeof(BadGatewayException), MockCrashingSender.BadGateway)]
		[TestCase(typeof(ServiceUnavailableException), MockCrashingSender.ServiceUnavailable)]
		[TestCase(typeof(GatewayTimeoutException), MockCrashingSender.GatewayTimeout)]
		public async Task TestSpecificErrorThrowsExceptionAndRetries(Type exceptionType, string requestBehavior)
		{
			this.mockCrashingSender.FailCount = 3;
			await this.SendRequest(requestBehavior);
			Assert.AreEqual(3, this.mockCrashingSender.SendCount);
		}

		[Test]
		public async Task TestRetryUntilSuccess()
		{
			await this.SendRequest(MockCrashingSender.RetryThreeTimes);

			Assert.AreEqual(4, this.mockCrashingSender.SendCount);
		}

		[Test]
		public void TestRetryUntilMaxAttempts()
		{
			Assert.ThrowsAsync<IOException>(async () => await this.SendRequest(MockCrashingSender.RetryMaxTimes));
		}

		[Test]
		public async Task TestDefaultSleepOnRateLimit()
		{
			await this.SendRequest(MockCrashingSender.TooManyRequests);

			Assert.AreEqual(10000, this.milliseconds);
		}

		[Test]
		public async Task TestRetryAfterSleepOnRateLimit()
		{
			await this.SendRequest(MockCrashingSender.TooManyRequestsWithRetryAfter);

			Assert.AreEqual(5000, this.milliseconds);
		}

		[Test]
		public async Task TestOnlyOneSleepOnRateLimit()
		{
			await this.SendRequest(MockCrashingSender.TooManyRequests);

			Assert.AreEqual(1, this.sleepCount);
		}

		[Test]
		public void TestRateLimitMaxRetriesThrows()
		{
			Assert.ThrowsAsync<TooManyRequestsException>(async () => await this.SendRequest(MockCrashingSender.TooManyRequestsAlways));
			Assert.AreEqual(MaxRetries + 1, this.mockCrashingSender.SendCount);
		}

		private async Task SendRequest(string requestBehavior)
		{
			var request = new Request();
			request.SetUrlPrefix(requestBehavior);
			var retrySender = new RetrySender(MaxRetries, this.mockCrashingSender, this.sleep, fakeRandomNumberGenerator);

			await retrySender.SendAsync(request);
		}

		public void sleep(int milliseconds)
		{
			this.milliseconds = milliseconds;
			this.sleepCount++;
		}
	}
}