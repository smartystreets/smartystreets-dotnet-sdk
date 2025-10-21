using System.Collections.Generic;
using System.Reflection;

namespace SmartyStreets
{
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class CustomQuerySenderTests
    {
        [Test]
        public async Task TestCustomQuerySender()
        {
            var queries = new Dictionary<string, string>
            {
                ["Test1"] = "value1",
                ["Test2"] = "value2"
            };

            var mockSender = new MockSender(null);
            var urlPrefixSender = new URLPrefixSender("http://localhost/", mockSender);
            var sender = new CustomQuerySender(queries, urlPrefixSender);

            await sender.SendAsync(new Request());

            var field = typeof(Request).GetField("parameters", BindingFlags.NonPublic | BindingFlags.Instance);
            var parameters = (Dictionary<string, string>)field.GetValue(mockSender.Request);

            Assert.AreEqual("value1", parameters["Test1"]);
            Assert.AreEqual("value2", parameters["Test2"]);
        }
    }
}