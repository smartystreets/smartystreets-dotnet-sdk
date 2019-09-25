namespace SmartyStreets.InternationalStreetApi
{
    using System.Runtime.Serialization;
    
    [DataContract]
    public class RootLevel
    {
        #region [ Fields ]
        
        [DataMember(Name = "input_id")]
        public string InputId { get; set; }
        
        [DataMember(Name = "organization")]
        public string Organization { get; set; }

        [DataMember(Name = "address1")]
        public string Address1 { get; set; }

        [DataMember(Name = "address2")]
        public string Address2 { get; set; }

        [DataMember(Name = "address3")]
        public string Address3 { get; set; }

        [DataMember(Name = "address4")]
        public string Address4 { get; set; }

        [DataMember(Name = "address5")]
        public string Address5 { get; set; }

        [DataMember(Name = "address6")]
        public string Address6 { get; set; }

        [DataMember(Name = "address7")]
        public string Address7 { get; set; }

        [DataMember(Name = "address8")]
        public string Address8 { get; set; }

        [DataMember(Name = "address9")]
        public string Address9 { get; set; }

        [DataMember(Name = "address10")]
        public string Address10 { get; set; }

        [DataMember(Name = "address11")]
        public string Address11 { get; set; }

        [DataMember(Name = "address12")]
        public string Address12 { get; set; }
        
        #endregion
    }
}