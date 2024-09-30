namespace SmartyStreets.USEnrichmentApi
{
    using System;
    using System.IO;

    public abstract class Lookup
    {
        private string smartyKey;
        private string datasetName;
        private string dataSubsetName;
        private string freeform;
        private string street;
        private string city;
        private string state;
        private string zipcode;
        private string includeFields;
        private string excludeFields;
        private string eTag;

        public Lookup(string smartyKey = null, string datasetName = null, string dataSubsetName = null, string freeform = null, string street = null,
        string city = null, string state = null, string zipcode = null)
        {
            this.smartyKey = smartyKey;
            this.datasetName = datasetName;
            this.dataSubsetName = dataSubsetName;
            this.freeform = freeform;
            this.street = street;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
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

        public string GetFreeform()
        {
            return freeform;
        }

        public string GetStreet()
        {
            return street;
        }

        public string GetCity()
        {
            return city;
        }

        public string GetState()
        {
            return state;
        }

        public string GetZipcode()
        {
            return zipcode;
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

        public void SetSmartyKey(string smartyKey)
        {
            this.smartyKey = smartyKey;
        }

        public void SetDatasetName(string datasetName)
        {
            this.datasetName = datasetName;
        }

        public void SetDataSubsetName(string dataSubsetName)
        {
            this.dataSubsetName = dataSubsetName;
        }

        public void SetFreeform(string freeform)
        {
            this.freeform = freeform;
        }

        public void SetStreet(string street)
        {
            this.street = street;
        }

        public void SetCity(string city)
        {
            this.city = city;
        }

        public void SetState(string state)
        {
            this.state = state;
        }

        public void SetZipcode(string zipcode)
        {
            this.zipcode = zipcode;
        }

        public abstract void DeserializeAndSetResults(SmartyStreets.ISerializer serializer, Stream payload);
    }

}