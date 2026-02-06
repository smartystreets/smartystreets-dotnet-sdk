using System.Collections.Generic;

namespace SmartyStreets
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class CustomHeaderSenderTests
    {
        [Test]
        public async Task TestAddingHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                ["Test1"] = "value1",
                ["Test2"] = "value2"
            };

            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new CustomHeaderSender(headers, urlPrefixSender);

            await sender.SendAsync(new Request());

            Assert.AreEqual("value1", mockSender.Request.Headers["Test1"]);
            Assert.AreEqual("value2", mockSender.Request.Headers["Test2"]);
        }

        [Test]
        public async Task TestAppendedHeadersAreJoinedWithSeparator()
        {
            var appendHeaders = new Dictionary<string, AppendedHeader>
            {
                ["User-Agent"] = new AppendedHeader("custom-value", " ")
            };

            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new CustomHeaderSender(new Dictionary<string, string>(), appendHeaders, urlPrefixSender);

            var request = new Request();
            request.SetHeader("User-Agent", "base-value");
            await sender.SendAsync(request);

            Assert.AreEqual("base-value custom-value", mockSender.Request.Headers["User-Agent"]);
        }

        [Test]
        public async Task TestAppendedAndCustomHeadersCoexist()
        {
            var headers = new Dictionary<string, string>
            {
                ["X-Custom"] = "hello"
            };
            var appendHeaders = new Dictionary<string, AppendedHeader>
            {
                ["User-Agent"] = new AppendedHeader("my-app/1.0", " ")
            };

            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new CustomHeaderSender(headers, appendHeaders, urlPrefixSender);

            var request = new Request();
            request.SetHeader("User-Agent", "smarty-sdk/1.0");
            await sender.SendAsync(request);

            Assert.AreEqual("smarty-sdk/1.0 my-app/1.0", mockSender.Request.Headers["User-Agent"]);
            Assert.AreEqual("hello", mockSender.Request.Headers["X-Custom"]);
        }

        [Test]
        public async Task TestAppendedHeaderWithNoExistingValue()
        {
            var appendHeaders = new Dictionary<string, AppendedHeader>
            {
                ["User-Agent"] = new AppendedHeader("my-app/1.0", " ")
            };

            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new CustomHeaderSender(new Dictionary<string, string>(), appendHeaders, urlPrefixSender);

            await sender.SendAsync(new Request());

            Assert.AreEqual("my-app/1.0", mockSender.Request.Headers["User-Agent"]);
        }
    }
}
