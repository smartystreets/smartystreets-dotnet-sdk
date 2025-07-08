namespace SmartyStreets
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class URLPrefixSenderTests 
    {
        [Test]
        public async Task TestRequestURLPresent()
        {
            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);

            var request = new Request();
            request.SetUrlComponents("jimbo");

            await urlPrefixSender.Send(request);

            Assert.AreEqual("http://localhost/jimbo?", request.GetUrl());
        }

        [Test]
        public async Task TestRequestURLAbsent()
        {
            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);

            var request = new Request();

            await urlPrefixSender.Send(request);

            Assert.AreEqual("http://localhost/?", request.GetUrl());
        }

        [Test]
        public async Task TestMultipleSends()
        {
            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);

            var request = new Request();
            request.SetUrlComponents("jimbo");

            await urlPrefixSender.Send(request);
            await urlPrefixSender.Send(request);

            Assert.AreEqual("http://localhost/jimbo?", request.GetUrl());
        }
    }
}