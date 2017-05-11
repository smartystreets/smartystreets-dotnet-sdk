using System.Text;
using NUnit.Framework;

namespace SmartyStreets.USExtractApi
{
    [TestFixture]
    public class ClientTests
    {
        [Test]
        public void TestSendingBodyOnlyLookup()
        {
            var capturingSender = new RequestCapturingSender();
            var sender = new URLPrefixSender("http://localhost/", capturingSender);
            var serializer = new FakeSerializer(null);
            var client = new Client(sender, serializer);
            const string expectedUrl = "http://localhost/?aggressive=false&addr_line_breaks=true&addr_per_line=0";
            var expectedPayload = Encoding.ASCII.GetBytes("Hello, World!");

            client.Send(new Lookup("Hello, World!"));

            Assert.AreEqual(expectedUrl, capturingSender.Request.GetUrl());
            Assert.AreEqual(expectedPayload, capturingSender.Request.Payload);
        }
    }
}