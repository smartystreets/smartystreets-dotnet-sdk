namespace SmartyStreets.USEnrichmentApi.Secondary
{
    using System.Runtime.Serialization;

	[DataContract]
    public class Secondaries
    {
        [DataMember(Name = "smarty_key")]
        public string SmartyKey { get; set; }
        
        [DataMember(Name = "secondary_designator")]
        public string SecondaryDesignator { get; set; }

        [DataMember(Name = "secondary_number")]
        public string SecondaryNumber { get; set; }
        
        [DataMember(Name = "plus4_code")]
        public string Plus4Code { get; set; }
    }
}