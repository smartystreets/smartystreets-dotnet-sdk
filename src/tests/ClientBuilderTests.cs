using System.Collections.Generic;
using System.Reflection;

namespace SmartyStreets
{
    using NUnit.Framework;

    [TestFixture]
    public class ClientBuilderTests
    {
        private static Dictionary<string, string> GetCustomQueries(ClientBuilder builder)
        {
            var field = typeof(ClientBuilder).GetField("customQueries", BindingFlags.NonPublic | BindingFlags.Instance);
            return (Dictionary<string, string>)field.GetValue(builder);
        }

        [Test]
        public void TestWithFeatureIanaTimeZone()
        {
            var builder = new ClientBuilder().WithFeatureIanaTimeZone();

            Assert.AreEqual("iana-timezone", GetCustomQueries(builder)["features"]);
        }

        [Test]
        public void TestWithFeatureIanaTimeZoneAndComponentAnalysis_ShouldAppend()
        {
            var builder = new ClientBuilder()
                .WithFeatureComponentAnalysis()
                .WithFeatureIanaTimeZone();

            Assert.AreEqual("component-analysis,iana-timezone", GetCustomQueries(builder)["features"]);
        }

        [Test]
        public void TestWithSender_WrapsWithMiddlewareChain()
        {
            var capturingSender = new RequestCapturingSender();
            var client = new ClientBuilder("test-id", "test-token")
                .WithSender(capturingSender)
                .WithSerializer(new FakeSerializer(null))
                .BuildUsStreetApiClient();

            client.Send(new USStreetApi.Lookup("1 Rosedale"));

            var url = capturingSender.Request.GetUrl();
            Assert.That(url, Does.Contain("us-street.api.smarty.com"));
            Assert.That(url, Does.Contain("auth-id=test-id"));
            Assert.That(url, Does.Contain("auth-token=test-token"));
        }
    }
}
