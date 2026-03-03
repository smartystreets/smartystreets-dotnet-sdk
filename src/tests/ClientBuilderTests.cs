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
        public void TestWithFeatureIANATimeZone()
        {
            var builder = new ClientBuilder().WithFeatureIANATimeZone();

            Assert.AreEqual("iana-timezone", GetCustomQueries(builder)["features"]);
        }

        [Test]
        public void TestWithFeatureIANATimeZoneAndComponentAnalysis_ShouldAppend()
        {
            var builder = new ClientBuilder()
                .WithFeatureComponentAnalysis()
                .WithFeatureIANATimeZone();

            Assert.AreEqual("component-analysis,iana-timezone", GetCustomQueries(builder)["features"]);
        }
    }
}
