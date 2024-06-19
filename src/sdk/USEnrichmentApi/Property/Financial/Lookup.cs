namespace SmartyStreets.USEnrichmentApi.Property.Financial
{
    using System;
    using System.IO;

    public class Lookup : SmartyStreets.USEnrichmentApi.Lookup
    {
        private Result[] results;

        public Lookup(string smartyKey) : base(smartyKey, "property", "financial")
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