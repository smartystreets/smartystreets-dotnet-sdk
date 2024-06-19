namespace SmartyStreets.USEnrichmentApi.GeoReference
{
    using System.Runtime.Serialization;

	[DataContract]
    public class Place
    {
        [DataMember(Name = "accuracy")]
        public string Accuracy { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}