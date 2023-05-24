namespace SmartyStreets.USStreetApi
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
            var RawJSON = @"[
            {
                ""input_id"": ""1234"",
                ""input_index"": 0,
                ""candidate_index"": 4242,
                ""addressee"": ""John Smith"",
                ""delivery_line_1"": ""3214 N University Ave # 409"",
                ""delivery_line_2"": ""blah blah"",
                ""last_line"": ""Provo UT 84604-4405"",
                ""delivery_point_barcode"": ""846044405140"",
                ""smarty_key"": ""1750774478"",
                ""components"": {
                    ""primary_number"": ""3214"",
                    ""street_predirection"": ""N"",
                    ""street_postdirection"": ""Q"",
                    ""street_name"": ""University"",
                    ""street_suffix"": ""Ave"",
                    ""secondary_number"": ""409"",
                    ""secondary_designator"": ""#"",
                    ""extra_secondary_number"": ""410"",
                    ""extra_secondary_designator"": ""Apt"",
                    ""pmb_number"": ""411"",
                    ""pmb_designator"": ""Box"",
                    ""city_name"": ""Provo"",
                    ""default_city_name"": ""Provo"",
                    ""state_abbreviation"": ""UT"",
                    ""zipcode"": ""84604"",
                    ""plus4_code"": ""4405"",
                    ""delivery_point"": ""14"",
                    ""delivery_point_check_digit"": ""0"",
                    ""urbanization"": ""urbanization""
                },
                ""metadata"": {
                    ""record_type"": ""S"",
                    ""zip_type"": ""Standard"",
                    ""county_fips"": ""49049"",
                    ""county_name"": ""Utah"",
                    ""carrier_route"": ""C016"",
                    ""congressional_district"": ""03"",
                    ""building_default_indicator"": ""hi"",
                    ""rdi"": ""Commercial"",
                    ""elot_sequence"": ""0016"",
                    ""elot_sort"": ""A"",
                    ""latitude"": 40.27658,
                    ""longitude"": -111.65759,
                    ""precision"": ""Zip9"",
                    ""time_zone"": ""Mountain"",
                    ""utc_offset"": -7,
                    ""dst"": true,
                    ""ews_match"": true
                },
                ""analysis"": {
                    ""dpv_match_code"": ""S"",
                    ""dpv_footnotes"": ""AACCRR"",
                    ""dpv_cmra"": ""Y"",
                    ""dpv_vacant"": ""N"",
                    ""dpv_no_stat"": ""N"",
                    ""active"": ""Y"",
                    ""footnotes"": ""footnotes"",
                    ""lacslink_code"": ""lacslink_code"",
                    ""lacslink_indicator"": ""lacslink_indicator"",
                    ""suitelink_match"": true,
                    ""enhanced_match"": ""enhanced_match""
                }
            }
            ]";
    
            var Bytes = Encoding.ASCII.GetBytes(RawJSON);
            var Stream = new MemoryStream(Bytes);
            
            var actual = nativeserializer.Deserialize<List<Candidate>>(Stream);
            var components = actual[0].Components;
            var metadata = actual[0].Metadata;
            var analysis = actual[0].Analysis;
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(0, actual[0].InputIndex);
            Assert.AreEqual(4242, actual[0].CandidateIndex);
            Assert.AreEqual("1234", actual[0].InputId);
            Assert.AreEqual("John Smith", actual[0].Addressee);
            Assert.AreEqual("3214 N University Ave # 409", actual[0].DeliveryLine1);
            Assert.AreEqual("blah blah", actual[0].DeliveryLine2);
            Assert.AreEqual("Provo UT 84604-4405", actual[0].LastLine);
            Assert.AreEqual("846044405140", actual[0].DeliveryPointBarcode);
            Assert.AreEqual("1750774478", actual[0].SmartyKey);
            Assert.AreEqual("3214", components.PrimaryNumber);
            Assert.AreEqual("N", components.StreetPredirection);
            Assert.AreEqual("Q", components.StreetPostdirection);
            Assert.AreEqual("University", components.StreetName);
            Assert.AreEqual("Ave", components.StreetSuffix);
            Assert.AreEqual("409", components.SecondaryNumber);
            Assert.AreEqual("#", components.SecondaryDesignator);
            Assert.AreEqual("410", components.ExtraSecondaryNumber);
            Assert.AreEqual("Apt", components.ExtraSecondaryDesignator);
            Assert.AreEqual("411", components.PmbNumber);
            Assert.AreEqual("Box", components.PmbDesignator);
            Assert.AreEqual("Provo", components.CityName);
            Assert.AreEqual("Provo", components.DefaultCityName);
            Assert.AreEqual("UT", components.State);
            Assert.AreEqual("84604", components.ZipCode);
            Assert.AreEqual("4405", components.Plus4Code);
            Assert.AreEqual("14", components.DeliveryPoint);
            Assert.AreEqual("0", components.DeliveryPointCheckDigit);
            Assert.AreEqual("urbanization", components.Urbanization);
            Assert.AreEqual("S", metadata.RecordType);
            Assert.AreEqual("Standard", metadata.ZipType);
            Assert.AreEqual("49049", metadata.CountyFips);
            Assert.AreEqual("Utah", metadata.CountyName);
            Assert.AreEqual("C016", metadata.CarrierRoute);
            Assert.AreEqual("03", metadata.CongressionalDistrict);
            Assert.AreEqual("hi", metadata.BuildingDefaultIndicator);
            Assert.AreEqual("Commercial", metadata.Rdi);
            Assert.AreEqual("0016", metadata.ElotSequence);
            Assert.AreEqual("A", metadata.ElotSort);
            Assert.AreEqual(40.27658, metadata.Latitude);
            Assert.AreEqual(-111.65759, metadata.Longitude);
            Assert.AreEqual("Zip9", metadata.Precision);
            Assert.AreEqual("Mountain", metadata.TimeZone);
            Assert.AreEqual(-7, metadata.UtcOffset);
            Assert.AreEqual(true, metadata.ObeysDst);
            Assert.AreEqual(true, metadata.IsEwsMatch);
            Assert.AreEqual("S", analysis.DpvMatchCode);
            Assert.AreEqual("AACCRR", analysis.DpvFootnotes);
            Assert.AreEqual("Y", analysis.Cmra);
            Assert.AreEqual("N", analysis.Vacant);
            Assert.AreEqual("N", analysis.NoStat);
            Assert.AreEqual("Y", analysis.Active);
            Assert.AreEqual("footnotes", analysis.Footnotes);
            Assert.AreEqual("lacslink_code", analysis.LacsLinkCode);
            Assert.AreEqual("lacslink_indicator", analysis.LacsLinkIndicator);
            Assert.AreEqual(true, analysis.IsSuiteLinkMatch);
            Assert.AreEqual("enhanced_match", analysis.EnhancedMatch);
        }
    }

}