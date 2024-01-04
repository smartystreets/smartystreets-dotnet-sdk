namespace SmartyStreets.USEnrichmentApi.LookupTypes
{
    using System;
    using System.IO;

    public abstract class Lookup
    {
        private readonly string smartyKey;
        private readonly string datasetName;
        private readonly string dataSubsetName;

        public Lookup(string smartyKey, string datasetName, string dataSubsetName)
        {
            this.smartyKey = smartyKey;
            this.datasetName = datasetName;
            this.dataSubsetName = dataSubsetName;
        }

        public string GetSmartyKey()
        {
            return smartyKey;
        }

        public string GetDatasetName()
        {
            return datasetName;
        }

        public string GetDataSubsetName()
        {
            return dataSubsetName;
        }

        public abstract void DeserializeAndSetResults(Serializer serializer, byte[] payload);
    }
}