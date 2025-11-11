namespace SmartyStreets.InternationalStreet
{
	using System.IO;
	using System.Text;
	using InternationalStreetApi;
	using NUnit.Framework;

	[TestFixture]
	public class CandidateTest
	{
		[Test]
		public void TestAllFieldsFilledCorrectly()
		{
			const string responsePayload = "[{\"input_id\":\"1234\",\"organization\":\"1\",\"address1\":\"2\",\"address2\":\"3\"," +
			                               "\"address3\":\"4\",\"address4\":\"5\",\"address5\":\"6\",\"address6\":\"7\",\"address7\":\"8\"," +
			                               "\"address8\":\"9\",\"address9\":\"10\",\"address10\":\"11\",\"address11\":\"12\",\"address12\":\"13\"," +
			                               "\"components\":{\"country_iso_3\":\"14\",\"super_administrative_area\":\"15\"," +
			                               "\"administrative_area\":\"16\",\"administrative_area_short\":\"16.1\",\"administrative_area_long\":\"16.2\"," +
			                               "\"sub_administrative_area\":\"17\",\"dependent_locality\":\"18\"," +
			                               "\"dependent_locality_name\":\"19\",\"double_dependent_locality\":\"20\",\"locality\":\"21\"," +
			                               "\"postal_code\":\"22\",\"postal_code_short\":\"23\",\"postal_code_extra\":\"24\"," +
			                               "\"premise\":\"25\",\"premise_extra\":\"26\",\"premise_number\":\"27\",\"premise_number_prefix\":\"27.1\",\"premise_type\":\"28\"," +
			                               "\"thoroughfare\":\"29\",\"thoroughfare_predirection\":\"30\",\"thoroughfare_postdirection\":\"31\"," +
			                               "\"thoroughfare_name\":\"32\",\"thoroughfare_trailing_type\":\"33\",\"thoroughfare_type\":\"34\"," +
			                               "\"dependent_thoroughfare\":\"35\",\"dependent_thoroughfare_predirection\":\"36\"," +
			                               "\"dependent_thoroughfare_postdirection\":\"37\",\"dependent_thoroughfare_name\":\"38\"," +
			                               "\"dependent_thoroughfare_trailing_type\":\"39\",\"dependent_thoroughfare_type\":\"40\"," +
			                               "\"building\":\"41\",\"building_leading_type\":\"42\",\"building_name\":\"43\"," +
			                               "\"building_trailing_type\":\"44\",\"sub_building_type\":\"45\",\"sub_building_number\":\"46\"," +
			                               "\"sub_building_name\":\"47\",\"sub_building\":\"48\",\"level_type\":\"48.1\",\"level_number\":\"48.2\"," +
			                               "\"post_box\":\"49\",\"post_box_type\":\"50\"," +
			                               "\"post_box_number\":\"51\",\"additional_content\":\"112\",\"delivery_installation\":\"113\"," +
                						   "\"delivery_installation_type\":\"114\",\"delivery_installation_qualifier_name\":\"115\",\"route\":\"116\"," +
               							   "\"route_number\":\"117\",\"route_type\":\"118\"},\"metadata\":{\"latitude\":52.0,\"longitude\":53.0," +
			                               "\"geocode_precision\":\"54\",\"geocode_classification\":\"multiple-point-average\",\"max_geocode_precision\":\"55\",\"address_format\":\"56\",\"occupant_use\":\"56.1\"}," +
			                               "\"analysis\":{\"verification_status\":\"57\",\"address_precision\":\"58\",\"max_address_precision\":\"59\"," +
										   "\"changes\":{\"organization\":\"60\",\"address1\":\"61\",\"address2\":\"62\",\"address3\":\"63\"," +
			                               "\"address4\":\"64\",\"address5\":\"65\",\"address6\":\"66\",\"address7\":\"67\",\"address8\":\"68\"," +
			                               "\"address9\":\"69\",\"address10\":\"70\",\"address11\":\"71\",\"address12\":\"72\",\"components\":{" +
			                               "\"super_administrative_area\":\"73\"," +
			                               "\"administrative_area\":\"74\",\"administrative_area_short\":\"74.1\",\"administrative_area_long\":\"74.2\"," +
			                               "\"sub_administrative_area\":\"75\"," +
			                               "\"building\":\"76\",\"dependent_locality\":\"77\",\"dependent_locality_name\":\"78\"," +
			                               "\"double_dependent_locality\":\"79\",\"country_iso_3\":\"80\",\"locality\":\"81\",\"postal_code\":\"82\"," +
			                               "\"postal_code_short\":\"83\",\"postal_code_extra\":\"84\",\"premise\":\"85\",\"premise_extra\":\"86\"," +
			                               "\"premise_number\":\"87\",\"premise_type\":\"88\",\"premise_number_prefix\":\"89\",\"thoroughfare\":\"90\"," +
			                               "\"thoroughfare_predirection\":\"91\",\"thoroughfare_postdirection\":\"92\",\"thoroughfare_name\":\"93\"," +
			                               "\"thoroughfare_trailing_type\":\"94\",\"thoroughfare_type\":\"95\",\"dependent_thoroughfare\":\"96\"," +
			                               "\"dependent_thoroughfare_predirection\":\"97\",\"dependent_thoroughfare_postdirection\":\"98\"," +
			                               "\"dependent_thoroughfare_name\":\"99\",\"dependent_thoroughfare_trailing_type\":\"100\"," +
			                               "\"dependent_thoroughfare_type\":\"101\",\"building_leading_type\":\"102\"," +
			                               "\"building_name\":\"103\",\"building_trailing_type\":\"104\",\"sub_building_type\":\"105\"," +
			                               "\"sub_building_number\":\"106\",\"sub_building_name\":\"107\"," +
			                               "\"sub_building\":\"108\",\"level_type\":\"108.1\",\"level_number\":\"108.2\"," +
			                               "\"post_box\":\"109\",\"post_box_type\":\"110\",\"post_box_number\":\"111\"}}}}]";

			var nativeSerializer = new NativeSerializer();
			Candidate candidate;
			using (var payloadStream = new MemoryStream(Encoding.ASCII.GetBytes(responsePayload)))
			{
				var candidates = nativeSerializer.Deserialize<Candidate[]>(payloadStream) ?? new Candidate[0];
				candidate = candidates[0];
			}

			#region [ Candidate ]

			Assert.AreEqual("1234", candidate.InputId);
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
			Assert.AreEqual("16.1", components.AdministrativeAreaShort);
			Assert.AreEqual("16.2", components.AdministrativeAreaLong);
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
			Assert.AreEqual("27.1", components.PremiseNumberPrefix);
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
			Assert.AreEqual("48.1", components.LevelType);
			Assert.AreEqual("48.2", components.LevelNumber);
			Assert.AreEqual("49", components.PostBox);
			Assert.AreEqual("50", components.PostBoxType);
			Assert.AreEqual("51", components.PostBoxNumber);
			Assert.AreEqual("112", components.AdditionalContent);
			Assert.AreEqual("113", components.DeliveryInstallation);
			Assert.AreEqual("114", components.DeliveryInstallationType);
			Assert.AreEqual("115", components.DeliveryInstallationQualifierName);
			Assert.AreEqual("116", components.Route);
			Assert.AreEqual("117", components.RouteNumber);
			Assert.AreEqual("118", components.RouteType);

			#endregion

			#region [ Metadata ]

			var metadata = candidate.Metadata;
			Assert.IsNotNull(metadata);
			Assert.AreEqual(52, metadata.Latitude, 0.001);
			Assert.AreEqual(53, metadata.Longitude, 0.001);
			Assert.AreEqual("54", metadata.GeocodePrecision);
			Assert.AreEqual("multiple-point-average", metadata.GeocodeClassification);
			Assert.AreEqual("55", metadata.MaxGeocodePrecision);
			Assert.AreEqual("56", metadata.AddressFormat);
			Assert.AreEqual("56.1", metadata.OccupantUse);

			#endregion

			#region [ Analysis ]

			var analysis = candidate.Analysis;
			Assert.IsNotNull(analysis);
			Assert.AreEqual("57", analysis.VerificationStatus);
			Assert.AreEqual("58", analysis.AddressPrecision);
			Assert.AreEqual("59", analysis.MaxAddressPrecision);
			
			#region [ Changes ]

			var changes = analysis.Changes;
			Assert.IsNotNull(changes);
			Assert.AreEqual("60", changes.Organization);
			Assert.AreEqual("61", changes.Address1);
			Assert.AreEqual("62", changes.Address2);
			Assert.AreEqual("63", changes.Address3);
			Assert.AreEqual("64", changes.Address4);
			Assert.AreEqual("65", changes.Address5);
			Assert.AreEqual("66", changes.Address6);
			Assert.AreEqual("67", changes.Address7);
			Assert.AreEqual("68", changes.Address8);
			Assert.AreEqual("69", changes.Address9);
			Assert.AreEqual("70", changes.Address10);
			Assert.AreEqual("71", changes.Address11);
			Assert.AreEqual("72", changes.Address12);
			
			#region [ Changes.Components ]

			var ccomponents = changes.Components;
			Assert.IsNotNull(ccomponents);
			Assert.AreEqual("73", ccomponents.SuperAdministrativeArea);
			Assert.AreEqual("74", ccomponents.AdministrativeArea);
			Assert.AreEqual("74.1", ccomponents.AdministrativeAreaShort);
			Assert.AreEqual("74.2", ccomponents.AdministrativeAreaLong);
			Assert.AreEqual("75", ccomponents.SubAdministrativeArea);
			Assert.AreEqual("76", ccomponents.Building);
			Assert.AreEqual("77", ccomponents.DependentLocality);
			Assert.AreEqual("78", ccomponents.DependentLocalityName);
			Assert.AreEqual("79", ccomponents.DoubleDependentLocality);
			Assert.AreEqual("80", ccomponents.CountryIso3);
			Assert.AreEqual("81", ccomponents.Locality);
			Assert.AreEqual("82", ccomponents.PostalCode);
			Assert.AreEqual("83", ccomponents.PostalCodeShort);
			Assert.AreEqual("84", ccomponents.PostalCodeExtra);
			Assert.AreEqual("85", ccomponents.Premise);
			Assert.AreEqual("86", ccomponents.PremiseExtra);
			Assert.AreEqual("87", ccomponents.PremiseNumber);
			Assert.AreEqual("88", ccomponents.PremiseType);
			Assert.AreEqual("89", ccomponents.PremiseNumberPrefix);
			Assert.AreEqual("90", ccomponents.Thoroughfare);
			Assert.AreEqual("91", ccomponents.ThoroughfarePredirection);
			Assert.AreEqual("92", ccomponents.ThoroughfarePostdirection);
			Assert.AreEqual("93", ccomponents.ThoroughfareName);
			Assert.AreEqual("94", ccomponents.ThoroughfareTrailingType);
			Assert.AreEqual("95", ccomponents.ThoroughfareType);
			Assert.AreEqual("96", ccomponents.DependentThoroughfare);
			Assert.AreEqual("97", ccomponents.DependentThoroughfarePredirection);
			Assert.AreEqual("98", ccomponents.DependentThoroughfarePostdirection);
			Assert.AreEqual("99", ccomponents.DependentThoroughfareName);
			Assert.AreEqual("100", ccomponents.DependentThoroughfareTrailingType);
			Assert.AreEqual("101", ccomponents.DependentThoroughfareType);
			Assert.AreEqual("102", ccomponents.BuildingLeadingType);
			Assert.AreEqual("103", ccomponents.BuildingName);
			Assert.AreEqual("104", ccomponents.BuildingTrailingType);
			Assert.AreEqual("105", ccomponents.SubBuildingType);
			Assert.AreEqual("106", ccomponents.SubBuildingNumber);
			Assert.AreEqual("107", ccomponents.SubBuildingName);
			Assert.AreEqual("108", ccomponents.SubBuilding);
			Assert.AreEqual("108.1", ccomponents.LevelType);
			Assert.AreEqual("108.2", ccomponents.LevelNumber);
			Assert.AreEqual("109", ccomponents.PostBox);
			Assert.AreEqual("110", ccomponents.PostBoxType);
			Assert.AreEqual("111", ccomponents.PostBoxNumber);

			#endregion

			#endregion

			#endregion
		}
	}
}