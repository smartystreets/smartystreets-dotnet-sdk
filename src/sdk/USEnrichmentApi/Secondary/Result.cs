namespace SmartyStreets.USEnrichmentApi.Secondary
{
    using System.Runtime.Serialization;

	[DataContract]
    public class Result
    {
        [DataMember(Name = "smarty_key")]
        public string SmartyKey { get; set; }

        [DataMember(Name = "etag")]
        public string Etag { get; set; }

        [DataMember(Name = "root_address")]
        public RootAddress RootAddress { get; set; }

        [DataMember(Name = "aliases")]
        public Aliases[] Aliases { get; set; }

        [DataMember(Name = "secondaries")]
        public Secondaries[] Secondaries { get; set; }
    }
}