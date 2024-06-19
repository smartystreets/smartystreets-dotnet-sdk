namespace SmartyStreets.USEnrichmentApi.GeoReference
{
    using System.Runtime.Serialization;

	[DataContract]
    public class CensusTract
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }
    }
}