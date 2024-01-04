namespace SmartyStreets.USEnrichmentApi.LookupTypes.Property.Financial
{
    using System;
    using System.IO;

    public class Lookup : SmartyStreets.USEnrichmentApi.LookupTypes.Lookup
    {
        private SmartyStreets.USEnrichmentApi.ResultTypes.Financial.Result[] results;

        public Lookup(string smartyKey) : base(smartyKey, "property", "financial")
        {
        }

        public SmartyStreets.USEnrichmentApi.ResultTypes.Financial.Result[] GetResults()
        {
            return results;
        }

        public void SetResults(SmartyStreets.USEnrichmentApi.ResultTypes.Financial.Result[] results)
        {
            this.results = results;
        }

        public override void DeserializeAndSetResults(SmartyStreets.ISerializer serializer, byte[] payload)
        {
            this.results = serializer.Deserialize<SmartyStreets.USEnrichmentApi.ResultTypes.Financial.Result[]>(payload);
        }
    }


}