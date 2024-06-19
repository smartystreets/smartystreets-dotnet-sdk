namespace SmartyStreets.USEnrichmentApi.GeoReference
{
    using System.Runtime.Serialization;

	[DataContract]
    public class Result
    {
        [DataMember(Name = "smarty_key")]
        public string SmartyKey { get; set; }

        [DataMember(Name = "data_set_name")]
        public string DataSetName { get; set; }

        [DataMember(Name = "etag")]
        public string Etag { get; set; }

        [DataMember(Name = "attributes")]
        public Attributes Attributes { get; set; }
    }
}