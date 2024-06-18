namespace SmartyStreets.USEnrichmentApi.Universal
{
    using System;
    using System.IO;
    using SmartyStreets.USEnrichmentApi.Universal;

    public class Lookup : SmartyStreets.USEnrichmentApi.Lookup
    {
        private byte[] results;

        public Lookup(string smartyKey, string dataSet, string dataSubset) : base(smartyKey, dataSet, dataSubset)
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
            // this.results = serializer.Deserialize<byte[]>(payload);
            using(var memoryStream = new MemoryStream())
            {
                payload.CopyTo(memoryStream);
                this.results = memoryStream.ToArray();
            }
        }
    }
    
}