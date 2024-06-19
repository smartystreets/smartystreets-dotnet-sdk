namespace SmartyStreets.USEnrichmentApi.GeoReference
{
    using System.Runtime.Serialization;

	[DataContract]
    public class CoreBasedStatArea
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}