namespace SmartyStreets.USEnrichmentApi
{
    using System.Collections.Generic;
    using System.IO;

    public abstract class EnrichmentLookupBase
    {
        private string includeFields;
        private string excludeFields;
        private string requestEtag;
        private string responseEtag;
        public Dictionary<string, string> CustomParamDict = new Dictionary<string, string>();

        public string GetIncludeFields()
        {
            return includeFields;
        }

        public void SetIncludeFields(string includeFields)
        {
            this.includeFields = includeFields;
        }

        public string GetExcludeFields()
        {
            return excludeFields;
        }

        public void SetExcludeFields(string excludeFields)
        {
            this.excludeFields = excludeFields;
        }

        public string GetRequestEtag()
        {
            return requestEtag;
        }

        public void SetRequestEtag(string requestEtag)
        {
            this.requestEtag = requestEtag;
        }

        public string GetResponseEtag()
        {
            return responseEtag;
        }

        public void SetResponseEtag(string responseEtag)
        {
            this.responseEtag = responseEtag;
        }

        public void AddCustomParameter(string parameter, string value)
        {
            CustomParamDict.Add(parameter, value);
        }

        public Dictionary<string, string> GetCustomParameters()
        {
            return CustomParamDict;
        }

        public abstract void DeserializeAndSetResults(ISerializer serializer, Stream payload);
    }
}
