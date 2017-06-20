using System.IO;
using System.Text;
using NUnit.Framework;
using SmartyStreets.InternationalStreetApi;

namespace SmartyStreets.InternationalStreet
{
    [TestFixture]
    public class CandidateTest
    {
        [Test]
        public void TestAllFieldsFilledCorrectly()
        {
            const string responsePayload = "[{\"organization\":\"1\",\"address1\":\"2\",\"address2\":\"3\"," +
                                           "\"address3\":\"4\",\"address4\":\"5\",\"address5\":\"6\",\"address6\":\"7\",\"address7\":\"8\"," +
                                           "\"address8\":\"9\",\"address9\":\"10\",\"address10\":\"11\",\"address11\":\"12\",\"address12\":\"13\"," +
                                           "\"components\":{\"country_iso_3\":\"14\",\"super_administrative_area\":\"15\"," +
                                           "\"administrative_area\":\"16\",\"sub_administrative_area\":\"17\",\"dependent_locality\":\"18\"," +
                                           "\"dependent_locality_name\":\"19\",\"double_dependent_locality\":\"20\",\"locality\":\"21\"," +
                                           "\"postal_code\":\"22\",\"postal_code_short\":\"23\",\"postal_code_extra\":\"24\"," +
                                           "\"premise\":\"25\",\"premise_extra\":\"26\",\"premise_number\":\"27\",\"premise_type\":\"28\"," +
                                           "\"thoroughfare\":\"29\",\"thoroughfare_predirection\":\"30\",\"thoroughfare_postdirection\":\"31\"," +
                                           "\"thoroughfare_name\":\"32\",\"thoroughfare_trailing_type\":\"33\",\"thoroughfare_type\":\"34\"," +
                                           "\"dependent_thoroughfare\":\"35\",\"dependent_thoroughfare_predirection\":\"36\"," +
                                           "\"dependent_thoroughfare_postdirection\":\"37\",\"dependent_thoroughfare_name\":\"38\"," +
                                           "\"dependent_thoroughfare_trailing_type\":\"39\",\"dependent_thoroughfare_type\":\"40\"," +
                                           "\"building\":\"41\",\"building_leading_type\":\"42\",\"building_name\":\"43\"," +
                                           "\"building_trailing_type\":\"44\",\"sub_building_type\":\"45\",\"sub_building_number\":\"46\"," +
                                           "\"sub_building_name\":\"47\",\"sub_building\":\"48\",\"post_box\":\"49\",\"post_box_type\":\"50\"," +
                                           "\"post_box_number\":\"51\"},\"metadata\":{\"latitude\":52.0,\"longitude\":53.0," +
                                           "\"geocode_precision\":\"54\",\"max_geocode_precision\":\"55\"}," +
                                           "\"analysis\":{\"verification_status\":\"56\",\"address_precision\":\"57\",\"max_address_precision\":\"58\"}}]";

            var nativeSerializer = new NativeSerializer();
            Candidate candidate;
            using (var payloadStream = new MemoryStream(Encoding.ASCII.GetBytes(responsePayload)))
            {
                var candidates = nativeSerializer.Deserialize<Candidate[]>(payloadStream) ?? new Candidate[0];
                candidate = candidates[0];
            }

            #region [ Candidate ]
            Assert.AreEqual("1", candidate.Organization);
            Assert.AreEqual("2", candidate.Address1);
            Assert.AreEqual("3", candidate.Address2);
            Assert.AreEqual("4", candidate.Address3);
            Assert.AreEqual("5", candidate.Address4);
            Assert.AreEqual("6", candidate.Address5);
            Assert.AreEqual("7", candidate.Address6);
            Assert.AreEqual("8", candidate.Address7);
            Assert.AreEqual("9", candidate.Address8);
            Assert.AreEqual("10", candidate.Address9);
            Assert.AreEqual("11", candidate.Address10);
            Assert.AreEqual("12", candidate.Address11);
            Assert.AreEqual("13", candidate.Address12);
            #endregion
            
            #region [ Components ]
            var components = candidate.Components;
            Assert.IsNotNull(components);
            Assert.AreEqual("14", components.CountryIso3);
            Assert.AreEqual("15", components.SuperAdministrativeArea);
            Assert.AreEqual("16", components.AdministrativeArea);
            Assert.AreEqual("17", components.SubAdministrativeArea);
            Assert.AreEqual("18", components.DependentLocality);
            Assert.AreEqual("19", components.DependentLocalityName);
            Assert.AreEqual("20", components.DoubleDependentLocality);
            Assert.AreEqual("21", components.Locality);
            Assert.AreEqual("22", components.PostalCode);
            Assert.AreEqual("23", components.PostalCodeShort);
            Assert.AreEqual("24", components.PostalCodeExtra);
            Assert.AreEqual("25", components.Premise);
            Assert.AreEqual("26", components.PremiseExtra);
            Assert.AreEqual("27", components.PremiseNumber);
            Assert.AreEqual("28", components.PremiseType);
            Assert.AreEqual("29", components.Thoroughfare);
            Assert.AreEqual("30", components.ThoroughfarePredirection);
            Assert.AreEqual("31", components.ThoroughfarePostdirection);
            Assert.AreEqual("32", components.ThoroughfareName);
            Assert.AreEqual("33", components.ThoroughfareTrailingType);
            Assert.AreEqual("34", components.ThoroughfareType);
            Assert.AreEqual("35", components.DependentThoroughfare);
            Assert.AreEqual("36", components.DependentThoroughfarePredirection);
            Assert.AreEqual("37", components.DependentThoroughfarePostdirection);
            Assert.AreEqual("38", components.DependentThoroughfareName);
            Assert.AreEqual("39", components.DependentThoroughfareTrailingType);
            Assert.AreEqual("40", components.DependentThoroughfareType);
            Assert.AreEqual("41", components.Building);
            Assert.AreEqual("42", components.BuildingLeadingType);
            Assert.AreEqual("43", components.BuildingName);
            Assert.AreEqual("44", components.BuildingTrailingType);
            Assert.AreEqual("45", components.SubBuildingType);
            Assert.AreEqual("46", components.SubBuildingNumber);
            Assert.AreEqual("47", components.SubBuildingName);
            Assert.AreEqual("48", components.SubBuilding);
            Assert.AreEqual("49", components.PostBox);
            Assert.AreEqual("50", components.PostBoxType);
            Assert.AreEqual("51", components.PostBoxNumber);
            #endregion

            #region [ Metadata ]
            var metadata = candidate.Metadata;
            Assert.IsNotNull(metadata);
            Assert.AreEqual(52, metadata.Latitude, 0.001);
            Assert.AreEqual(53, metadata.Longitude, 0.001);
            Assert.AreEqual("54", metadata.GeocodePrecision);
            Assert.AreEqual("55", metadata.MaxGeocodePrecision);
            #endregion
            
            #region [ Analysis ]
            var analysis = candidate.Analysis;
            Assert.IsNotNull(analysis);
            Assert.AreEqual("56", analysis.VerificationStatus);
            Assert.AreEqual("57", analysis.AddressPrecision);
            Assert.AreEqual("58", analysis.MaxAddressPrecision);
            #endregion
        }

    }
}