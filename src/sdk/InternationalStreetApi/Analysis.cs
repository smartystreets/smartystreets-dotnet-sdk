using System.Runtime.Serialization;

namespace SmartyStreets.InternationalStreetApi
{
    /// <summary>
    /// See "https://smartystreets.com/docs/cloud/international-street-api#analysis"
    /// </summary>
    [DataContract]
    public class Analysis
    {
        [DataMember(Name = "verification_status")]
        public string VerificationStatus { get; private set; }

        [DataMember(Name = "address_precision")]
        public string AddressPrecision { get; private set; }

        [DataMember(Name = "max_address_precision")]
        public string MaxAddressPrecision { get; private set; }
    }
}
