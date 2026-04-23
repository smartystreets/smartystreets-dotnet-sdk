namespace SmartyStreets.USEnrichmentApi.Business.Summary
{
    using System.Runtime.Serialization;

    [DataContract]
    public class BusinessEntry
    {
        [DataMember(Name = "company_name")]
        public string CompanyName { get; set; }

        [DataMember(Name = "business_id")]
        public string BusinessId { get; set; }
    }
}
