namespace SmartyStreets.USEnrichmentApi
{
    using System.Runtime.Serialization;

	[DataContract]
    public class MatchedAddress
    {
        [DataMember(Name = "street")]
        public string street { get; set; }

        [DataMember(Name = "city")]
        public string city { get; set; }

        [DataMember(Name = "state")]
        public string state { get; set; }

        [DataMember(Name = "zipcode")]
        public string zipcode { get; set; }
    }
}