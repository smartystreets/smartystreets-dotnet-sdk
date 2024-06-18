namespace SmartyStreets.USEnrichmentApi
{
    using System;
    using System.IO;

    public abstract class Lookup
    {
        private readonly string smartyKey;
        private readonly string datasetName;
        private readonly string dataSubsetName;
        private string includeFields;
        private string excludeFields;
        private string eTag;

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

        public string GetIncludeFields()
        {
            return includeFields;
        }

        public string GetExcludeFields()
        {
            return excludeFields;
        }

        public string GetEtag()
        {
            return eTag;
        }

        public void SetIncludeFields(string includeFields)
        {
            this.includeFields = includeFields;
        }

        public void SetExcludeFields(string excludeFields)
        {
            this.excludeFields = excludeFields;
        }

        public void SetEtag(string eTag)
        {
            this.eTag = eTag;
        }

        public abstract void DeserializeAndSetResults(SmartyStreets.ISerializer serializer, Stream payload);
    }

}