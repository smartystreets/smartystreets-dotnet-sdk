namespace SmartyStreets.USEnrichmentApi.Property.Principal
{
    using System.Runtime.Serialization;

	[DataContract]
    public class HistoryEntry
    {
        [DataMember(Name = "code_title_company")]
        public string CodeTitleCompany { get; set; }

        [DataMember(Name = "document_type_description")]
        public string DocumentTypeDescription { get; set; }

        [DataMember(Name = "instrument_date")]
        public string InstrumentDate { get; set; }

        [DataMember(Name = "interest_rate_type_2")]
        public string InterestRateType2 { get; set; }

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

        [DataMember(Name = "multi_parcel_flag")]
        public string MultiParcelFlag { get; set; }

        [DataMember(Name = "name_title_company")]
        public string NameTitleCompany { get; set; }

        [DataMember(Name = "recording_date")]
        public string RecordingDate { get; set; }

        [DataMember(Name = "transfer_amount")]
        public string TransferAmount { get; set; }
    }

}