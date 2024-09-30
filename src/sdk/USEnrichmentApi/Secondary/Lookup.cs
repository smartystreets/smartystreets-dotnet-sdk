namespace SmartyStreets.USEnrichmentApi.Secondary
{
    using System;
    using System.IO;
    using SmartyStreets.USEnrichmentApi.Secondary;

    public class Lookup : SmartyStreets.USEnrichmentApi.Lookup
    {
        private Result[] results;

        public Lookup(string smartyKey = null) : base(smartyKey, "secondary", "")
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
            if (this.results != null) {
                this.results[0].Etag = this.GetEtag();
            }
        }
    }
}