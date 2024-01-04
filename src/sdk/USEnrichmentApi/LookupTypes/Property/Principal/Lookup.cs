namespace SmartyStreets.USEnrichmentApi.LookupTypes.Property.Principal
{
    using System;
    using System.IO;

    public class Lookup : SmartyStreets.USEnrichmentApi.LookupTypes.Lookup
    {
        private SmartyStreets.USEnrichmentApi.ResultTypes.Principal.Result[] results;

        public Lookup(string smartyKey) : base(smartyKey, "property", "principal")
        {
        }

        public SmartyStreets.USEnrichmentApi.ResultTypes.Principal.Result[] GetResults()
        {
            return results;
        }

        public void SetResults(SmartyStreets.USEnrichmentApi.ResultTypes.Principal.Result[] results)
        {
            this.results = results;
        }

        public override void DeserializeAndSetResults(SmartyStreets.ISerializer serializer, byte[] payload)
        {
            this.results = serializer.Deserialize<SmartyStreets.USEnrichmentApi.ResultTypes.Principal.Result[]>(payload);
        }
    }
}