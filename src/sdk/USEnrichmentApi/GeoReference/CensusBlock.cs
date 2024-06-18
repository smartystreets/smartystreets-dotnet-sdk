namespace SmartyStreets.USEnrichmentApi.GeoReference
{
    using System.Runtime.Serialization;

	[DataContract]
    public class CensusBlock
    {
        [DataMember(Name = "accuracy")]
        public string Accuracy { get; set; }

        [DataMember(Name = "geoid")]
        public string GeoID { get; set; }
    }
}