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
            var headers = new Dictionary<string, string>
            {
                ["User-Agent"] = "custom-value"
            };
            var appendHeaders = new Dictionary<string, string>
            {
                ["User-Agent"] = " "
            };

            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new CustomHeaderSender(headers, appendHeaders, urlPrefixSender);

            var request = new Request();
            request.SetHeader("User-Agent", "base-value");
            await sender.SendAsync(request);

            Assert.AreEqual("base-value custom-value", mockSender.Request.Headers["User-Agent"]);
        }
    }
}