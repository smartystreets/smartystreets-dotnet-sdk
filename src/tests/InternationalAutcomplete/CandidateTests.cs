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
                        ""entries"": ""3"",
                        ""address_text"": ""my_fun_street"",
                        ""address_id"": ""my_address_id""

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
            Assert.AreEqual("3", actual[1].Entries);
            Assert.AreEqual("my_fun_street", actual[1].AddressText);
            Assert.AreEqual("my_address_id", actual[1].AddressID);
        }
    }

}