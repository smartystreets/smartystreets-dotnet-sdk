namespace SmartyStreets.USEnrichmentApi.ResultTypes.Property.Principal
{
    public class Result
    {
        [JsonProperty("smarty_key")]
        public string SmartyKey { get; set; }

        [JsonProperty("data_set_name")]
        public string DataSetName { get; set; }

        [JsonProperty("data_subset_name")]
        public string DataSubsetName { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }
}