using System.Runtime.Serialization;

namespace SmartyStreets.InternationalStreetApi
{
    /// <summary>
    /// See "https://smartystreets.com/docs/cloud/international-street-api#metadata"
    /// </summary>
    [DataContract]
    public class Metadata
    {
        #region [ Fields ]

        [DataMember(Name = "latitude")]
        public double Latitude;

        [DataMember(Name = "longitude")]
        public double Longitude;

        [DataMember(Name = "geocode_precision")]
        public string GeocodePrecision;

        [DataMember(Name = "max_geocode_precision")]
        public string MaxGeocodePrecision;

        #endregion
    }
}