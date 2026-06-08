namespace SmartyStreets.InternationalStreetApi
{
    using System.Runtime.Serialization;
    
    [DataContract]
    public class Changes : RootLevel
    {
        [DataMember(Name = "country")]
        public string Country { get; set; }

        [DataMember(Name = "components")]
        public Components Components { get; set; }
    }
}