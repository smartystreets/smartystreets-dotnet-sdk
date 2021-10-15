using SmartyStreets.InternationalAutocompleteApi;

namespace SmartyStreets.InternationalAutcompleteApi
{
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using NUnit.Framework;

    [TestFixture]
    public class CandidateTests
    {
        [Test]
        public void TestFullJSONDeserialization()
        {
            var nativeserializer = new NativeSerializer();
            var RawJSON = @"{
	            ""candidates"": [
                    {
                        ""street"": ""12TH AV"",
                        ""locality"": ""OCEAN GROVE"",
                        ""administrative_area"": ""VIC"",
                        ""postal_code"": ""3226"",
                        ""country_iso3"": ""AUS""
                    },
                    {
                        ""street"": ""TWELFTH AV"",
                        ""locality"": ""EDEN PARK"",
                        ""administrative_area"": ""VIC"",
                        ""postal_code"": ""3757"",
                        ""country_iso3"": ""AUS""
                    }
                ]
            }";



            var Bytes = Encoding.ASCII.GetBytes(RawJSON);
            var Stream = new MemoryStream(Bytes);
            
            var result = nativeserializer.Deserialize<Result>(Stream) ?? new Result();
            var actual = result.Candidates;
            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual("12TH AV", actual[0].Street);
            Assert.AreEqual("OCEAN GROVE", actual[0].Locality);
            Assert.AreEqual("VIC", actual[0].AdministrativeArea);
            Assert.AreEqual("3226", actual[0].PostalCode);
            Assert.AreEqual("AUS", actual[0].CountryISO3);
            Assert.AreEqual("TWELFTH AV", actual[1].Street);
            Assert.AreEqual("EDEN PARK", actual[1].Locality);
            Assert.AreEqual("VIC", actual[1].AdministrativeArea);
            Assert.AreEqual("3757", actual[1].PostalCode);
            Assert.AreEqual("AUS", actual[1].CountryISO3);
        }
    }

}