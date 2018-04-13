using System.IO;
using System.Text;
using NUnit.Framework;
using SmartyStreets.USAutocompleteApi;

namespace SmartyStreets.USAutocomplete
{
    [TestFixture]
    public class SuggestionTests
    {
        private readonly NativeSerializer nativeSerializer = new NativeSerializer();
        private const string responsePayload = "{\"suggestions\":[" +
                                               "{\"text\":\"1\",\"street_line\":\"2\",\"city\":\"3\",\"state\":\"4\"}]}";

        [Test]
        public void TestAllFieldGetFilledInCorrectly()
        {
            using (var payloadStream = new MemoryStream(Encoding.ASCII.GetBytes(responsePayload)))
            {
                var result = this.nativeSerializer.Deserialize<Result>(payloadStream) ?? new Result();

                Assert.NotNull(result.Suggestions[0]);
                Assert.AreEqual("1", result.Suggestions[0].Text);
                Assert.AreEqual("2", result.Suggestions[0].StreetLine);
                Assert.AreEqual("3", result.Suggestions[0].City);
                Assert.AreEqual("4", result.Suggestions[0].State);
            }
        }
    }
}