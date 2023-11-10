namespace SmartyStreets
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class URLPrefixSenderTests 
    {
        [Test]
        public void TestRequestURLPresent()
        {
            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);

            var request = new Request();
            request.SetUrlPrefix("jimbo");

            urlPrefixSender.Send(request);

            Assert.AreEqual("http://localhost/jimbo?", request.GetUrl());
        }

        [Test]
        public void TestRequestURLAbsent()
        {
            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);

            var request = new Request();

            urlPrefixSender.Send(request);

            Assert.AreEqual("http://localhost/?", request.GetUrl());
        }
    }
}