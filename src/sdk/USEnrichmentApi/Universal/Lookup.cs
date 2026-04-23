namespace SmartyStreets.USEnrichmentApi.Universal
{
    using System.IO;

    public class Lookup : SmartyStreets.USEnrichmentApi.Lookup
    {
        private byte[] results;

        public Lookup(string smartyKey = null, string dataSet = null, string dataSubset = null) : base(smartyKey, dataSet, dataSubset)
        {
        }

        public byte[] GetResults()
        {
            return results;
        }

        public void SetResults(byte[] results)
        {
            this.results = results;
        }

        public override void DeserializeAndSetResults(SmartyStreets.ISerializer serializer, Stream payload)
        {
            using (var memoryStream = new MemoryStream())
            {
                payload.CopyTo(memoryStream);
                this.results = memoryStream.ToArray();
            }
        }
    }
}
