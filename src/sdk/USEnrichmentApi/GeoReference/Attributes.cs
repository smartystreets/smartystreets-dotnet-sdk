namespace SmartyStreets.USEnrichmentApi.GeoReference
{
    using System.Runtime.Serialization;

	[DataContract]
    public class Attributes
    {
        [DataMember(Name = "census_block")]
        public CensusBlock CensusBlock { get; set; }

        [DataMember(Name = "census_county_division")]
        public CensusCountyDivision CensusCountyDivision { get; set; }

        [DataMember(Name = "census_tract")]
        public CensusTract CensusTract { get; set; }

        [DataMember(Name = "core_based_stat_area")]
        public CoreBasedStatArea CoreBasedStatArea { get; set; }

        [DataMember(Name = "place")]
        public Place Place { get; set; }
    }
}