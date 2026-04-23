namespace SmartyStreets.USEnrichmentApi.Business.Detail
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Attributes
    {
        [DataMember(Name = "accounting_expense_range")]
        public string AccountingExpenseRange { get; set; }

        [DataMember(Name = "accounting_expense_total")]
        public string AccountingExpenseTotal { get; set; }

        [DataMember(Name = "advertising_expense_range")]
        public string AdvertisingExpenseRange { get; set; }

        [DataMember(Name = "advertising_expense_total")]
        public string AdvertisingExpenseTotal { get; set; }

        [DataMember(Name = "business_insurance_expense_range")]
        public string BusinessInsuranceExpenseRange { get; set; }

        [DataMember(Name = "business_insurance_expense_total")]
        public string BusinessInsuranceExpenseTotal { get; set; }

        [DataMember(Name = "business_status")]
        public string BusinessStatus { get; set; }

        [DataMember(Name = "business_type")]
        public string BusinessType { get; set; }

        [DataMember(Name = "carrier_route")]
        public string CarrierRoute { get; set; }

        [DataMember(Name = "census_block")]
        public string CensusBlock { get; set; }

        [DataMember(Name = "census_tract")]
        public string CensusTract { get; set; }

        [DataMember(Name = "city_name")]
        public string CityName { get; set; }

        [DataMember(Name = "company_name")]
        public string CompanyName { get; set; }

        [DataMember(Name = "company_name_secondary")]
        public string CompanyNameSecondary { get; set; }

        [DataMember(Name = "contact_first_name")]
        public string ContactFirstName { get; set; }

        [DataMember(Name = "contact_full_name")]
        public string ContactFullName { get; set; }

        [DataMember(Name = "contact_gender")]
        public string ContactGender { get; set; }

        [DataMember(Name = "contact_last_name")]
        public string ContactLastName { get; set; }

        [DataMember(Name = "contact_middle_name")]
        public string ContactMiddleName { get; set; }

        [DataMember(Name = "contact_prefix")]
        public string ContactPrefix { get; set; }

        [DataMember(Name = "contact_professional_title")]
        public string ContactProfessionalTitle { get; set; }

        [DataMember(Name = "contact_suffix")]
        public string ContactSuffix { get; set; }

        [DataMember(Name = "core_based_stat_area_code")]
        public string CoreBasedStatAreaCode { get; set; }

        [DataMember(Name = "core_based_stat_area_name")]
        public string CoreBasedStatAreaName { get; set; }

        [DataMember(Name = "corporate_employee_count_range")]
        public string CorporateEmployeeCountRange { get; set; }

        [DataMember(Name = "corporate_employee_count_total")]
        public string CorporateEmployeeCountTotal { get; set; }

        [DataMember(Name = "county_fips")]
        public string CountyFips { get; set; }

        [DataMember(Name = "county_name")]
        public string CountyName { get; set; }

        [DataMember(Name = "credit_capacity")]
        public string CreditCapacity { get; set; }

        [DataMember(Name = "credit_capacity_range")]
        public string CreditCapacityRange { get; set; }

        [DataMember(Name = "credit_score")]
        public string CreditScore { get; set; }

        [DataMember(Name = "credit_score_description")]
        public string CreditScoreDescription { get; set; }

        [DataMember(Name = "date_of_last_update")]
        public string DateOfLastUpdate { get; set; }

        [DataMember(Name = "delivery_line_1")]
        public string DeliveryLine1 { get; set; }

        [DataMember(Name = "delivery_point")]
        public string DeliveryPoint { get; set; }

        [DataMember(Name = "delivery_point_check_digit")]
        public string DeliveryPointCheckDigit { get; set; }

        [DataMember(Name = "domestic_foreign_owner_indicator")]
        public string DomesticForeignOwnerIndicator { get; set; }

        [DataMember(Name = "ein")]
        public string Ein { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "email_available_indicator")]
        public string EmailAvailableIndicator { get; set; }

        [DataMember(Name = "executive_department")]
        public string ExecutiveDepartment { get; set; }

        [DataMember(Name = "executive_level")]
        public string ExecutiveLevel { get; set; }

        [DataMember(Name = "executive_verification_type")]
        public string ExecutiveVerificationType { get; set; }

        [DataMember(Name = "fax")]
        public string Fax { get; set; }

        [DataMember(Name = "female_owned_indicator")]
        public string FemaleOwnedIndicator { get; set; }

        [DataMember(Name = "foreign_parent_city_name")]
        public string ForeignParentCityName { get; set; }

        [DataMember(Name = "foreign_parent_company_name")]
        public string ForeignParentCompanyName { get; set; }

        [DataMember(Name = "foreign_parent_country")]
        public string ForeignParentCountry { get; set; }

        [DataMember(Name = "fortune_1000_branches")]
        public string Fortune1000Branches { get; set; }

        [DataMember(Name = "fortune_1000_indicator")]
        public string Fortune1000Indicator { get; set; }

        [DataMember(Name = "fortune_1000_rank")]
        public string Fortune1000Rank { get; set; }

        [DataMember(Name = "holding_city_name")]
        public string HoldingCityName { get; set; }

        [DataMember(Name = "holding_company_name")]
        public string HoldingCompanyName { get; set; }

        [DataMember(Name = "holding_id")]
        public string HoldingId { get; set; }

        [DataMember(Name = "holding_state_abbreviation")]
        public string HoldingStateAbbreviation { get; set; }

        [DataMember(Name = "home_based_business_indicator")]
        public string HomeBasedBusinessIndicator { get; set; }

        [DataMember(Name = "hq_city_name")]
        public string HqCityName { get; set; }

        [DataMember(Name = "hq_company_name")]
        public string HqCompanyName { get; set; }

        [DataMember(Name = "hq_id")]
        public string HqId { get; set; }

        [DataMember(Name = "hq_number_of_companies")]
        public string HqNumberOfCompanies { get; set; }

        [DataMember(Name = "hq_state_abbreviation")]
        public string HqStateAbbreviation { get; set; }

        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "legal_expense_range")]
        public string LegalExpenseRange { get; set; }

        [DataMember(Name = "legal_expense_total")]
        public string LegalExpenseTotal { get; set; }

        [DataMember(Name = "linkage_company_name")]
        public string LinkageCompanyName { get; set; }

        [DataMember(Name = "linkage_indicator")]
        public string LinkageIndicator { get; set; }

        [DataMember(Name = "linkage_level")]
        public string LinkageLevel { get; set; }

        [DataMember(Name = "linkage_type")]
        public string LinkageType { get; set; }

        [DataMember(Name = "location_employee_count")]
        public string LocationEmployeeCount { get; set; }

        [DataMember(Name = "location_employee_count_range")]
        public string LocationEmployeeCountRange { get; set; }

        [DataMember(Name = "location_sales_range")]
        public string LocationSalesRange { get; set; }

        [DataMember(Name = "location_sales_total")]
        public string LocationSalesTotal { get; set; }

        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }

        [DataMember(Name = "mail_score_code")]
        public string MailScoreCode { get; set; }

        [DataMember(Name = "mail_score_description")]
        public string MailScoreDescription { get; set; }

        [DataMember(Name = "mailing_carrier_route")]
        public string MailingCarrierRoute { get; set; }

        [DataMember(Name = "mailing_city_name")]
        public string MailingCityName { get; set; }

        [DataMember(Name = "mailing_delivery_line_1")]
        public string MailingDeliveryLine1 { get; set; }

        [DataMember(Name = "mailing_delivery_point")]
        public string MailingDeliveryPoint { get; set; }

        [DataMember(Name = "mailing_delivery_point_check_digit")]
        public string MailingDeliveryPointCheckDigit { get; set; }

        [DataMember(Name = "mailing_plus4_code")]
        public string MailingPlus4Code { get; set; }

        [DataMember(Name = "mailing_state_abbreviation")]
        public string MailingStateAbbreviation { get; set; }

        [DataMember(Name = "mailing_zipcode")]
        public string MailingZipcode { get; set; }

        [DataMember(Name = "manufacturing_indicator")]
        public string ManufacturingIndicator { get; set; }

        [DataMember(Name = "minority_owned_indicator")]
        public string MinorityOwnedIndicator { get; set; }

        [DataMember(Name = "minority_type")]
        public string MinorityType { get; set; }

        [DataMember(Name = "naics_01_code")]
        public string Naics01Code { get; set; }

        [DataMember(Name = "naics_01_description")]
        public string Naics01Description { get; set; }

        [DataMember(Name = "naics_02_code")]
        public string Naics02Code { get; set; }

        [DataMember(Name = "naics_02_description")]
        public string Naics02Description { get; set; }

        [DataMember(Name = "naics_03_code")]
        public string Naics03Code { get; set; }

        [DataMember(Name = "naics_03_description")]
        public string Naics03Description { get; set; }

        [DataMember(Name = "naics_04_code")]
        public string Naics04Code { get; set; }

        [DataMember(Name = "naics_04_description")]
        public string Naics04Description { get; set; }

        [DataMember(Name = "naics_05_code")]
        public string Naics05Code { get; set; }

        [DataMember(Name = "naics_05_description")]
        public string Naics05Description { get; set; }

        [DataMember(Name = "naics_06_code")]
        public string Naics06Code { get; set; }

        [DataMember(Name = "naics_06_description")]
        public string Naics06Description { get; set; }

        [DataMember(Name = "new_business_indicator")]
        public string NewBusinessIndicator { get; set; }

        [DataMember(Name = "non_profit_indicator")]
        public string NonProfitIndicator { get; set; }

        [DataMember(Name = "num_of_pcs_range")]
        public string NumOfPcsRange { get; set; }

        [DataMember(Name = "num_of_pcs_total")]
        public string NumOfPcsTotal { get; set; }

        [DataMember(Name = "number_of_years_in_business")]
        public string NumberOfYearsInBusiness { get; set; }

        [DataMember(Name = "number_of_years_in_business_range")]
        public string NumberOfYearsInBusinessRange { get; set; }

        [DataMember(Name = "office_equipment_expense_range")]
        public string OfficeEquipmentExpenseRange { get; set; }

        [DataMember(Name = "office_equipment_expense_total")]
        public string OfficeEquipmentExpenseTotal { get; set; }

        [DataMember(Name = "operating_hours_friday")]
        public string OperatingHoursFriday { get; set; }

        [DataMember(Name = "operating_hours_monday")]
        public string OperatingHoursMonday { get; set; }

        [DataMember(Name = "operating_hours_saturday")]
        public string OperatingHoursSaturday { get; set; }

        [DataMember(Name = "operating_hours_sunday")]
        public string OperatingHoursSunday { get; set; }

        [DataMember(Name = "operating_hours_thursday")]
        public string OperatingHoursThursday { get; set; }

        [DataMember(Name = "operating_hours_tuesday")]
        public string OperatingHoursTuesday { get; set; }

        [DataMember(Name = "operating_hours_wednesday")]
        public string OperatingHoursWednesday { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "phone_area_code")]
        public string PhoneAreaCode { get; set; }

        [DataMember(Name = "phone_secondary")]
        public string PhoneSecondary { get; set; }

        [DataMember(Name = "phone_toll_free")]
        public string PhoneTollFree { get; set; }

        [DataMember(Name = "plus4_code")]
        public string Plus4Code { get; set; }

        [DataMember(Name = "population_range")]
        public string PopulationRange { get; set; }

        [DataMember(Name = "precision")]
        public string Precision { get; set; }

        [DataMember(Name = "primary_executive_indicator")]
        public string PrimaryExecutiveIndicator { get; set; }

        [DataMember(Name = "primary_number")]
        public string PrimaryNumber { get; set; }

        [DataMember(Name = "primary_sic_2digit_code")]
        public string PrimarySic2DigitCode { get; set; }

        [DataMember(Name = "primary_sic_2digit_description")]
        public string PrimarySic2DigitDescription { get; set; }

        [DataMember(Name = "primary_sic_4digit_code")]
        public string PrimarySic4DigitCode { get; set; }

        [DataMember(Name = "primary_sic_4digit_description")]
        public string PrimarySic4DigitDescription { get; set; }

        [DataMember(Name = "primary_sic_code")]
        public string PrimarySicCode { get; set; }

        [DataMember(Name = "primary_sic_description")]
        public string PrimarySicDescription { get; set; }

        [DataMember(Name = "public_indicator")]
        public string PublicIndicator { get; set; }

        [DataMember(Name = "rdi")]
        public string Rdi { get; set; }

        [DataMember(Name = "rent_expense_range")]
        public string RentExpenseRange { get; set; }

        [DataMember(Name = "rent_expense_total")]
        public string RentExpenseTotal { get; set; }

        [DataMember(Name = "secondary_01_sic_7digit_code")]
        public string Secondary01Sic7DigitCode { get; set; }

        [DataMember(Name = "secondary_01_sic_7digit_description")]
        public string Secondary01Sic7DigitDescription { get; set; }

        [DataMember(Name = "secondary_02_sic_7digit_code")]
        public string Secondary02Sic7DigitCode { get; set; }

        [DataMember(Name = "secondary_02_sic_7digit_description")]
        public string Secondary02Sic7DigitDescription { get; set; }

        [DataMember(Name = "secondary_03_sic_7digit_code")]
        public string Secondary03Sic7DigitCode { get; set; }

        [DataMember(Name = "secondary_03_sic_7digit_description")]
        public string Secondary03Sic7DigitDescription { get; set; }

        [DataMember(Name = "secondary_04_sic_7digit_code")]
        public string Secondary04Sic7DigitCode { get; set; }

        [DataMember(Name = "secondary_04_sic_7digit_description")]
        public string Secondary04Sic7DigitDescription { get; set; }

        [DataMember(Name = "secondary_05_sic_7digit_code")]
        public string Secondary05Sic7DigitCode { get; set; }

        [DataMember(Name = "secondary_05_sic_7digit_description")]
        public string Secondary05Sic7DigitDescription { get; set; }

        [DataMember(Name = "secondary_designator")]
        public string SecondaryDesignator { get; set; }

        [DataMember(Name = "secondary_number")]
        public string SecondaryNumber { get; set; }

        [DataMember(Name = "sectional_center_facility")]
        public string SectionalCenterFacility { get; set; }

        [DataMember(Name = "small_business_indicator")]
        public string SmallBusinessIndicator { get; set; }

        [DataMember(Name = "source_title")]
        public string SourceTitle { get; set; }

        [DataMember(Name = "square_footage")]
        public string SquareFootage { get; set; }

        [DataMember(Name = "square_footage_range")]
        public string SquareFootageRange { get; set; }

        [DataMember(Name = "standardized_title")]
        public string StandardizedTitle { get; set; }

        [DataMember(Name = "standardized_title_rank")]
        public string StandardizedTitleRank { get; set; }

        [DataMember(Name = "state_abbreviation")]
        public string StateAbbreviation { get; set; }

        [DataMember(Name = "stock_exchange")]
        public string StockExchange { get; set; }

        [DataMember(Name = "street_name")]
        public string StreetName { get; set; }

        [DataMember(Name = "street_postdirection")]
        public string StreetPostdirection { get; set; }

        [DataMember(Name = "street_predirection")]
        public string StreetPredirection { get; set; }

        [DataMember(Name = "street_suffix")]
        public string StreetSuffix { get; set; }

        [DataMember(Name = "sub_hq_city_name")]
        public string SubHqCityName { get; set; }

        [DataMember(Name = "sub_hq_company_name")]
        public string SubHqCompanyName { get; set; }

        [DataMember(Name = "sub_hq_id")]
        public string SubHqId { get; set; }

        [DataMember(Name = "sub_hq_number_of_companies")]
        public string SubHqNumberOfCompanies { get; set; }

        [DataMember(Name = "sub_hq_state_abbreviation")]
        public string SubHqStateAbbreviation { get; set; }

        [DataMember(Name = "technology_expense_range")]
        public string TechnologyExpenseRange { get; set; }

        [DataMember(Name = "technology_expense_total")]
        public string TechnologyExpenseTotal { get; set; }

        [DataMember(Name = "telecom_expense_range")]
        public string TelecomExpenseRange { get; set; }

        [DataMember(Name = "telecom_expense_total")]
        public string TelecomExpenseTotal { get; set; }

        [DataMember(Name = "ticker_symbol")]
        public string TickerSymbol { get; set; }

        [DataMember(Name = "time_zone")]
        public string TimeZone { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "url_facebook")]
        public string UrlFacebook { get; set; }

        [DataMember(Name = "url_instagram")]
        public string UrlInstagram { get; set; }

        [DataMember(Name = "url_linkedin")]
        public string UrlLinkedin { get; set; }

        [DataMember(Name = "url_twitter")]
        public string UrlTwitter { get; set; }

        [DataMember(Name = "url_yelp")]
        public string UrlYelp { get; set; }

        [DataMember(Name = "url_youtube")]
        public string UrlYoutube { get; set; }

        [DataMember(Name = "utilities_expense_range")]
        public string UtilitiesExpenseRange { get; set; }

        [DataMember(Name = "utilities_expense_total")]
        public string UtilitiesExpenseTotal { get; set; }

        [DataMember(Name = "webmail_indicator")]
        public string WebmailIndicator { get; set; }

        [DataMember(Name = "year_current")]
        public string YearCurrent { get; set; }

        [DataMember(Name = "year_current_employee_count")]
        public string YearCurrentEmployeeCount { get; set; }

        [DataMember(Name = "year_established")]
        public string YearEstablished { get; set; }

        [DataMember(Name = "year_four_prior")]
        public string YearFourPrior { get; set; }

        [DataMember(Name = "year_four_prior_employee_count")]
        public string YearFourPriorEmployeeCount { get; set; }

        [DataMember(Name = "year_four_prior_employee_growth")]
        public string YearFourPriorEmployeeGrowth { get; set; }

        [DataMember(Name = "year_one_prior")]
        public string YearOnePrior { get; set; }

        [DataMember(Name = "year_one_prior_employee_count")]
        public string YearOnePriorEmployeeCount { get; set; }

        [DataMember(Name = "year_one_prior_employee_growth")]
        public string YearOnePriorEmployeeGrowth { get; set; }

        [DataMember(Name = "year_three_prior")]
        public string YearThreePrior { get; set; }

        [DataMember(Name = "year_three_prior_employee_count")]
        public string YearThreePriorEmployeeCount { get; set; }

        [DataMember(Name = "year_three_prior_employee_growth")]
        public string YearThreePriorEmployeeGrowth { get; set; }

        [DataMember(Name = "year_two_prior")]
        public string YearTwoPrior { get; set; }

        [DataMember(Name = "year_two_prior_employee_count")]
        public string YearTwoPriorEmployeeCount { get; set; }

        [DataMember(Name = "year_two_prior_employee_growth")]
        public string YearTwoPriorEmployeeGrowth { get; set; }

        [DataMember(Name = "zipcode")]
        public string Zipcode { get; set; }
    }
}
