namespace SmartyStreets.SmartyStreets.USEnrichmentApi.ResultTypes.Property.Financial
{
    public class HistoryEntry
    {
        [JsonProperty("code_title_company")]
        public string CodeTitleCompany { get; set; }

        [JsonProperty("document_type_description")]
        public string DocumentTypeDescription { get; set; }

        [JsonProperty("instrument_date")]
        public string InstrumentDate { get; set; }

        [JsonProperty("interest_rate_type_2")]
        public string InterestRateType2 { get; set; }

        [JsonProperty("lender_address")]
        public string LenderAddress { get; set; }

        [JsonProperty("lender_address_2")]
        public string LenderAddress2 { get; set; }

        [JsonProperty("lender_city")]
        public string LenderCity { get; set; }

        [JsonProperty("lender_city_2")]
        public string LenderCity2 { get; set; }

        [JsonProperty("lender_code_2")]
        public string LenderCode2 { get; set; }

        [JsonProperty("lender_first_name")]
        public string LenderFirstName { get; set; }

        [JsonProperty("lender_first_name_2")]
        public string LenderFirstName2 { get; set; }

        [JsonProperty("lender_last_name")]
        public string LenderLastName { get; set; }

        [JsonProperty("lender_last_name_2")]
        public string LenderLastName2 { get; set; }

        [JsonProperty("lender_name")]
        public string LenderName { get; set; }

        [JsonProperty("lender_name_2")]
        public string LenderName2 { get; set; }

        [JsonProperty("lender_seller_carry_back")]
        public string LenderSellerCarryBack { get; set; }

        [JsonProperty("lender_seller_carry_back_2")]
        public string LenderSellerCarryBack2 { get; set; }

        [JsonProperty("lender_state")]
        public string LenderState { get; set; }

        [JsonProperty("lender_state_2")]
        public string LenderState2 { get; set; }

        [JsonProperty("lender_zip")]
        public string LenderZip { get; set; }

        [JsonProperty("lender_zip_2")]
        public string LenderZip2 { get; set; }

        [JsonProperty("lender_zip_extended")]
        public string LenderZipExtended { get; set; }

        [JsonProperty("lender_zip_extended_2")]
        public string LenderZipExtended2 { get; set; }

        [JsonProperty("mortgage_amount")]
        public string MortgageAmount { get; set; }

        [JsonProperty("mortgage_amount_2")]
        public string MortgageAmount2 { get; set; }

        [JsonProperty("mortgage_due_date")]
        public string MortgageDueDate { get; set; }

        [JsonProperty("mortgage_due_date_2")]
        public string MortgageDueDate2 { get; set; }

        [JsonProperty("mortgage_interest_rate")]
        public string MortgageInterestRate { get; set; }

        [JsonProperty("mortgage_interest_rate_type")]
        public string MortgageInterestRateType { get; set; }

        [JsonProperty("mortgage_lender_code")]
        public string MortgageLenderCode { get; set; }

        [JsonProperty("mortgage_rate_2")]
        public string MortgageRate2 { get; set; }

        [JsonProperty("mortgage_recording_date")]
        public string MortgageRecordingDate { get; set; }

        [JsonProperty("mortgage_recording_date_2")]
        public string MortgageRecordingDate2 { get; set; }

        [JsonProperty("mortgage_term")]
        public string MortgageTerm { get; set; }

        [JsonProperty("mortgage_term_2")]
        public string MortgageTerm2 { get; set; }

        [JsonProperty("mortgage_term_type")]
        public string MortgageTermType { get; set; }

        [JsonProperty("mortgage_term_type_2")]
        public string MortgageTermType2 { get; set; }

        [JsonProperty("mortgage_type")]
        public string MortgageType { get; set; }

        [JsonProperty("mortgage_type_2")]
        public string MortgageType2 { get; set; }

        [JsonProperty("multi_parcel_flag")]
        public string MultiParcelFlag { get; set; }

        [JsonProperty("name_title_company")]
        public string NameTitleCompany { get; set; }

        [JsonProperty("recording_date")]
        public string RecordingDate { get; set; }

        [JsonProperty("transfer_amount")]
        public string TransferAmount { get; set; }
    }

}