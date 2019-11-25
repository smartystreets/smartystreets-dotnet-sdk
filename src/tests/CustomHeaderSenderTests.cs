using System.Collections.Generic;

namespace SmartyStreets
{
    using NUnit.Framework;

    [TestFixture]
    public class CustomHeaderSenderTests
    {
        [Test]
        public void TestAddingHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                ["Test1"] = "value1",
                ["Test2"] = "value2"
            };

            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new CustomHeaderSender(headers, urlPrefixSender);

            sender.Send(new Request());

            Assert.AreEqual("value1", mockSender.Request.Headers["Test1"]);
            Assert.AreEqual("value2", mockSender.Request.Headers["Test2"]);
        }
    }
}