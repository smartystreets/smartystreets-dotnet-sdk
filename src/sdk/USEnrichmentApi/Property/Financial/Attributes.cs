namespace SmartyStreets.USEnrichmentApi.Property.Financial
{
    using System.Runtime.Serialization;
    using System.Collections.Generic;

	[DataContract]

    public class Attributes
    {
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

        [DataMember(Name = "disabled_tax_exemption")]
        public string DisabledTaxExemption { get; set; }

        [DataMember(Name = "financial_history")]
        public List<HistoryEntry> FinancialHistory { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "first_name_2")]
        public string FirstName2 { get; set; }

        [DataMember(Name = "first_name_3")]
        public string FirstName3 { get; set; }

        [DataMember(Name = "first_name_4")]
        public string FirstName4 { get; set; }

        [DataMember(Name = "homeowner_tax_exemption")]
        public string HomeownerTaxExemption { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        [DataMember(Name = "last_name_2")]
        public string LastName2 { get; set; }

        [DataMember(Name = "last_name_3")]
        public string LastName3 { get; set; }

        [DataMember(Name = "last_name_4")]
        public string LastName4 { get; set; }

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

        [DataMember(Name = "middle_name")]
        public string MiddleName { get; set; }

        [DataMember(Name = "middle_name_2")]
        public string MiddleName2 { get; set; }

        [DataMember(Name = "middle_name_3")]
        public string MiddleName3 { get; set; }

        [DataMember(Name = "middle_name_4")]
        public string MiddleName4 { get; set; }

        [DataMember(Name = "other_tax_exemption")]
        public string OtherTaxExemption { get; set; }

        [DataMember(Name = "owner_full_name")]
        public string OwnerFullName { get; set; }

        [DataMember(Name = "owner_full_name_2")]
        public string OwnerFullName2 { get; set; }

        [DataMember(Name = "owner_full_name_3")]
        public string OwnerFullName3 { get; set; }

        [DataMember(Name = "owner_full_name_4")]
        public string OwnerFullName4 { get; set; }

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

        [DataMember(Name = "previous_assessed_value")]
        public string PreviousAssessedValue { get; set; }

        [DataMember(Name = "prior_sale_amount")]
        public string PriorSaleAmount { get; set; }

        [DataMember(Name = "prior_sale_date")]
        public string PriorSaleDate { get; set; }

        [DataMember(Name = "sale_amount")]
        public string SaleAmount { get; set; }

        [DataMember(Name = "sale_date")]
        public string SaleDate { get; set; }

        [DataMember(Name = "senior_tax_exemption")]
        public string SeniorTaxExemption { get; set; }

        [DataMember(Name = "suffix")]
        public string Suffix { get; set; }

        [DataMember(Name = "suffix_2")]
        public string Suffix2 { get; set; }

        [DataMember(Name = "suffix_3")]
        public string Suffix3 { get; set; }

        [DataMember(Name = "suffix_4")]
        public string Suffix4 { get; set; }

        [DataMember(Name = "tax_assess_year")]
        public string TaxAssessYear { get; set; }

        [DataMember(Name = "tax_billed_amount")]
        public string TaxBilledAmount { get; set; }

        [DataMember(Name = "tax_delinquent_year")]
        public string TaxDelinquentYear { get; set; }

        [DataMember(Name = "tax_fiscal_year")]
        public string TaxFiscalYear { get; set; }

        [DataMember(Name = "tax_rate_area")]
        public string TaxRateArea { get; set; }

        [DataMember(Name = "total_market_value")]
        public string TotalMarketValue { get; set; }

        [DataMember(Name = "trust_description")]
        public string TrustDescription { get; set; }

        [DataMember(Name = "veteran_tax_exemption")]
        public string VeteranTaxExemption { get; set; }

        [DataMember(Name = "widow_tax_exemption")]
        public string WidowTaxExemption { get; set; }
    }
}