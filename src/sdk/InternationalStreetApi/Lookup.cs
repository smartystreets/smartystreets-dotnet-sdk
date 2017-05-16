namespace SmartyStreets.InternationalStreetApi
{
    /// <summary>
    /// In addition to holding all of the input data for this lookup, this class also
    /// will contain the result of the lookup after it comes back from the API.
    /// </summary>
    /// <remarks>
    /// Lookups must have certain required fields set with non-blank values.
    /// These can be found at "https://smartystreets.com/docs/cloud/international-street-api#http-input-fields"
    /// </remarks>
    public class Lookup
    {
        #region [ Fields ]
        public Candidate[] Result;

        /// <remarks>
        /// Disabled by default. Set to true to enable.
        /// </remarks>
        public bool Geocode { get; set; }
        public string InputId { get; set; }
        public string Country { get; set; }
        /// <remarks>
        /// May be set to LanguageMode.NATIVE or LanguageMode.LATIN
        /// </remarks>
        public string Language { get; set; }
        /// <summary>
        /// The entire address except the country, which should be input using the Country field.
        /// </summary>
        public string Freeform { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Organization { get; set; }
        public string Locality { get; set; }
        public string AdministrativeArea { get; set; }
        public string PostalCode { get; set; }

        #endregion

        #region [ Constructors ]

        public Lookup()
        {
            this.Result = new Candidate[0];
        }

        public Lookup(string freeform, string country) : this()
        {
            this.Freeform = freeform;
            this.Country = country;
        }

        public Lookup(string address1, string postalCode, string country) : this()
        {
            this.Address1 = address1;
            this.PostalCode = postalCode;
            this.Country = country;
        }

        public Lookup(string address1, string locality, string administrativeArea, string country) : this()
        {
            this.Address1 = address1;
            this.Locality = locality;
            this.AdministrativeArea = administrativeArea;
            this.Country = country;
        }

        #endregion
    }
}