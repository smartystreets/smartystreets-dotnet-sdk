namespace SmartyStreets.SmartyStreets.USEnrichmentApi.ResultTypes.Property.Financial
{
    public class Attributes
    {
        [JsonProperty("assessed_improvement_percent")]
        public string AssessedImprovementPercent { get; set; }

        [JsonProperty("assessed_improvement_value")]
        public string AssessedImprovementValue { get; set; }

        [JsonProperty("assessed_land_value")]
        public string AssessedLandValue { get; set; }

        [JsonProperty("assessed_value")]
        public string AssessedValue { get; set; }

        [JsonProperty("assessor_last_update")]
        public string AssessorLastUpdate { get; set; }

        [JsonProperty("assessor_taxroll_update")]
        public string AssessorTaxrollUpdate { get; set; }

        [JsonProperty("contact_city")]
        public string ContactCity { get; set; }

        [JsonProperty("contact_crrt")]
        public string ContactCrrt { get; set; }

        [JsonProperty("contact_full_address")]
        public string ContactFullAddress { get; set; }

        [JsonProperty("contact_house_number")]
        public string ContactHouseNumber { get; set; }

        [JsonProperty("contact_mail_info_format")]
        public string ContactMailInfoFormat { get; set; }

        [JsonProperty("contact_mail_info_privacy")]
        public string ContactMailInfoPrivacy { get; set; }

        [JsonProperty("contact_mailing_county")]
        public string ContactMailingCounty { get; set; }

        [JsonProperty("contact_mailing_fips")]
        public string ContactMailingFips { get; set; }

        [JsonProperty("contact_post_direction")]
        public string ContactPostDirection { get; set; }

        [JsonProperty("contact_pre_direction")]
        public string ContactPreDirection { get; set; }

        [JsonProperty("contact_state")]
        public string ContactState { get; set; }

        [JsonProperty("contact_street_name")]
        public string ContactStreetName { get; set; }

        [JsonProperty("contact_suffix")]
        public string ContactSuffix { get; set; }

        [JsonProperty("contact_unit_designator")]
        public string ContactUnitDesignator { get; set; }

        [JsonProperty("contact_value")]
        public string ContactValue { get; set; }

        [JsonProperty("contact_zip")]
        public string ContactZip { get; set; }

        [JsonProperty("contact_zip4")]
        public string ContactZip4 { get; set; }

        [JsonProperty("deed_document_book")]
        public string DeedDocumentBook { get; set; }

        [JsonProperty("deed_document_number")]
        public string DeedDocumentNumber { get; set; }

        [JsonProperty("deed_document_page")]
        public string DeedDocumentPage { get; set; }

        [JsonProperty("deed_owner_first_name")]
        public string DeedOwnerFirstName { get; set; }

        [JsonProperty("deed_owner_first_name2")]
        public string DeedOwnerFirstName2 { get; set; }

        [JsonProperty("deed_owner_first_name3")]
        public string DeedOwnerFirstName3 { get; set; }

        [JsonProperty("deed_owner_first_name4")]
        public string DeedOwnerFirstName4 { get; set; }

        [JsonProperty("deed_owner_full_name")]
        public string DeedOwnerFullName { get; set; }

        [JsonProperty("deed_owner_full_name2")]
        public string DeedOwnerFullName2 { get; set; }

        [JsonProperty("deed_owner_full_name3")]
        public string DeedOwnerFullName3 { get; set; }

        [JsonProperty("deed_owner_full_name4")]
        public string DeedOwnerFullName4 { get; set; }

        [JsonProperty("deed_owner_last_name")]
        public string DeedOwnerLastName { get; set; }

        [JsonProperty("deed_owner_last_name2")]
        public string DeedOwnerLastName2 { get; set; }

        [JsonProperty("deed_owner_last_name3")]
        public string DeedOwnerLastName3 { get; set; }

        [JsonProperty("deed_owner_last_name4")]
        public string DeedOwnerLastName4 { get; set; }

        [JsonProperty("deed_owner_middle_name")]
        public string DeedOwnerMiddleName { get; set; }

        [JsonProperty("deed_owner_middle_name2")]
        public string DeedOwnerMiddleName2 { get; set; }

        [JsonProperty("deed_owner_middle_name3")]
        public string DeedOwnerMiddleName3 { get; set; }

        [JsonProperty("deed_owner_middle_name4")]
        public string DeedOwnerMiddleName4 { get; set; }

        [JsonProperty("deed_owner_suffix")]
        public string DeedOwnerSuffix { get; set; }

        [JsonProperty("deed_owner_suffix2")]
        public string DeedOwnerSuffix2 { get; set; }

        [JsonProperty("deed_owner_suffix3")]
        public string DeedOwnerSuffix3 { get; set; }

        [JsonProperty("deed_owner_suffix4")]
        public string DeedOwnerSuffix4 { get; set; }

        [JsonProperty("deed_sale_date")]
        public string DeedSaleDate { get; set; }

        [JsonProperty("deed_sale_price")]
        public string DeedSalePrice { get; set; }

        [JsonProperty("deed_transaction_id")]
        public string DeedTransactionId { get; set; }

        [JsonProperty("disabled_tax_exemption")]
        public string DisabledTaxExemption { get; set; }

        [JsonProperty("financial_history")]
        public List<HistoryEntry> FinancialHistory { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("first_name_2")]
        public string FirstName2 { get; set; }

        [JsonProperty("first_name_3")]
        public string FirstName3 { get; set; }

        [JsonProperty("first_name_4")]
        public string FirstName4 { get; set; }

        [JsonProperty("homeowner_tax_exemption")]
        public string HomeownerTaxExemption { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("last_name_2")]
        public string LastName2 { get; set; }

        [JsonProperty("last_name_3")]
        public string LastName3 { get; set; }

        [JsonProperty("last_name_4")]
        public string LastName4 { get; set; }

        [JsonProperty("market_improvement_percent")]
        public string MarketImprovementPercent { get; set; }

        [JsonProperty("market_improvement_value")]
        public string MarketImprovementValue { get; set; }

        [JsonProperty("market_land_value")]
        public string MarketLandValue { get; set; }

        [JsonProperty("market_value_year")]
        public string MarketValueYear { get; set; }

        [JsonProperty("match_type")]
        public string MatchType { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("middle_name_2")]
        public string MiddleName2 { get; set; }

        [JsonProperty("middle_name_3")]
        public string MiddleName3 { get; set; }

        [JsonProperty("middle_name_4")]
        public string MiddleName4 { get; set; }

        [JsonProperty("other_tax_exemption")]
        public string OtherTaxExemption { get; set; }

        [JsonProperty("owner_full_name")]
        public string OwnerFullName { get; set; }

        [JsonProperty("owner_full_name_2")]
        public string OwnerFullName2 { get; set; }

        [JsonProperty("owner_full_name_3")]
        public string OwnerFullName3 { get; set; }

        [JsonProperty("owner_full_name_4")]
        public string OwnerFullName4 { get; set; }

        [JsonProperty("ownership_transfer_date")]
        public string OwnershipTransferDate { get; set; }

        [JsonProperty("ownership_transfer_doc_number")]
        public string OwnershipTransferDocNumber { get; set; }

        [JsonProperty("ownership_transfer_transaction_id")]
        public string OwnershipTransferTransactionId { get; set; }

        [JsonProperty("ownership_type")]
        public string OwnershipType { get; set; }

        [JsonProperty("ownership_type_2")]
        public string OwnershipType2 { get; set; }

        [JsonProperty("previous_assessed_value")]
        public string PreviousAssessedValue { get; set; }

        [JsonProperty("prior_sale_amount")]
        public string PriorSaleAmount { get; set; }

        [JsonProperty("prior_sale_date")]
        public string PriorSaleDate { get; set; }

        [JsonProperty("sale_amount")]
        public string SaleAmount { get; set; }

        [JsonProperty("sale_date")]
        public string SaleDate { get; set; }

        [JsonProperty("senior_tax_exemption")]
        public string SeniorTaxExemption { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("suffix_2")]
        public string Suffix2 { get; set; }

        [JsonProperty("suffix_3")]
        public string Suffix3 { get; set; }

        [JsonProperty("suffix_4")]
        public string Suffix4 { get; set; }

        [JsonProperty("tax_assess_year")]
        public string TaxAssessYear { get; set; }

        [JsonProperty("tax_billed_amount")]
        public string TaxBilledAmount { get; set; }

        [JsonProperty("tax_delinquent_year")]
        public string TaxDelinquentYear { get; set; }

        [JsonProperty("tax_fiscal_year")]
        public string TaxFiscalYear { get; set; }

        [JsonProperty("tax_rate_area")]
        public string TaxRateArea { get; set; }

        [JsonProperty("total_market_value")]
        public string TotalMarketValue { get; set; }

        [JsonProperty("trust_description")]
        public string TrustDescription { get; set; }

        [JsonProperty("veteran_tax_exemption")]
        public string VeteranTaxExemption { get; set; }

        [JsonProperty("widow_tax_exemption")]
        public string WidowTaxExemption { get; set; }
    }
}