namespace SmartyStreets.USEnrichmentApi.Business.Detail
{
    using System.IO;

    public class Lookup : SmartyStreets.USEnrichmentApi.EnrichmentLookupBase
    {
        private string businessId;
        private Result result;

        public Lookup(string businessId)
        {
            this.businessId = businessId;
        }

        public string GetBusinessId()
        {
            return businessId;
        }

        public void SetBusinessId(string businessId)
        {
            this.businessId = businessId;
        }

        public Result GetResult()
        {
            return result;
        }

        public void SetResult(Result result)
        {
            this.result = result;
        }

        // The detail endpoint returns a one-element array on success; >1 element is a server-contract violation.
        public override void DeserializeAndSetResults(SmartyStreets.ISerializer serializer, Stream payload)
        {
            var results = serializer.Deserialize<Result[]>(payload);
            if (results == null || results.Length == 0)
            {
                this.result = null;
                return;
            }
            if (results.Length > 1)
            {
                throw new SmartyStreets.SmartyException(
                    "business detail response contained " + results.Length + " results; expected at most 1");
            }
            this.result = results[0];
        }
    }
}
