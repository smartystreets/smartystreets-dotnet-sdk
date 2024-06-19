namespace SmartyStreets.USEnrichmentApi.GeoReference
{
    using System;
    using System.IO;
    using SmartyStreets.USEnrichmentApi.GeoReference;

    public class Lookup : SmartyStreets.USEnrichmentApi.Lookup
    {
        private Result[] results;

        public Lookup(string smartyKey) : base(smartyKey, "geo-reference", "")
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
            this.results[0].Etag = this.GetEtag();
        }
    }
}