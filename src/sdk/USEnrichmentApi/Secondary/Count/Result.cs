namespace SmartyStreets.USEnrichmentApi.Secondary.Count
{
    using System.Runtime.Serialization;

	[DataContract]
    public class Result
    {
        [DataMember(Name = "smarty_key")]
        public string SmartyKey { get; set; }

        [DataMember(Name = "etag")]
        public string Etag { get; set; }

        [DataMember(Name = "count")]
        public string count { get; set; }
    }
}