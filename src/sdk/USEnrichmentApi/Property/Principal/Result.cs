namespace SmartyStreets.USEnrichmentApi.Property.Principal
{
    using System.Runtime.Serialization;

	[DataContract]
    public class Result
    {
        [DataMember(Name = "smarty_key")]
        public string SmartyKey { get; set; }

        [DataMember(Name = "data_set_name")]
        public string DataSetName { get; set; }

        [DataMember(Name = "data_subset_name")]
        public string DataSubsetName { get; set; }

        [DataMember(Name = "etag")]
        public string Etag { get; set; }

        [DataMember(Name = "matched_address")]
        public MatchedAddress MatchedAddress { get; set; }

        [DataMember(Name = "attributes")]
        public Attributes Attributes { get; set; }
    }
}