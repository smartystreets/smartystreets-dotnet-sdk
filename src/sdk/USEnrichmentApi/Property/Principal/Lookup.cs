namespace SmartyStreets.USEnrichmentApi.Property.Principal
{
    using System;
    using System.IO;
    using SmartyStreets.USEnrichmentApi.Property.Principal;

    public class Lookup : SmartyStreets.USEnrichmentApi.Lookup
    {
        private Result[] results;

        public Lookup(string smartyKey) : base(smartyKey, "property", "principal")
        {
        }

        public Result[] GetResults()
        {
            return results;
        }

        public void SetResults(Result[] results)
        {
            this.results = results;
        }

        public override void DeserializeAndSetResults(SmartyStreets.ISerializer serializer, Stream payload)
        {
            this.results = serializer.Deserialize<Result[]>(payload);
        }
    }
}