using System.Runtime.Serialization;

namespace SmartyStreets.USZipCodeApi
{
    /// <summary>
    /// See "https://smartystreets.com/docs/cloud/us-zipcode-api#zipcodes"
    /// </summary>
    [DataContract]
    public class AlternateCounty
    {
        [DataMember(Name = "county_fips")]
        public string CountyFips { get; private set; }

        [DataMember(Name = "county_name")]
        public string CountyName { get; private set; }

        [DataMember(Name = "state_abbreviation")]
        public string StateAbbreviation { get; private set; }

        [DataMember(Name = "state")]
        public string State { get; private set; }
    }
}