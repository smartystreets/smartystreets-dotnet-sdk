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
		private FakeRandomNumberGenerator fakeRandomNumberGenerator;
		private int MaxRetries = 5;

		[SetUp]
		public void Setup()
		{
			this.mockCrashingSender = new MockCrashingSender();
			fakeRandomNumberGenerator = new FakeRandomNumberGenerator();
			this.mockCrashingSender.FailCount = 1;
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

		[TestCase(3)]
		[TestCase(2)]
		[TestCase(4)]
		public async Task TestSleepOnRateLimit(int pseudoRandomNumber)
		{
			fakeRandomNumberGenerator.SetNextRandomNumber(pseudoRandomNumber);
			await this.SendRequest(MockCrashingSender.TooManyRequests);
			
			Assert.AreEqual(pseudoRandomNumber*1000, this.milliseconds);
		}

		private async Task SendRequest(string requestBehavior)
		{
			var request = new Request();
			request.SetUrlPrefix(requestBehavior);
			var retrySender = new RetrySender(MaxRetries, this.mockCrashingSender, this.sleep, fakeRandomNumberGenerator);

			await retrySender.Send(request);
		}

		public void sleep(int milliseconds)
		{
			this.milliseconds = milliseconds;
		}
	}
}