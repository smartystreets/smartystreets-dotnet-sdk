namespace SmartyStreets.USEnrichmentApi.ResultTypes.Property.Principal
{
    using System.Runtime.Serialization;

	[DataContract]
    public class Attributes
    {
        [DataMember(Name = "1st_floor_sqft")]
        public string FirstFloorSqft { get; set; }

        [DataMember(Name = "2nd_floor_sqft")]
        public string SecondFloorSqft { get; set; }

        [DataMember(Name = "acres")]
        public string Acres { get; set; }

        [DataMember(Name = "air_conditioner")]
        public string AirConditioner { get; set; }

        [DataMember(Name = "arbor_pergola")]
        public string ArborPergola { get; set; }

        [DataMember(Name = "assessed_improvement_percent")]
        public string AssessedImprovementPercent { get; set; }

        [DataMember(Name = "assessed_improvement_value")]
        public string AssessedImprovementValue { get; set; }

        [DataMember(Name = "assessed_land_value")]
        public string AssessedLandValue { get; set; }

        [DataMember(Name = "assessed_value")]
        public string AssessedValue { get; set; }

        [DataMember(Name = "assessor_last_update")]
        public string AssessorLastUpdate { get; set; }

        [DataMember(Name = "assessor_taxroll_update")]
        public string AssessorTaxrollUpdate { get; set; }

        [DataMember(Name = "attic_area")]
        public string AtticArea { get; set; }

        [DataMember(Name = "attic_flag")]
        public string AtticFlag { get; set; }

        [DataMember(Name = "balcony")]
        public string Balcony { get; set; }

        [DataMember(Name = "balcony_area")]
        public string BalconyArea { get; set; }

        [DataMember(Name = "basement_sqft")]
        public string BasementSqft { get; set; }

        [DataMember(Name = "basement_sqft_finished")]
        public string BasementSqftFinished { get; set; }

        [DataMember(Name = "basement_sqft_unfinished")]
        public string BasementSqftUnfinished { get; set; }

        [DataMember(Name = "bath_house")]
        public string BathHouse { get; set; }

        [DataMember(Name = "bath_house_sqft")]
        public string BathHouseSqft { get; set; }

        [DataMember(Name = "bathrooms_partial")]
        public string BathroomsPartial { get; set; }

        [DataMember(Name = "bathrooms_total")]
        public string BathroomsTotal { get; set; }

        [DataMember(Name = "bedrooms")]
        public string Bedrooms { get; set; }

        [DataMember(Name = "block1")]
        public string Block1 { get; set; }

        [DataMember(Name = "block2")]
        public string Block2 { get; set; }

        [DataMember(Name = "boat_access")]
        public string BoatAccess { get; set; }

        [DataMember(Name = "boat_house")]
        public string BoatHouse { get; set; }

        [DataMember(Name = "boat_house_sqft")]
        public string BoatHouseSqft { get; set; }

        [DataMember(Name = "boat_lift")]
        public string BoatLift { get; set; }

        [DataMember(Name = "bonus_room")]
        public string BonusRoom { get; set; }

        [DataMember(Name = "breakfast_nook")]
        public string BreakfastNook { get; set; }

        [DataMember(Name = "breezeway")]
        public string Breezeway { get; set; }

        [DataMember(Name = "building_definition_code")]
        public string BuildingDefinitionCode { get; set; }

        [DataMember(Name = "building_sqft")]
        public string BuildingSqft { get; set; }

        [DataMember(Name = "cabin")]
        public string Cabin { get; set; }

        [DataMember(Name = "cabin_sqft")]
        public string CabinSqft { get; set; }

        [DataMember(Name = "canopy")]
        public string Canopy { get; set; }

        [DataMember(Name = "canopy_sqft")]
        public string CanopySqft { get; set; }

        [DataMember(Name = "carport")]
        public string Carport { get; set; }

        [DataMember(Name = "carport_sqft")]
        public string CarportSqft { get; set; }

        [DataMember(Name = "cbsa_code")]
        public string CbsaCode { get; set; }

        [DataMember(Name = "cbsa_name")]
        public string CbsaName { get; set; }

        [DataMember(Name = "cellar")]
        public string Cellar { get; set; }

        [DataMember(Name = "census_block")]
        public string CensusBlock { get; set; }

        [DataMember(Name = "census_block_group")]
        public string CensusBlockGroup { get; set; }

        [DataMember(Name = "census_fips_place_code")]
        public string CensusFipsPlaceCode { get; set; }

        [DataMember(Name = "census_tract")]
        public string CensusTract { get; set; }

        [DataMember(Name = "central_vacuum")]
        public string CentralVacuum { get; set; }

        [DataMember(Name = "code_title_company")]
        public string CodeTitleCompany { get; set; }

        [DataMember(Name = "combined_statistical_area")]
        public string CombinedStatisticalArea { get; set; }

        [DataMember(Name = "community_rec")]
        public string CommunityRec { get; set; }

        [DataMember(Name = "company_flag")]
        public string CompanyFlag { get; set; }

        [DataMember(Name = "congressional_district")]
        public string CongressionalDistrict { get; set; }

        [DataMember(Name = "construction_type")]
        public string ConstructionType { get; set; }

        [DataMember(Name = "contact_city")]
        public string ContactCity { get; set; }

        [DataMember(Name = "contact_crrt")]
        public string ContactCrrt { get; set; }

        [DataMember(Name = "contact_full_address")]
        public string ContactFullAddress { get; set; }

        [DataMember(Name = "contact_house_number")]
        public string ContactHouseNumber { get; set; }

        [DataMember(Name = "contact_mail_info_format")]
        public string ContactMailInfoFormat { get; set; }

        [DataMember(Name = "contact_mail_info_privacy")]
        public string ContactMailInfoPrivacy { get; set; }

        [DataMember(Name = "contact_mailing_county")]
        public string ContactMailingCounty { get; set; }

        [DataMember(Name = "contact_mailing_fips")]
        public string ContactMailingFips { get; set; }

        [DataMember(Name = "contact_post_direction")]
        public string ContactPostDirection { get; set; }

        [DataMember(Name = "contact_pre_direction")]
        public string ContactPreDirection { get; set; }

        [DataMember(Name = "contact_state")]
        public string ContactState { get; set; }

        [DataMember(Name = "contact_street_name")]
        public string ContactStreetName { get; set; }

        [DataMember(Name = "contact_suffix")]
        public string ContactSuffix { get; set; }

        [DataMember(Name = "contact_unit_designator")]
        public string ContactUnitDesignator { get; set; }

        [DataMember(Name = "contact_value")]
        public string ContactValue { get; set; }

        [DataMember(Name = "contact_zip")]
        public string ContactZip { get; set; }

        [DataMember(Name = "contact_zip4")]
        public string ContactZip4 { get; set; }

        [DataMember(Name = "courtyard")]
        public string Courtyard { get; set; }

        [DataMember(Name = "courtyard_area")]
        public string CourtyardArea { get; set; }

        [DataMember(Name = "deck")]
        public string Deck { get; set; }

        [DataMember(Name = "deck_area")]
        public string DeckArea { get; set; }

        [DataMember(Name = "deed_document_book")]
        public string DeedDocumentBook { get; set; }

        [DataMember(Name = "deed_document_number")]
        public string DeedDocumentNumber { get; set; }

        [DataMember(Name = "deed_document_page")]
        public string DeedDocumentPage { get; set; }

        [DataMember(Name = "deed_owner_first_name")]
        public string DeedOwnerFirstName { get; set; }

        [DataMember(Name = "deed_owner_first_name2")]
        public string DeedOwnerFirstName2 { get; set; }

        [DataMember(Name = "deed_owner_first_name3")]
        public string DeedOwnerFirstName3 { get; set; }

        [DataMember(Name = "deed_owner_first_name4")]
        public string DeedOwnerFirstName4 { get; set; }

        [DataMember(Name = "deed_owner_full_name")]
        public string DeedOwnerFullName { get; set; }

        [DataMember(Name = "deed_owner_full_name2")]
        public string DeedOwnerFullName2 { get; set; }

        [DataMember(Name = "deed_owner_full_name3")]
        public string DeedOwnerFullName3 { get; set; }

        [DataMember(Name = "deed_owner_full_name4")]
        public string DeedOwnerFullName4 { get; set; }

        [DataMember(Name = "deed_owner_last_name")]
        public string DeedOwnerLastName { get; set; }

        [DataMember(Name = "deed_owner_last_name2")]
        public string DeedOwnerLastName2 { get; set; }

        [DataMember(Name = "deed_owner_last_name3")]
        public string DeedOwnerLastName3 { get; set; }

        [DataMember(Name = "deed_owner_last_name4")]
        public string DeedOwnerLastName4 { get; set; }

        [DataMember(Name = "deed_owner_middle_name")]
        public string DeedOwnerMiddleName { get; set; }

        [DataMember(Name = "deed_owner_middle_name2")]
        public string DeedOwnerMiddleName2 { get; set; }

        [DataMember(Name = "deed_owner_middle_name3")]
        public string DeedOwnerMiddleName3 { get; set; }

        [DataMember(Name = "deed_owner_middle_name4")]
        public string DeedOwnerMiddleName4 { get; set; }

        [DataMember(Name = "deed_owner_suffix")]
        public string DeedOwnerSuffix { get; set; }

        [DataMember(Name = "deed_owner_suffix2")]
        public string DeedOwnerSuffix2 { get; set; }

        [DataMember(Name = "deed_owner_suffix3")]
        public string DeedOwnerSuffix3 { get; set; }

        [DataMember(Name = "deed_owner_suffix4")]
        public string DeedOwnerSuffix4 { get; set; }

        [DataMember(Name = "deed_sale_date")]
        public string DeedSaleDate { get; set; }

        [DataMember(Name = "deed_sale_price")]
        public string DeedSalePrice { get; set; }

        [DataMember(Name = "deed_transaction_id")]
        public string DeedTransactionId { get; set; }

        [DataMember(Name = "depth_linear_footage")]
        public string DepthLinearFootage { get; set; }

        [DataMember(Name = "disabled_tax_exemption")]
        public string DisabledTaxExemption { get; set; }

        [DataMember(Name = "document_type_description")]
        public string DocumentTypeDescription { get; set; }

        [DataMember(Name = "driveway_sqft")]
        public string DrivewaySqft { get; set; }

        [DataMember(Name = "driveway_type")]
        public string DrivewayType { get; set; }

        [DataMember(Name = "effective_year_built")]
        public string EffectiveYearBuilt { get; set; }

        [DataMember(Name = "elevation_feet")]
        public string ElevationFeet { get; set; }

        [DataMember(Name = "elevator")]
        public string Elevator { get; set; }

        [DataMember(Name = "equestrian_arena")]
        public string EquestrianArena { get; set; }

        [DataMember(Name = "escalator")]
        public string Escalator { get; set; }

        [DataMember(Name = "exercise_room")]
        public string ExerciseRoom { get; set; }

        [DataMember(Name = "exterior_walls")]
        public string ExteriorWalls { get; set; }

        [DataMember(Name = "family_room")]
        public string FamilyRoom { get; set; }

        [DataMember(Name = "fence")]
        public string Fence { get; set; }

        [DataMember(Name = "fence_area")]
        public string FenceArea { get; set; }

        [DataMember(Name = "fips_code")]
        public string FipsCode { get; set; }

        [DataMember(Name = "fire_resistance_code")]
        public string FireResistanceCode { get; set; }

        [DataMember(Name = "fire_sprinklers_flag")]
        public string FireSprinklersFlag { get; set; }

        [DataMember(Name = "fireplace")]
        public string Fireplace { get; set; }

        [DataMember(Name = "fireplace_number")]
        public string FireplaceNumber { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "first_name_2")]
        public string FirstName2 { get; set; }

        [DataMember(Name = "first_name_3")]
        public string FirstName3 { get; set; }

        [DataMember(Name = "first_name_4")]
        public string FirstName4 { get; set; }

        [DataMember(Name = "flooring")]
        public string Flooring { get; set; }

        [DataMember(Name = "foundation")]
        public string Foundation { get; set; }

        [DataMember(Name = "game_room")]
        public string GameRoom { get; set; }

        [DataMember(Name = "garage")]
        public string Garage { get; set; }

        [DataMember(Name = "garage_sqft")]
        public string GarageSqft { get; set; }

        [DataMember(Name = "gazebo")]
        public string Gazebo { get; set; }

        [DataMember(Name = "gazebo_sqft")]
        public string GazeboSqft { get; set; }

        [DataMember(Name = "golf_course")]
        public string GolfCourse { get; set; }

        [DataMember(Name = "grainery")]
        public string Grainery { get; set; }

        [DataMember(Name = "grainery_sqft")]
        public string GrainerySqft { get; set; }

        [DataMember(Name = "great_room")]
        public string GreatRoom { get; set; }

        [DataMember(Name = "greenhouse")]
        public string Greenhouse { get; set; }

        [DataMember(Name = "greenhouse_sqft")]
        public string GreenhouseSqft { get; set; }

        [DataMember(Name = "gross_sqft")]
        public string GrossSqft { get; set; }

        [DataMember(Name = "guesthouse")]
        public string Guesthouse { get; set; }

        [DataMember(Name = "guesthouse_sqft")]
        public string GuesthouseSqft { get; set; }

        [DataMember(Name = "handicap_accessibility")]
        public string HandicapAccessibility { get; set; }

        [DataMember(Name = "heat")]
        public string Heat { get; set; }

        [DataMember(Name = "heat_fuel_type")]
        public string HeatFuelType { get; set; }

        [DataMember(Name = "hobby_room")]
        public string HobbyRoom { get; set; }

        [DataMember(Name = "homeowner_tax_exemption")]
        public string HomeownerTaxExemption { get; set; }

        [DataMember(Name = "instrument_date")]
        public string InstrumentDate { get; set; }

        [DataMember(Name = "intercom_system")]
        public string IntercomSystem { get; set; }

        [DataMember(Name = "interest_rate_type_2")]
        public string InterestRateType2 { get; set; }

        [DataMember(Name = "interior_structure")]
        public string InteriorStructure { get; set; }

        [DataMember(Name = "kennel")]
        public string Kennel { get; set; }

        [DataMember(Name = "kennel_sqft")]
        public string KennelSqft { get; set; }

        [DataMember(Name = "land_use_code")]
        public string LandUseCode { get; set; }

        [DataMember(Name = "land_use_group")]
        public string LandUseGroup { get; set; }

        [DataMember(Name = "land_use_standard")]
        public string LandUseStandard { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "last_name_2")]
        public string LastName2 { get; set; }

        [DataMember(Name = "last_name_3")]
        public string LastName3 { get; set; }

        [DataMember(Name = "last_name_4")]
        public string LastName4 { get; set; }

        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "laundry")]
        public string Laundry { get; set; }

        [DataMember(Name = "lean_to")]
        public string LeanTo { get; set; }

        [DataMember(Name = "lean_to_sqft")]
        public string LeanToSqft { get; set; }

        [DataMember(Name = "legal_description")]
        public string LegalDescription { get; set; }

        [DataMember(Name = "legal_unit")]
        public string LegalUnit { get; set; }

        [DataMember(Name = "lender_address")]
        public string LenderAddress { get; set; }

        [DataMember(Name = "lender_address_2")]
        public string LenderAddress2 { get; set; }

        [DataMember(Name = "lender_city")]
        public string LenderCity { get; set; }

        [DataMember(Name = "lender_city_2")]
        public string LenderCity2 { get; set; }

        [DataMember(Name = "lender_code_2")]
        public string LenderCode2 { get; set; }

        [DataMember(Name = "lender_first_name")]
        public string LenderFirstName { get; set; }

        [DataMember(Name = "lender_first_name_2")]
        public string LenderFirstName2 { get; set; }

        [DataMember(Name = "lender_last_name")]
        public string LenderLastName { get; set; }

        [DataMember(Name = "lender_last_name_2")]
        public string LenderLastName2 { get; set; }

        [DataMember(Name = "lender_name")]
        public string LenderName { get; set; }

        [DataMember(Name = "lender_name_2")]
        public string LenderName2 { get; set; }

        [DataMember(Name = "lender_seller_carry_back")]
        public string LenderSellerCarryBack { get; set; }

        [DataMember(Name = "lender_seller_carry_back_2")]
        public string LenderSellerCarryBack2 { get; set; }

        [DataMember(Name = "lender_state")]
        public string LenderState { get; set; }

        [DataMember(Name = "lender_state_2")]
        public string LenderState2 { get; set; }

        [DataMember(Name = "lender_zip")]
        public string LenderZip { get; set; }

        [DataMember(Name = "lender_zip_2")]
        public string LenderZip2 { get; set; }

        [DataMember(Name = "lender_zip_extended")]
        public string LenderZipExtended { get; set; }

        [DataMember(Name = "lender_zip_extended_2")]
        public string LenderZipExtended2 { get; set; }

        [DataMember(Name = "loading_platform")]
        public string LoadingPlatform { get; set; }

        [DataMember(Name = "loading_platform_sqft")]
        public string LoadingPlatformSqft { get; set; }

        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }

        [DataMember(Name = "lot_1")]
        public string Lot1 { get; set; }

        [DataMember(Name = "lot_2")]
        public string Lot2 { get; set; }

        [DataMember(Name = "lot_3")]
        public string Lot3 { get; set; }

        [DataMember(Name = "lot_sqft")]
        public string LotSqft { get; set; }

        [DataMember(Name = "market_improvement_percent")]
        public string MarketImprovementPercent { get; set; }

        [DataMember(Name = "market_improvement_value")]
        public string MarketImprovementValue { get; set; }

        [DataMember(Name = "market_land_value")]
        public string MarketLandValue { get; set; }

        [DataMember(Name = "market_value_year")]
        public string MarketValueYear { get; set; }

        [DataMember(Name = "match_type")]
        public string MatchType { get; set; }

        [DataMember(Name = "media_room")]
        public string MediaRoom { get; set; }

        [DataMember(Name = "metro_division")]
        public string MetroDivision { get; set; }

        [DataMember(Name = "middle_name")]
        public string MiddleName { get; set; }

        [DataMember(Name = "middle_name_2")]
        public string MiddleName2 { get; set; }

        [DataMember(Name = "middle_name_3")]
        public string MiddleName3 { get; set; }

        [DataMember(Name = "middle_name_4")]
        public string MiddleName4 { get; set; }

        [DataMember(Name = "milkhouse")]
        public string Milkhouse { get; set; }

        [DataMember(Name = "milkhouse_sqft")]
        public string MilkhouseSqft { get; set; }

        [DataMember(Name = "minor_civil_division_code")]
        public string MinorCivilDivisionCode { get; set; }

        [DataMember(Name = "minor_civil_division_name")]
        public string MinorCivilDivisionName { get; set; }

        [DataMember(Name = "mobile_home_hookup")]
        public string MobileHomeHookup { get; set; }

        [DataMember(Name = "mortgage_amount")]
        public string MortgageAmount { get; set; }

        [DataMember(Name = "mortgage_amount_2")]
        public string MortgageAmount2 { get; set; }

        [DataMember(Name = "mortgage_due_date")]
        public string MortgageDueDate { get; set; }

        [DataMember(Name = "mortgage_due_date_2")]
        public string MortgageDueDate2 { get; set; }

        [DataMember(Name = "mortgage_interest_rate")]
        public string MortgageInterestRate { get; set; }

        [DataMember(Name = "mortgage_interest_rate_type")]
        public string MortgageInterestRateType { get; set; }

        [DataMember(Name = "mortgage_lender_code")]
        public string MortgageLenderCode { get; set; }

        [DataMember(Name = "mortgage_rate_2")]
        public string MortgageRate2 { get; set; }

        [DataMember(Name = "mortgage_recording_date")]
        public string MortgageRecordingDate { get; set; }

        [DataMember(Name = "mortgage_recording_date_2")]
        public string MortgageRecordingDate2 { get; set; }

        [DataMember(Name = "mortgage_term")]
        public string MortgageTerm { get; set; }

        [DataMember(Name = "mortgage_term_2")]
        public string MortgageTerm2 { get; set; }

        [DataMember(Name = "mortgage_term_type")]
        public string MortgageTermType { get; set; }

        [DataMember(Name = "mortgage_term_type_2")]
        public string MortgageTermType2 { get; set; }

        [DataMember(Name = "mortgage_type")]
        public string MortgageType { get; set; }

        [DataMember(Name = "mortgage_type_2")]
        public string MortgageType2 { get; set; }

        [DataMember(Name = "msa_code")]
        public string MsaCode { get; set; }

        [DataMember(Name = "msa_name")]
        public string MsaName { get; set; }

        [DataMember(Name = "mud_room")]
        public string MudRoom { get; set; }

        [DataMember(Name = "multi_parcel_flag")]
        public string MultiParcelFlag { get; set; }

        [DataMember(Name = "name_title_company")]
        public string NameTitleCompany { get; set; }

        [DataMember(Name = "neighborhood_code")]
        public string NeighborhoodCode { get; set; }

        [DataMember(Name = "number_of_buildings")]
        public string NumberOfBuildings { get; set; }

        [DataMember(Name = "office")]
        public string Office { get; set; }

        [DataMember(Name = "office_sqft")]
        public string OfficeSqft { get; set; }

        [DataMember(Name = "other_tax_exemption")]
        public string OtherTaxExemption { get; set; }

        [DataMember(Name = "outdoor_kitchen_fireplace")]
        public string OutdoorKitchenFireplace { get; set; }

        [DataMember(Name = "overhead_door")]
        public string OverheadDoor { get; set; }

        [DataMember(Name = "owner_full_name")]
        public string OwnerFullName { get; set; }

        [DataMember(Name = "owner_full_name_2")]
        public string OwnerFullName2 { get; set; }

        [DataMember(Name = "owner_full_name_3")]
        public string OwnerFullName3 { get; set; }

        [DataMember(Name = "owner_full_name_4")]
        public string OwnerFullName4 { get; set; }

        [DataMember(Name = "owner_occupancy_status")]
        public string OwnerOccupancyStatus { get; set; }

        [DataMember(Name = "ownership_transfer_date")]
        public string OwnershipTransferDate { get; set; }

        [DataMember(Name = "ownership_transfer_doc_number")]
        public string OwnershipTransferDocNumber { get; set; }

        [DataMember(Name = "ownership_transfer_transaction_id")]
        public string OwnershipTransferTransactionId { get; set; }

        [DataMember(Name = "ownership_type")]
        public string OwnershipType { get; set; }

        [DataMember(Name = "ownership_type_2")]
        public string OwnershipType2 { get; set; }

        [DataMember(Name = "ownership_vesting_relation_code")]
        public string OwnershipVestingRelationCode { get; set; }

        [DataMember(Name = "parcel_account_number")]
        public string ParcelAccountNumber { get; set; }

        [DataMember(Name = "parcel_map_book")]
        public string ParcelMapBook { get; set; }

        [DataMember(Name = "parcel_map_page")]
        public string ParcelMapPage { get; set; }

        [DataMember(Name = "parcel_number_alternate")]
        public string ParcelNumberAlternate { get; set; }

        [DataMember(Name = "parcel_number_formatted")]
        public string ParcelNumberFormatted { get; set; }

        [DataMember(Name = "parcel_number_previous")]
        public string ParcelNumberPrevious { get; set; }

        [DataMember(Name = "parcel_number_year_added")]
        public string ParcelNumberYearAdded { get; set; }

        [DataMember(Name = "parcel_number_year_change")]
        public string ParcelNumberYearChange { get; set; }

        [DataMember(Name = "parcel_raw_number")]
        public string ParcelRawNumber { get; set; }

        [DataMember(Name = "parcel_shell_record")]
        public string ParcelShellRecord { get; set; }

        [DataMember(Name = "parking_spaces")]
        public string ParkingSpaces { get; set; }

        [DataMember(Name = "patio_area")]
        public string PatioArea { get; set; }

        [DataMember(Name = "phase_name")]
        public string PhaseName { get; set; }

        [DataMember(Name = "plumbing_fixtures_count")]
        public string PlumbingFixturesCount { get; set; }

        [DataMember(Name = "pole_struct")]
        public string PoleStruct { get; set; }

        [DataMember(Name = "pole_struct_sqft")]
        public string PoleStructSqft { get; set; }

        [DataMember(Name = "pond")]
        public string Pond { get; set; }

        [DataMember(Name = "pool")]
        public string Pool { get; set; }

        [DataMember(Name = "pool_area")]
        public string PoolArea { get; set; }

        [DataMember(Name = "poolhouse")]
        public string Poolhouse { get; set; }

        [DataMember(Name = "poolhouse_sqft")]
        public string PoolhouseSqft { get; set; }

        [DataMember(Name = "porch")]
        public string Porch { get; set; }

        [DataMember(Name = "porch_area")]
        public string PorchArea { get; set; }

        [DataMember(Name = "poultry_house")]
        public string PoultryHouse { get; set; }

        [DataMember(Name = "poultry_house_sqft")]
        public string PoultryHouseSqft { get; set; }

        [DataMember(Name = "previous_assessed_value")]
        public string PreviousAssessedValue { get; set; }

        [DataMember(Name = "prior_sale_amount")]
        public string PriorSaleAmount { get; set; }

        [DataMember(Name = "prior_sale_date")]
        public string PriorSaleDate { get; set; }

        [DataMember(Name = "property_address_carrier_route_code")]
        public string PropertyAddressCarrierRouteCode { get; set; }

        [DataMember(Name = "property_address_city")]
        public string PropertyAddressCity { get; set; }

        [DataMember(Name = "property_address_full")]
        public string PropertyAddressFull { get; set; }

        [DataMember(Name = "property_address_house_number")]
        public string PropertyAddressHouseNumber { get; set; }

        [DataMember(Name = "property_address_post_direction")]
        public string PropertyAddressPostDirection { get; set; }

        [DataMember(Name = "property_address_pre_direction")]
        public string PropertyAddressPreDirection { get; set; }

        [DataMember(Name = "property_address_state")]
        public string PropertyAddressState { get; set; }

        [DataMember(Name = "property_address_street_name")]
        public string PropertyAddressStreetName { get; set; }

        [DataMember(Name = "property_address_street_suffix")]
        public string PropertyAddressStreetSuffix { get; set; }

        [DataMember(Name = "property_address_unit_designator")]
        public string PropertyAddressUnitDesignator { get; set; }

        [DataMember(Name = "property_address_unit_value")]
        public string PropertyAddressUnitValue { get; set; }

        [DataMember(Name = "property_address_zip_4")]
        public string PropertyAddressZip4 { get; set; }

        [DataMember(Name = "property_address_zipcode")]
        public string PropertyAddressZipcode { get; set; }

        [DataMember(Name = "publication_date")]
        public string PublicationDate { get; set; }

        [DataMember(Name = "quarter")]
        public string Quarter { get; set; }

        [DataMember(Name = "quarter_quarter")]
        public string QuarterQuarter { get; set; }

        [DataMember(Name = "quonset")]
        public string Quonset { get; set; }

        [DataMember(Name = "quonset_sqft")]
        public string QuonsetSqft { get; set; }

        [DataMember(Name = "range")]
        public string Range { get; set; }

        [DataMember(Name = "recording_date")]
        public string RecordingDate { get; set; }

        [DataMember(Name = "roof_cover")]
        public string RoofCover { get; set; }

        [DataMember(Name = "roof_frame")]
        public string RoofFrame { get; set; }

        [DataMember(Name = "rooms")]
        public string Rooms { get; set; }

        [DataMember(Name = "rv_parking")]
        public string RvParking { get; set; }

        [DataMember(Name = "safe_room")]
        public string SafeRoom { get; set; }

        [DataMember(Name = "sale_amount")]
        public string SaleAmount { get; set; }

        [DataMember(Name = "sale_date")]
        public string SaleDate { get; set; }

        [DataMember(Name = "sauna")]
        public string Sauna { get; set; }

        [DataMember(Name = "section")]
        public string Section { get; set; }

        [DataMember(Name = "security_alarm")]
        public string SecurityAlarm { get; set; }

        [DataMember(Name = "senior_tax_exemption")]
        public string SeniorTaxExemption { get; set; }

        [DataMember(Name = "sewer_type")]
        public string SewerType { get; set; }

        [DataMember(Name = "shed")]
        public string Shed { get; set; }

        [DataMember(Name = "shed_sqft")]
        public string ShedSqft { get; set; }

        [DataMember(Name = "silo")]
        public string Silo { get; set; }

        [DataMember(Name = "silo_sqft")]
        public string SiloSqft { get; set; }

        [DataMember(Name = "sitting_room")]
        public string SittingRoom { get; set; }

        [DataMember(Name = "situs_county")]
        public string SitusCounty { get; set; }

        [DataMember(Name = "situs_state")]
        public string SitusState { get; set; }

        [DataMember(Name = "sound_system")]
        public string SoundSystem { get; set; }

        [DataMember(Name = "sports_court")]
        public string SportsCourt { get; set; }

        [DataMember(Name = "sprinklers")]
        public string Sprinklers { get; set; }

        [DataMember(Name = "stable")]
        public string Stable { get; set; }

        [DataMember(Name = "stable_sqft")]
        public string StableSqft { get; set; }

        [DataMember(Name = "storage_building")]
        public string StorageBuilding { get; set; }

        [DataMember(Name = "storage_building_sqft")]
        public string StorageBuildingSqft { get; set; }

        [DataMember(Name = "stories_number")]
        public string StoriesNumber { get; set; }

        [DataMember(Name = "storm_shelter")]
        public string StormShelter { get; set; }

        [DataMember(Name = "storm_shutter")]
        public string StormShutter { get; set; }

        [DataMember(Name = "structure_style")]
        public string StructureStyle { get; set; }

        [DataMember(Name = "study")]
        public string Study { get; set; }

        [DataMember(Name = "subdivision")]
        public string Subdivision { get; set; }

        [DataMember(Name = "suffix")]
        public string Suffix { get; set; }

        [DataMember(Name = "suffix_2")]
        public string Suffix2 { get; set; }

        [DataMember(Name = "suffix_3")]
        public string Suffix3 { get; set; }

        [DataMember(Name = "suffix_4")]
        public string Suffix4 { get; set; }

        [DataMember(Name = "sunroom")]
        public string Sunroom { get; set; }

        [DataMember(Name = "tax_assess_year")]
        public string TaxAssessYear { get; set; }

        [DataMember(Name = "tax_billed_amount")]
        public string TaxBilledAmount { get; set; }

        [DataMember(Name = "tax_delinquent_year")]
        public string TaxDelinquentYear { get; set; }

        [DataMember(Name = "tax_fiscal_year")]
        public string TaxFiscalYear { get; set; }

        [DataMember(Name = "tax_jurisdiction")]
        public string TaxJurisdiction { get; set; }

        [DataMember(Name = "tax_rate_area")]
        public string TaxRateArea { get; set; }

        [DataMember(Name = "tennis_court")]
        public string TennisCourt { get; set; }

        [DataMember(Name = "topography_code")]
        public string TopographyCode { get; set; }

        [DataMember(Name = "total_market_value")]
        public string TotalMarketValue { get; set; }

        [DataMember(Name = "township")]
        public string Township { get; set; }

        [DataMember(Name = "tract_number")]
        public string TractNumber { get; set; }

        [DataMember(Name = "transfer_amount")]
        public string TransferAmount { get; set; }

        [DataMember(Name = "trust_description")]
        public string TrustDescription { get; set; }

        [DataMember(Name = "unit_count")]
        public string UnitCount { get; set; }

        [DataMember(Name = "upper_floors_sqft")]
        public string UpperFloorsSqft { get; set; }

        [DataMember(Name = "utility")]
        public string Utility { get; set; }

        [DataMember(Name = "utility_building")]
        public string UtilityBuilding { get; set; }

        [DataMember(Name = "utility_building_sqft")]
        public string UtilityBuildingSqft { get; set; }

        [DataMember(Name = "utility_sqft")]
        public string UtilitySqft { get; set; }

        [DataMember(Name = "veteran_tax_exemption")]
        public string VeteranTaxExemption { get; set; }

        [DataMember(Name = "view_description")]
        public string ViewDescription { get; set; }

        [DataMember(Name = "water_feature")]
        public string WaterFeature { get; set; }

        [DataMember(Name = "water_service_type")]
        public string WaterServiceType { get; set; }

        [DataMember(Name = "wet_bar")]
        public string WetBar { get; set; }

        [DataMember(Name = "widow_tax_exemption")]
        public string WidowTaxExemption { get; set; }

        [DataMember(Name = "width_linear_footage")]
        public string WidthLinearFootage { get; set; }

        [DataMember(Name = "wine_cellar")]
        public string WineCellar { get; set; }

        [DataMember(Name = "year_built")]
        public string YearBuilt { get; set; }

        [DataMember(Name = "zoning")]
        public string Zoning { get; set; }
    }
}