namespace SmartyStreets.USEnrichmentApi.Risk
{
    using System.Runtime.Serialization;

	[DataContract]
    public class Attributes
    {
        [DataMember(Name = "AGRIVALUE")]
        public string AGRIVALUE { get; set; }

        [DataMember(Name = "ALR_NPCTL")]
        public string ALR_NPCTL { get; set; }

        [DataMember(Name = "ALR_VALA")]
        public string ALR_VALA { get; set; }

        [DataMember(Name = "ALR_VALB")]
        public string ALR_VALB { get; set; }

        [DataMember(Name = "ALR_VALP")]
        public string ALR_VALP { get; set; }

        [DataMember(Name = "ALR_VRA_NPCTL")]
        public string ALR_VRA_NPCTL { get; set; }

        [DataMember(Name = "AREA")]
        public string AREA { get; set; }

        [DataMember(Name = "AVLN_AFREQ")]
        public string AVLN_AFREQ { get; set; }

        [DataMember(Name = "AVLN_ALRB")]
        public string AVLN_ALRB { get; set; }

        [DataMember(Name = "AVLN_ALRP")]
        public string AVLN_ALRP { get; set; }

        [DataMember(Name = "AVLN_ALR_NPCTL")]
        public string AVLN_ALR_NPCTL { get; set; }

        [DataMember(Name = "AVLN_EALB")]
        public string AVLN_EALB { get; set; }

        [DataMember(Name = "AVLN_EALP")]
        public string AVLN_EALP { get; set; }

        [DataMember(Name = "AVLN_EALPE")]
        public string AVLN_EALPE { get; set; }

        [DataMember(Name = "AVLN_EALR")]
        public string AVLN_EALR { get; set; }

        [DataMember(Name = "AVLN_EALS")]
        public string AVLN_EALS { get; set; }

        [DataMember(Name = "AVLN_EALT")]
        public string AVLN_EALT { get; set; }

        [DataMember(Name = "AVLN_EVNTS")]
        public string AVLN_EVNTS { get; set; }

        [DataMember(Name = "AVLN_EXPB")]
        public string AVLN_EXPB { get; set; }

        [DataMember(Name = "AVLN_EXPP")]
        public string AVLN_EXPP { get; set; }

        [DataMember(Name = "AVLN_EXPPE")]
        public string AVLN_EXPPE { get; set; }

        [DataMember(Name = "AVLN_EXPT")]
        public string AVLN_EXPT { get; set; }

        [DataMember(Name = "AVLN_EXP_AREA")]
        public string AVLN_EXP_AREA { get; set; }

        [DataMember(Name = "AVLN_HLRB")]
        public string AVLN_HLRB { get; set; }

        [DataMember(Name = "AVLN_HLRP")]
        public string AVLN_HLRP { get; set; }

        [DataMember(Name = "AVLN_HLRR")]
        public string AVLN_HLRR { get; set; }

        [DataMember(Name = "AVLN_RISKR")]
        public string AVLN_RISKR { get; set; }

        [DataMember(Name = "AVLN_RISKS")]
        public string AVLN_RISKS { get; set; }

        [DataMember(Name = "AVLN_RISKV")]
        public string AVLN_RISKV { get; set; }

        [DataMember(Name = "BUILDVALUE")]
        public string BUILDVALUE { get; set; }

        [DataMember(Name = "CFLD_AFREQ")]
        public string CFLD_AFREQ { get; set; }

        [DataMember(Name = "CFLD_ALRB")]
        public string CFLD_ALRB { get; set; }

        [DataMember(Name = "CFLD_ALRP")]
        public string CFLD_ALRP { get; set; }

        [DataMember(Name = "CFLD_ALR_NPCTL")]
        public string CFLD_ALR_NPCTL { get; set; }

        [DataMember(Name = "CFLD_EALB")]
        public string CFLD_EALB { get; set; }

        [DataMember(Name = "CFLD_EALP")]
        public string CFLD_EALP { get; set; }

        [DataMember(Name = "CFLD_EALPE")]
        public string CFLD_EALPE { get; set; }

        [DataMember(Name = "CFLD_EALR")]
        public string CFLD_EALR { get; set; }

        [DataMember(Name = "CFLD_EALS")]
        public string CFLD_EALS { get; set; }

        [DataMember(Name = "CFLD_EALT")]
        public string CFLD_EALT { get; set; }

        [DataMember(Name = "CFLD_EVNTS")]
        public string CFLD_EVNTS { get; set; }

        [DataMember(Name = "CFLD_EXPB")]
        public string CFLD_EXPB { get; set; }

        [DataMember(Name = "CFLD_EXPP")]
        public string CFLD_EXPP { get; set; }

        [DataMember(Name = "CFLD_EXPPE")]
        public string CFLD_EXPPE { get; set; }

        [DataMember(Name = "CFLD_EXPT")]
        public string CFLD_EXPT { get; set; }

        [DataMember(Name = "CFLD_EXP_AREA")]
        public string CFLD_EXP_AREA { get; set; }

        [DataMember(Name = "CFLD_HLRB")]
        public string CFLD_HLRB { get; set; }

        [DataMember(Name = "CFLD_HLRP")]
        public string CFLD_HLRP { get; set; }

        [DataMember(Name = "CFLD_HLRR")]
        public string CFLD_HLRR { get; set; }

        [DataMember(Name = "CFLD_RISKR")]
        public string CFLD_RISKR { get; set; }

        [DataMember(Name = "CFLD_RISKS")]
        public string CFLD_RISKS { get; set; }

        [DataMember(Name = "CFLD_RISKV")]
        public string CFLD_RISKV { get; set; }

        [DataMember(Name = "COUNTY")]
        public string COUNTY { get; set; }

        [DataMember(Name = "COUNTYFIPS")]
        public string COUNTYFIPS { get; set; }

        [DataMember(Name = "COUNTYTYPE")]
        public string COUNTYTYPE { get; set; }

        [DataMember(Name = "CRF_VALUE")]
        public string CRF_VALUE { get; set; }

        [DataMember(Name = "CWAV_AFREQ")]
        public string CWAV_AFREQ { get; set; }

        [DataMember(Name = "CWAV_ALRA")]
        public string CWAV_ALRA { get; set; }

        [DataMember(Name = "CWAV_ALRB")]
        public string CWAV_ALRB { get; set; }

        [DataMember(Name = "CWAV_ALRP")]
        public string CWAV_ALRP { get; set; }

        [DataMember(Name = "CWAV_ALR_NPCTL")]
        public string CWAV_ALR_NPCTL { get; set; }

        [DataMember(Name = "CWAV_EALA")]
        public string CWAV_EALA { get; set; }

        [DataMember(Name = "CWAV_EALB")]
        public string CWAV_EALB { get; set; }

        [DataMember(Name = "CWAV_EALP")]
        public string CWAV_EALP { get; set; }

        [DataMember(Name = "CWAV_EALPE")]
        public string CWAV_EALPE { get; set; }

        [DataMember(Name = "CWAV_EALR")]
        public string CWAV_EALR { get; set; }

        [DataMember(Name = "CWAV_EALS")]
        public string CWAV_EALS { get; set; }

        [DataMember(Name = "CWAV_EALT")]
        public string CWAV_EALT { get; set; }

        [DataMember(Name = "CWAV_EVNTS")]
        public string CWAV_EVNTS { get; set; }

        [DataMember(Name = "CWAV_EXPA")]
        public string CWAV_EXPA { get; set; }

        [DataMember(Name = "CWAV_EXPB")]
        public string CWAV_EXPB { get; set; }

        [DataMember(Name = "CWAV_EXPP")]
        public string CWAV_EXPP { get; set; }

        [DataMember(Name = "CWAV_EXPPE")]
        public string CWAV_EXPPE { get; set; }

        [DataMember(Name = "CWAV_EXPT")]
        public string CWAV_EXPT { get; set; }

        [DataMember(Name = "CWAV_EXP_AREA")]
        public string CWAV_EXP_AREA { get; set; }

        [DataMember(Name = "CWAV_HLRA")]
        public string CWAV_HLRA { get; set; }

        [DataMember(Name = "CWAV_HLRB")]
        public string CWAV_HLRB { get; set; }

        [DataMember(Name = "CWAV_HLRP")]
        public string CWAV_HLRP { get; set; }

        [DataMember(Name = "CWAV_HLRR")]
        public string CWAV_HLRR { get; set; }

        [DataMember(Name = "CWAV_RISKR")]
        public string CWAV_RISKR { get; set; }

        [DataMember(Name = "CWAV_RISKS")]
        public string CWAV_RISKS { get; set; }

        [DataMember(Name = "CWAV_RISKV")]
        public string CWAV_RISKV { get; set; }

        [DataMember(Name = "DRGT_AFREQ")]
        public string DRGT_AFREQ { get; set; }

        [DataMember(Name = "DRGT_ALRA")]
        public string DRGT_ALRA { get; set; }

        [DataMember(Name = "DRGT_ALR_NPCTL")]
        public string DRGT_ALR_NPCTL { get; set; }

        [DataMember(Name = "DRGT_EALA")]
        public string DRGT_EALA { get; set; }

        [DataMember(Name = "DRGT_EALR")]
        public string DRGT_EALR { get; set; }

        [DataMember(Name = "DRGT_EALS")]
        public string DRGT_EALS { get; set; }

        [DataMember(Name = "DRGT_EALT")]
        public string DRGT_EALT { get; set; }

        [DataMember(Name = "DRGT_EVNTS")]
        public string DRGT_EVNTS { get; set; }

        [DataMember(Name = "DRGT_EXPA")]
        public string DRGT_EXPA { get; set; }

        [DataMember(Name = "DRGT_EXPT")]
        public string DRGT_EXPT { get; set; }

        [DataMember(Name = "DRGT_EXP_AREA")]
        public string DRGT_EXP_AREA { get; set; }

        [DataMember(Name = "DRGT_HLRA")]
        public string DRGT_HLRA { get; set; }

        [DataMember(Name = "DRGT_HLRR")]
        public string DRGT_HLRR { get; set; }

        [DataMember(Name = "DRGT_RISKR")]
        public string DRGT_RISKR { get; set; }

        [DataMember(Name = "DRGT_RISKS")]
        public string DRGT_RISKS { get; set; }

        [DataMember(Name = "DRGT_RISKV")]
        public string DRGT_RISKV { get; set; }

        [DataMember(Name = "EAL_RATNG")]
        public string EAL_RATNG { get; set; }

        [DataMember(Name = "EAL_SCORE")]
        public string EAL_SCORE { get; set; }

        [DataMember(Name = "EAL_SPCTL")]
        public string EAL_SPCTL { get; set; }

        [DataMember(Name = "EAL_VALA")]
        public string EAL_VALA { get; set; }

        [DataMember(Name = "EAL_VALB")]
        public string EAL_VALB { get; set; }

        [DataMember(Name = "EAL_VALP")]
        public string EAL_VALP { get; set; }

        [DataMember(Name = "EAL_VALPE")]
        public string EAL_VALPE { get; set; }

        [DataMember(Name = "EAL_VALT")]
        public string EAL_VALT { get; set; }

        [DataMember(Name = "ERQK_AFREQ")]
        public string ERQK_AFREQ { get; set; }

        [DataMember(Name = "ERQK_ALRB")]
        public string ERQK_ALRB { get; set; }

        [DataMember(Name = "ERQK_ALRP")]
        public string ERQK_ALRP { get; set; }

        [DataMember(Name = "ERQK_ALR_NPCTL")]
        public string ERQK_ALR_NPCTL { get; set; }

        [DataMember(Name = "ERQK_EALB")]
        public string ERQK_EALB { get; set; }

        [DataMember(Name = "ERQK_EALP")]
        public string ERQK_EALP { get; set; }

        [DataMember(Name = "ERQK_EALPE")]
        public string ERQK_EALPE { get; set; }

        [DataMember(Name = "ERQK_EALR")]
        public string ERQK_EALR { get; set; }

        [DataMember(Name = "ERQK_EALS")]
        public string ERQK_EALS { get; set; }

        [DataMember(Name = "ERQK_EALT")]
        public string ERQK_EALT { get; set; }

        [DataMember(Name = "ERQK_EVNTS")]
        public string ERQK_EVNTS { get; set; }

        [DataMember(Name = "ERQK_EXPB")]
        public string ERQK_EXPB { get; set; }

        [DataMember(Name = "ERQK_EXPP")]
        public string ERQK_EXPP { get; set; }

        [DataMember(Name = "ERQK_EXPPE")]
        public string ERQK_EXPPE { get; set; }

        [DataMember(Name = "ERQK_EXPT")]
        public string ERQK_EXPT { get; set; }

        [DataMember(Name = "ERQK_EXP_AREA")]
        public string ERQK_EXP_AREA { get; set; }

        [DataMember(Name = "ERQK_HLRB")]
        public string ERQK_HLRB { get; set; }

        [DataMember(Name = "ERQK_HLRP")]
        public string ERQK_HLRP { get; set; }

        [DataMember(Name = "ERQK_HLRR")]
        public string ERQK_HLRR { get; set; }

        [DataMember(Name = "ERQK_RISKR")]
        public string ERQK_RISKR { get; set; }

        [DataMember(Name = "ERQK_RISKS")]
        public string ERQK_RISKS { get; set; }

        [DataMember(Name = "ERQK_RISKV")]
        public string ERQK_RISKV { get; set; }

        [DataMember(Name = "HAIL_AFREQ")]
        public string HAIL_AFREQ { get; set; }

        [DataMember(Name = "HAIL_ALRA")]
        public string HAIL_ALRA { get; set; }

        [DataMember(Name = "HAIL_ALRB")]
        public string HAIL_ALRB { get; set; }

        [DataMember(Name = "HAIL_ALRP")]
        public string HAIL_ALRP { get; set; }

        [DataMember(Name = "HAIL_ALR_NPCTL")]
        public string HAIL_ALR_NPCTL { get; set; }

        [DataMember(Name = "HAIL_EALA")]
        public string HAIL_EALA { get; set; }

        [DataMember(Name = "HAIL_EALB")]
        public string HAIL_EALB { get; set; }

        [DataMember(Name = "HAIL_EALP")]
        public string HAIL_EALP { get; set; }

        [DataMember(Name = "HAIL_EALPE")]
        public string HAIL_EALPE { get; set; }

        [DataMember(Name = "HAIL_EALR")]
        public string HAIL_EALR { get; set; }

        [DataMember(Name = "HAIL_EALS")]
        public string HAIL_EALS { get; set; }

        [DataMember(Name = "HAIL_EALT")]
        public string HAIL_EALT { get; set; }

        [DataMember(Name = "HAIL_EVNTS")]
        public string HAIL_EVNTS { get; set; }

        [DataMember(Name = "HAIL_EXPA")]
        public string HAIL_EXPA { get; set; }

        [DataMember(Name = "HAIL_EXPB")]
        public string HAIL_EXPB { get; set; }

        [DataMember(Name = "HAIL_EXPP")]
        public string HAIL_EXPP { get; set; }

        [DataMember(Name = "HAIL_EXPPE")]
        public string HAIL_EXPPE { get; set; }

        [DataMember(Name = "HAIL_EXPT")]
        public string HAIL_EXPT { get; set; }

        [DataMember(Name = "HAIL_EXP_AREA")]
        public string HAIL_EXP_AREA { get; set; }

        [DataMember(Name = "HAIL_HLRA")]
        public string HAIL_HLRA { get; set; }

        [DataMember(Name = "HAIL_HLRB")]
        public string HAIL_HLRB { get; set; }

        [DataMember(Name = "HAIL_HLRP")]
        public string HAIL_HLRP { get; set; }

        [DataMember(Name = "HAIL_HLRR")]
        public string HAIL_HLRR { get; set; }

        [DataMember(Name = "HAIL_RISKR")]
        public string HAIL_RISKR { get; set; }

        [DataMember(Name = "HAIL_RISKS")]
        public string HAIL_RISKS { get; set; }

        [DataMember(Name = "HAIL_RISKV")]
        public string HAIL_RISKV { get; set; }

        [DataMember(Name = "HRCN_AFREQ")]
        public string HRCN_AFREQ { get; set; }

        [DataMember(Name = "HRCN_ALRA")]
        public string HRCN_ALRA { get; set; }

        [DataMember(Name = "HRCN_ALRB")]
        public string HRCN_ALRB { get; set; }

        [DataMember(Name = "HRCN_ALRP")]
        public string HRCN_ALRP { get; set; }

        [DataMember(Name = "HRCN_ALR_NPCTL")]
        public string HRCN_ALR_NPCTL { get; set; }

        [DataMember(Name = "HRCN_EALA")]
        public string HRCN_EALA { get; set; }

        [DataMember(Name = "HRCN_EALB")]
        public string HRCN_EALB { get; set; }

        [DataMember(Name = "HRCN_EALP")]
        public string HRCN_EALP { get; set; }

        [DataMember(Name = "HRCN_EALPE")]
        public string HRCN_EALPE { get; set; }

        [DataMember(Name = "HRCN_EALR")]
        public string HRCN_EALR { get; set; }

        [DataMember(Name = "HRCN_EALS")]
        public string HRCN_EALS { get; set; }

        [DataMember(Name = "HRCN_EALT")]
        public string HRCN_EALT { get; set; }

        [DataMember(Name = "HRCN_EVNTS")]
        public string HRCN_EVNTS { get; set; }

        [DataMember(Name = "HRCN_EXPA")]
        public string HRCN_EXPA { get; set; }

        [DataMember(Name = "HRCN_EXPB")]
        public string HRCN_EXPB { get; set; }

        [DataMember(Name = "HRCN_EXPP")]
        public string HRCN_EXPP { get; set; }

        [DataMember(Name = "HRCN_EXPPE")]
        public string HRCN_EXPPE { get; set; }

        [DataMember(Name = "HRCN_EXPT")]
        public string HRCN_EXPT { get; set; }

        [DataMember(Name = "HRCN_EXP_AREA")]
        public string HRCN_EXP_AREA { get; set; }

        [DataMember(Name = "HRCN_HLRA")]
        public string HRCN_HLRA { get; set; }

        [DataMember(Name = "HRCN_HLRB")]
        public string HRCN_HLRB { get; set; }

        [DataMember(Name = "HRCN_HLRP")]
        public string HRCN_HLRP { get; set; }

        [DataMember(Name = "HRCN_HLRR")]
        public string HRCN_HLRR { get; set; }

        [DataMember(Name = "HRCN_RISKR")]
        public string HRCN_RISKR { get; set; }

        [DataMember(Name = "HRCN_RISKS")]
        public string HRCN_RISKS { get; set; }

        [DataMember(Name = "HRCN_RISKV")]
        public string HRCN_RISKV { get; set; }

        [DataMember(Name = "HWAV_AFREQ")]
        public string HWAV_AFREQ { get; set; }

        [DataMember(Name = "HWAV_ALRA")]
        public string HWAV_ALRA { get; set; }

        [DataMember(Name = "HWAV_ALRB")]
        public string HWAV_ALRB { get; set; }

        [DataMember(Name = "HWAV_ALRP")]
        public string HWAV_ALRP { get; set; }

        [DataMember(Name = "HWAV_ALR_NPCTL")]
        public string HWAV_ALR_NPCTL { get; set; }

        [DataMember(Name = "HWAV_EALA")]
        public string HWAV_EALA { get; set; }

        [DataMember(Name = "HWAV_EALB")]
        public string HWAV_EALB { get; set; }

        [DataMember(Name = "HWAV_EALP")]
        public string HWAV_EALP { get; set; }

        [DataMember(Name = "HWAV_EALPE")]
        public string HWAV_EALPE { get; set; }

        [DataMember(Name = "HWAV_EALR")]
        public string HWAV_EALR { get; set; }

        [DataMember(Name = "HWAV_EALS")]
        public string HWAV_EALS { get; set; }

        [DataMember(Name = "HWAV_EALT")]
        public string HWAV_EALT { get; set; }

        [DataMember(Name = "HWAV_EVNTS")]
        public string HWAV_EVNTS { get; set; }

        [DataMember(Name = "HWAV_EXPA")]
        public string HWAV_EXPA { get; set; }

        [DataMember(Name = "HWAV_EXPB")]
        public string HWAV_EXPB { get; set; }

        [DataMember(Name = "HWAV_EXPP")]
        public string HWAV_EXPP { get; set; }

        [DataMember(Name = "HWAV_EXPPE")]
        public string HWAV_EXPPE { get; set; }

        [DataMember(Name = "HWAV_EXPT")]
        public string HWAV_EXPT { get; set; }

        [DataMember(Name = "HWAV_EXP_AREA")]
        public string HWAV_EXP_AREA { get; set; }

        [DataMember(Name = "HWAV_HLRA")]
        public string HWAV_HLRA { get; set; }

        [DataMember(Name = "HWAV_HLRB")]
        public string HWAV_HLRB { get; set; }

        [DataMember(Name = "HWAV_HLRP")]
        public string HWAV_HLRP { get; set; }

        [DataMember(Name = "HWAV_HLRR")]
        public string HWAV_HLRR { get; set; }

        [DataMember(Name = "HWAV_RISKR")]
        public string HWAV_RISKR { get; set; }

        [DataMember(Name = "HWAV_RISKS")]
        public string HWAV_RISKS { get; set; }

        [DataMember(Name = "HWAV_RISKV")]
        public string HWAV_RISKV { get; set; }

        [DataMember(Name = "ISTM_AFREQ")]
        public string ISTM_AFREQ { get; set; }

        [DataMember(Name = "ISTM_ALRB")]
        public string ISTM_ALRB { get; set; }

        [DataMember(Name = "ISTM_ALRP")]
        public string ISTM_ALRP { get; set; }

        [DataMember(Name = "ISTM_ALR_NPCTL")]
        public string ISTM_ALR_NPCTL { get; set; }

        [DataMember(Name = "ISTM_EALB")]
        public string ISTM_EALB { get; set; }

        [DataMember(Name = "ISTM_EALP")]
        public string ISTM_EALP { get; set; }

        [DataMember(Name = "ISTM_EALPE")]
        public string ISTM_EALPE { get; set; }

        [DataMember(Name = "ISTM_EALR")]
        public string ISTM_EALR { get; set; }

        [DataMember(Name = "ISTM_EALS")]
        public string ISTM_EALS { get; set; }

        [DataMember(Name = "ISTM_EALT")]
        public string ISTM_EALT { get; set; }

        [DataMember(Name = "ISTM_EVNTS")]
        public string ISTM_EVNTS { get; set; }

        [DataMember(Name = "ISTM_EXPB")]
        public string ISTM_EXPB { get; set; }

        [DataMember(Name = "ISTM_EXPP")]
        public string ISTM_EXPP { get; set; }

        [DataMember(Name = "ISTM_EXPPE")]
        public string ISTM_EXPPE { get; set; }

        [DataMember(Name = "ISTM_EXPT")]
        public string ISTM_EXPT { get; set; }

        [DataMember(Name = "ISTM_EXP_AREA")]
        public string ISTM_EXP_AREA { get; set; }

        [DataMember(Name = "ISTM_HLRB")]
        public string ISTM_HLRB { get; set; }

        [DataMember(Name = "ISTM_HLRP")]
        public string ISTM_HLRP { get; set; }

        [DataMember(Name = "ISTM_HLRR")]
        public string ISTM_HLRR { get; set; }

        [DataMember(Name = "ISTM_RISKR")]
        public string ISTM_RISKR { get; set; }

        [DataMember(Name = "ISTM_RISKS")]
        public string ISTM_RISKS { get; set; }

        [DataMember(Name = "ISTM_RISKV")]
        public string ISTM_RISKV { get; set; }

        [DataMember(Name = "LNDS_AFREQ")]
        public string LNDS_AFREQ { get; set; }

        [DataMember(Name = "LNDS_ALRB")]
        public string LNDS_ALRB { get; set; }

        [DataMember(Name = "LNDS_ALRP")]
        public string LNDS_ALRP { get; set; }

        [DataMember(Name = "LNDS_ALR_NPCTL")]
        public string LNDS_ALR_NPCTL { get; set; }

        [DataMember(Name = "LNDS_EALB")]
        public string LNDS_EALB { get; set; }

        [DataMember(Name = "LNDS_EALP")]
        public string LNDS_EALP { get; set; }

        [DataMember(Name = "LNDS_EALPE")]
        public string LNDS_EALPE { get; set; }

        [DataMember(Name = "LNDS_EALR")]
        public string LNDS_EALR { get; set; }

        [DataMember(Name = "LNDS_EALS")]
        public string LNDS_EALS { get; set; }

        [DataMember(Name = "LNDS_EALT")]
        public string LNDS_EALT { get; set; }

        [DataMember(Name = "LNDS_EVNTS")]
        public string LNDS_EVNTS { get; set; }

        [DataMember(Name = "LNDS_EXPB")]
        public string LNDS_EXPB { get; set; }

        [DataMember(Name = "LNDS_EXPP")]
        public string LNDS_EXPP { get; set; }

        [DataMember(Name = "LNDS_EXPPE")]
        public string LNDS_EXPPE { get; set; }

        [DataMember(Name = "LNDS_EXPT")]
        public string LNDS_EXPT { get; set; }

        [DataMember(Name = "LNDS_EXP_AREA")]
        public string LNDS_EXP_AREA { get; set; }

        [DataMember(Name = "LNDS_HLRB")]
        public string LNDS_HLRB { get; set; }

        [DataMember(Name = "LNDS_HLRP")]
        public string LNDS_HLRP { get; set; }

        [DataMember(Name = "LNDS_HLRR")]
        public string LNDS_HLRR { get; set; }

        [DataMember(Name = "LNDS_RISKR")]
        public string LNDS_RISKR { get; set; }

        [DataMember(Name = "LNDS_RISKS")]
        public string LNDS_RISKS { get; set; }

        [DataMember(Name = "LNDS_RISKV")]
        public string LNDS_RISKV { get; set; }

        [DataMember(Name = "LTNG_AFREQ")]
        public string LTNG_AFREQ { get; set; }

        [DataMember(Name = "LTNG_ALRB")]
        public string LTNG_ALRB { get; set; }

        [DataMember(Name = "LTNG_ALRP")]
        public string LTNG_ALRP { get; set; }

        [DataMember(Name = "LTNG_ALR_NPCTL")]
        public string LTNG_ALR_NPCTL { get; set; }

        [DataMember(Name = "LTNG_EALB")]
        public string LTNG_EALB { get; set; }

        [DataMember(Name = "LTNG_EALP")]
        public string LTNG_EALP { get; set; }

        [DataMember(Name = "LTNG_EALPE")]
        public string LTNG_EALPE { get; set; }

        [DataMember(Name = "LTNG_EALR")]
        public string LTNG_EALR { get; set; }

        [DataMember(Name = "LTNG_EALS")]
        public string LTNG_EALS { get; set; }

        [DataMember(Name = "LTNG_EALT")]
        public string LTNG_EALT { get; set; }

        [DataMember(Name = "LTNG_EVNTS")]
        public string LTNG_EVNTS { get; set; }

        [DataMember(Name = "LTNG_EXPB")]
        public string LTNG_EXPB { get; set; }

        [DataMember(Name = "LTNG_EXPP")]
        public string LTNG_EXPP { get; set; }

        [DataMember(Name = "LTNG_EXPPE")]
        public string LTNG_EXPPE { get; set; }

        [DataMember(Name = "LTNG_EXPT")]
        public string LTNG_EXPT { get; set; }

        [DataMember(Name = "LTNG_EXP_AREA")]
        public string LTNG_EXP_AREA { get; set; }

        [DataMember(Name = "LTNG_HLRB")]
        public string LTNG_HLRB { get; set; }

        [DataMember(Name = "LTNG_HLRP")]
        public string LTNG_HLRP { get; set; }

        [DataMember(Name = "LTNG_HLRR")]
        public string LTNG_HLRR { get; set; }

        [DataMember(Name = "LTNG_RISKR")]
        public string LTNG_RISKR { get; set; }

        [DataMember(Name = "LTNG_RISKS")]
        public string LTNG_RISKS { get; set; }

        [DataMember(Name = "LTNG_RISKV")]
        public string LTNG_RISKV { get; set; }

        [DataMember(Name = "NRI_VER")]
        public string NRI_VER { get; set; }

        [DataMember(Name = "POPULATION")]
        public string POPULATION { get; set; }

        [DataMember(Name = "RESL_RATNG")]
        public string RESL_RATNG { get; set; }

        [DataMember(Name = "RESL_SCORE")]
        public string RESL_SCORE { get; set; }

        [DataMember(Name = "RESL_SPCTL")]
        public string RESL_SPCTL { get; set; }

        [DataMember(Name = "RESL_VALUE")]
        public string RESL_VALUE { get; set; }

        [DataMember(Name = "RFLD_AFREQ")]
        public string RFLD_AFREQ { get; set; }

        [DataMember(Name = "RFLD_ALRA")]
        public string RFLD_ALRA { get; set; }

        [DataMember(Name = "RFLD_ALRB")]
        public string RFLD_ALRB { get; set; }

        [DataMember(Name = "RFLD_ALRP")]
        public string RFLD_ALRP { get; set; }

        [DataMember(Name = "RFLD_ALR_NPCTL")]
        public string RFLD_ALR_NPCTL { get; set; }

        [DataMember(Name = "RFLD_EALA")]
        public string RFLD_EALA { get; set; }

        [DataMember(Name = "RFLD_EALB")]
        public string RFLD_EALB { get; set; }

        [DataMember(Name = "RFLD_EALP")]
        public string RFLD_EALP { get; set; }

        [DataMember(Name = "RFLD_EALPE")]
        public string RFLD_EALPE { get; set; }

        [DataMember(Name = "RFLD_EALR")]
        public string RFLD_EALR { get; set; }

        [DataMember(Name = "RFLD_EALS")]
        public string RFLD_EALS { get; set; }

        [DataMember(Name = "RFLD_EALT")]
        public string RFLD_EALT { get; set; }

        [DataMember(Name = "RFLD_EVNTS")]
        public string RFLD_EVNTS { get; set; }

        [DataMember(Name = "RFLD_EXPA")]
        public string RFLD_EXPA { get; set; }

        [DataMember(Name = "RFLD_EXPB")]
        public string RFLD_EXPB { get; set; }

        [DataMember(Name = "RFLD_EXPP")]
        public string RFLD_EXPP { get; set; }

        [DataMember(Name = "RFLD_EXPPE")]
        public string RFLD_EXPPE { get; set; }

        [DataMember(Name = "RFLD_EXPT")]
        public string RFLD_EXPT { get; set; }

        [DataMember(Name = "RFLD_EXP_AREA")]
        public string RFLD_EXP_AREA { get; set; }

        [DataMember(Name = "RFLD_HLRA")]
        public string RFLD_HLRA { get; set; }

        [DataMember(Name = "RFLD_HLRB")]
        public string RFLD_HLRB { get; set; }

        [DataMember(Name = "RFLD_HLRP")]
        public string RFLD_HLRP { get; set; }

        [DataMember(Name = "RFLD_HLRR")]
        public string RFLD_HLRR { get; set; }

        [DataMember(Name = "RFLD_RISKR")]
        public string RFLD_RISKR { get; set; }

        [DataMember(Name = "RFLD_RISKS")]
        public string RFLD_RISKS { get; set; }

        [DataMember(Name = "RFLD_RISKV")]
        public string RFLD_RISKV { get; set; }

        [DataMember(Name = "RISK_RATNG")]
        public string RISK_RATNG { get; set; }

        [DataMember(Name = "RISK_SCORE")]
        public string RISK_SCORE { get; set; }

        [DataMember(Name = "RISK_SPCTL")]
        public string RISK_SPCTL { get; set; }

        [DataMember(Name = "RISK_VALUE")]
        public string RISK_VALUE { get; set; }

        [DataMember(Name = "SOVI_RATNG")]
        public string SOVI_RATNG { get; set; }

        [DataMember(Name = "SOVI_SCORE")]
        public string SOVI_SCORE { get; set; }

        [DataMember(Name = "SOVI_SPCTL")]
        public string SOVI_SPCTL { get; set; }

        [DataMember(Name = "STATE")]
        public string STATE { get; set; }

        [DataMember(Name = "STATEABBRV")]
        public string STATEABBRV { get; set; }

        [DataMember(Name = "STATEFIPS")]
        public string STATEFIPS { get; set; }

        [DataMember(Name = "STCOFIPS")]
        public string STCOFIPS { get; set; }

        [DataMember(Name = "SWND_AFREQ")]
        public string SWND_AFREQ { get; set; }

        [DataMember(Name = "SWND_ALRA")]
        public string SWND_ALRA { get; set; }

        [DataMember(Name = "SWND_ALRB")]
        public string SWND_ALRB { get; set; }

        [DataMember(Name = "SWND_ALRP")]
        public string SWND_ALRP { get; set; }

        [DataMember(Name = "SWND_ALR_NPCTL")]
        public string SWND_ALR_NPCTL { get; set; }

        [DataMember(Name = "SWND_EALA")]
        public string SWND_EALA { get; set; }

        [DataMember(Name = "SWND_EALB")]
        public string SWND_EALB { get; set; }

        [DataMember(Name = "SWND_EALP")]
        public string SWND_EALP { get; set; }

        [DataMember(Name = "SWND_EALPE")]
        public string SWND_EALPE { get; set; }

        [DataMember(Name = "SWND_EALR")]
        public string SWND_EALR { get; set; }

        [DataMember(Name = "SWND_EALS")]
        public string SWND_EALS { get; set; }

        [DataMember(Name = "SWND_EALT")]
        public string SWND_EALT { get; set; }

        [DataMember(Name = "SWND_EVNTS")]
        public string SWND_EVNTS { get; set; }

        [DataMember(Name = "SWND_EXPA")]
        public string SWND_EXPA { get; set; }

        [DataMember(Name = "SWND_EXPB")]
        public string SWND_EXPB { get; set; }

        [DataMember(Name = "SWND_EXPP")]
        public string SWND_EXPP { get; set; }

        [DataMember(Name = "SWND_EXPPE")]
        public string SWND_EXPPE { get; set; }

        [DataMember(Name = "SWND_EXPT")]
        public string SWND_EXPT { get; set; }

        [DataMember(Name = "SWND_EXP_AREA")]
        public string SWND_EXP_AREA { get; set; }

        [DataMember(Name = "SWND_HLRA")]
        public string SWND_HLRA { get; set; }

        [DataMember(Name = "SWND_HLRB")]
        public string SWND_HLRB { get; set; }

        [DataMember(Name = "SWND_HLRP")]
        public string SWND_HLRP { get; set; }

        [DataMember(Name = "SWND_HLRR")]
        public string SWND_HLRR { get; set; }

        [DataMember(Name = "SWND_RISKR")]
        public string SWND_RISKR { get; set; }

        [DataMember(Name = "SWND_RISKS")]
        public string SWND_RISKS { get; set; }

        [DataMember(Name = "SWND_RISKV")]
        public string SWND_RISKV { get; set; }

        [DataMember(Name = "TRACT")]
        public string TRACT { get; set; }

        [DataMember(Name = "TRACTFIPS")]
        public string TRACTFIPS { get; set; }

        [DataMember(Name = "TRND_AFREQ")]
        public string TRND_AFREQ { get; set; }

        [DataMember(Name = "TRND_ALRA")]
        public string TRND_ALRA { get; set; }

        [DataMember(Name = "TRND_ALRB")]
        public string TRND_ALRB { get; set; }

        [DataMember(Name = "TRND_ALRP")]
        public string TRND_ALRP { get; set; }

        [DataMember(Name = "TRND_ALR_NPCTL")]
        public string TRND_ALR_NPCTL { get; set; }

        [DataMember(Name = "TRND_EALA")]
        public string TRND_EALA { get; set; }

        [DataMember(Name = "TRND_EALB")]
        public string TRND_EALB { get; set; }

        [DataMember(Name = "TRND_EALP")]
        public string TRND_EALP { get; set; }

        [DataMember(Name = "TRND_EALPE")]
        public string TRND_EALPE { get; set; }

        [DataMember(Name = "TRND_EALR")]
        public string TRND_EALR { get; set; }

        [DataMember(Name = "TRND_EALS")]
        public string TRND_EALS { get; set; }

        [DataMember(Name = "TRND_EALT")]
        public string TRND_EALT { get; set; }

        [DataMember(Name = "TRND_EVNTS")]
        public string TRND_EVNTS { get; set; }

        [DataMember(Name = "TRND_EXPA")]
        public string TRND_EXPA { get; set; }

        [DataMember(Name = "TRND_EXPB")]
        public string TRND_EXPB { get; set; }

        [DataMember(Name = "TRND_EXPP")]
        public string TRND_EXPP { get; set; }

        [DataMember(Name = "TRND_EXPPE")]
        public string TRND_EXPPE { get; set; }

        [DataMember(Name = "TRND_EXPT")]
        public string TRND_EXPT { get; set; }

        [DataMember(Name = "TRND_EXP_AREA")]
        public string TRND_EXP_AREA { get; set; }

        [DataMember(Name = "TRND_HLRA")]
        public string TRND_HLRA { get; set; }

        [DataMember(Name = "TRND_HLRB")]
        public string TRND_HLRB { get; set; }

        [DataMember(Name = "TRND_HLRP")]
        public string TRND_HLRP { get; set; }

        [DataMember(Name = "TRND_HLRR")]
        public string TRND_HLRR { get; set; }

        [DataMember(Name = "TRND_RISKR")]
        public string TRND_RISKR { get; set; }

        [DataMember(Name = "TRND_RISKS")]
        public string TRND_RISKS { get; set; }

        [DataMember(Name = "TRND_RISKV")]
        public string TRND_RISKV { get; set; }

        [DataMember(Name = "TSUN_AFREQ")]
        public string TSUN_AFREQ { get; set; }

        [DataMember(Name = "TSUN_ALRB")]
        public string TSUN_ALRB { get; set; }

        [DataMember(Name = "TSUN_ALRP")]
        public string TSUN_ALRP { get; set; }

        [DataMember(Name = "TSUN_ALR_NPCTL")]
        public string TSUN_ALR_NPCTL { get; set; }

        [DataMember(Name = "TSUN_EALB")]
        public string TSUN_EALB { get; set; }

        [DataMember(Name = "TSUN_EALP")]
        public string TSUN_EALP { get; set; }

        [DataMember(Name = "TSUN_EALPE")]
        public string TSUN_EALPE { get; set; }

        [DataMember(Name = "TSUN_EALR")]
        public string TSUN_EALR { get; set; }

        [DataMember(Name = "TSUN_EALS")]
        public string TSUN_EALS { get; set; }

        [DataMember(Name = "TSUN_EALT")]
        public string TSUN_EALT { get; set; }

        [DataMember(Name = "TSUN_EVNTS")]
        public string TSUN_EVNTS { get; set; }

        [DataMember(Name = "TSUN_EXPB")]
        public string TSUN_EXPB { get; set; }

        [DataMember(Name = "TSUN_EXPP")]
        public string TSUN_EXPP { get; set; }

        [DataMember(Name = "TSUN_EXPPE")]
        public string TSUN_EXPPE { get; set; }

        [DataMember(Name = "TSUN_EXPT")]
        public string TSUN_EXPT { get; set; }

        [DataMember(Name = "TSUN_EXP_AREA")]
        public string TSUN_EXP_AREA { get; set; }

        [DataMember(Name = "TSUN_HLRB")]
        public string TSUN_HLRB { get; set; }

        [DataMember(Name = "TSUN_HLRP")]
        public string TSUN_HLRP { get; set; }

        [DataMember(Name = "TSUN_HLRR")]
        public string TSUN_HLRR { get; set; }

        [DataMember(Name = "TSUN_RISKR")]
        public string TSUN_RISKR { get; set; }

        [DataMember(Name = "TSUN_RISKS")]
        public string TSUN_RISKS { get; set; }

        [DataMember(Name = "TSUN_RISKV")]
        public string TSUN_RISKV { get; set; }

        [DataMember(Name = "VLCN_AFREQ")]
        public string VLCN_AFREQ { get; set; }

        [DataMember(Name = "VLCN_ALRB")]
        public string VLCN_ALRB { get; set; }

        [DataMember(Name = "VLCN_ALRP")]
        public string VLCN_ALRP { get; set; }

        [DataMember(Name = "VLCN_ALR_NPCTL")]
        public string VLCN_ALR_NPCTL { get; set; }

        [DataMember(Name = "VLCN_EALB")]
        public string VLCN_EALB { get; set; }

        [DataMember(Name = "VLCN_EALP")]
        public string VLCN_EALP { get; set; }

        [DataMember(Name = "VLCN_EALPE")]
        public string VLCN_EALPE { get; set; }

        [DataMember(Name = "VLCN_EALR")]
        public string VLCN_EALR { get; set; }

        [DataMember(Name = "VLCN_EALS")]
        public string VLCN_EALS { get; set; }

        [DataMember(Name = "VLCN_EALT")]
        public string VLCN_EALT { get; set; }

        [DataMember(Name = "VLCN_EVNTS")]
        public string VLCN_EVNTS { get; set; }

        [DataMember(Name = "VLCN_EXPB")]
        public string VLCN_EXPB { get; set; }

        [DataMember(Name = "VLCN_EXPP")]
        public string VLCN_EXPP { get; set; }

        [DataMember(Name = "VLCN_EXPPE")]
        public string VLCN_EXPPE { get; set; }

        [DataMember(Name = "VLCN_EXPT")]
        public string VLCN_EXPT { get; set; }

        [DataMember(Name = "VLCN_EXP_AREA")]
        public string VLCN_EXP_AREA { get; set; }

        [DataMember(Name = "VLCN_HLRB")]
        public string VLCN_HLRB { get; set; }

        [DataMember(Name = "VLCN_HLRP")]
        public string VLCN_HLRP { get; set; }

        [DataMember(Name = "VLCN_HLRR")]
        public string VLCN_HLRR { get; set; }

        [DataMember(Name = "VLCN_RISKR")]
        public string VLCN_RISKR { get; set; }

        [DataMember(Name = "VLCN_RISKS")]
        public string VLCN_RISKS { get; set; }

        [DataMember(Name = "VLCN_RISKV")]
        public string VLCN_RISKV { get; set; }

        [DataMember(Name = "WFIR_AFREQ")]
        public string WFIR_AFREQ { get; set; }

        [DataMember(Name = "WFIR_ALRA")]
        public string WFIR_ALRA { get; set; }

        [DataMember(Name = "WFIR_ALRB")]
        public string WFIR_ALRB { get; set; }

        [DataMember(Name = "WFIR_ALRP")]
        public string WFIR_ALRP { get; set; }

        [DataMember(Name = "WFIR_ALR_NPCTL")]
        public string WFIR_ALR_NPCTL { get; set; }

        [DataMember(Name = "WFIR_EALA")]
        public string WFIR_EALA { get; set; }

        [DataMember(Name = "WFIR_EALB")]
        public string WFIR_EALB { get; set; }

        [DataMember(Name = "WFIR_EALP")]
        public string WFIR_EALP { get; set; }

        [DataMember(Name = "WFIR_EALPE")]
        public string WFIR_EALPE { get; set; }

        [DataMember(Name = "WFIR_EALR")]
        public string WFIR_EALR { get; set; }

        [DataMember(Name = "WFIR_EALS")]
        public string WFIR_EALS { get; set; }

        [DataMember(Name = "WFIR_EALT")]
        public string WFIR_EALT { get; set; }

        [DataMember(Name = "WFIR_EVNTS")]
        public string WFIR_EVNTS { get; set; }

        [DataMember(Name = "WFIR_EXPA")]
        public string WFIR_EXPA { get; set; }

        [DataMember(Name = "WFIR_EXPB")]
        public string WFIR_EXPB { get; set; }

        [DataMember(Name = "WFIR_EXPP")]
        public string WFIR_EXPP { get; set; }

        [DataMember(Name = "WFIR_EXPPE")]
        public string WFIR_EXPPE { get; set; }

        [DataMember(Name = "WFIR_EXPT")]
        public string WFIR_EXPT { get; set; }

        [DataMember(Name = "WFIR_EXP_AREA")]
        public string WFIR_EXP_AREA { get; set; }

        [DataMember(Name = "WFIR_HLRA")]
        public string WFIR_HLRA { get; set; }

        [DataMember(Name = "WFIR_HLRB")]
        public string WFIR_HLRB { get; set; }

        [DataMember(Name = "WFIR_HLRP")]
        public string WFIR_HLRP { get; set; }

        [DataMember(Name = "WFIR_HLRR")]
        public string WFIR_HLRR { get; set; }

        [DataMember(Name = "WFIR_RISKR")]
        public string WFIR_RISKR { get; set; }

        [DataMember(Name = "WFIR_RISKS")]
        public string WFIR_RISKS { get; set; }

        [DataMember(Name = "WFIR_RISKV")]
        public string WFIR_RISKV { get; set; }

        [DataMember(Name = "WNTW_AFREQ")]
        public string WNTW_AFREQ { get; set; }

        [DataMember(Name = "WNTW_ALRA")]
        public string WNTW_ALRA { get; set; }

        [DataMember(Name = "WNTW_ALRB")]
        public string WNTW_ALRB { get; set; }

        [DataMember(Name = "WNTW_ALRP")]
        public string WNTW_ALRP { get; set; }

        [DataMember(Name = "WNTW_ALR_NPCTL")]
        public string WNTW_ALR_NPCTL { get; set; }

        [DataMember(Name = "WNTW_EALA")]
        public string WNTW_EALA { get; set; }

        [DataMember(Name = "WNTW_EALB")]
        public string WNTW_EALB { get; set; }

        [DataMember(Name = "WNTW_EALP")]
        public string WNTW_EALP { get; set; }

        [DataMember(Name = "WNTW_EALPE")]
        public string WNTW_EALPE { get; set; }

        [DataMember(Name = "WNTW_EALR")]
        public string WNTW_EALR { get; set; }

        [DataMember(Name = "WNTW_EALS")]
        public string WNTW_EALS { get; set; }

        [DataMember(Name = "WNTW_EALT")]
        public string WNTW_EALT { get; set; }

        [DataMember(Name = "WNTW_EVNTS")]
        public string WNTW_EVNTS { get; set; }

        [DataMember(Name = "WNTW_EXPA")]
        public string WNTW_EXPA { get; set; }

        [DataMember(Name = "WNTW_EXPB")]
        public string WNTW_EXPB { get; set; }

        [DataMember(Name = "WNTW_EXPP")]
        public string WNTW_EXPP { get; set; }

        [DataMember(Name = "WNTW_EXPPE")]
        public string WNTW_EXPPE { get; set; }

        [DataMember(Name = "WNTW_EXPT")]
        public string WNTW_EXPT { get; set; }

        [DataMember(Name = "WNTW_EXP_AREA")]
        public string WNTW_EXP_AREA { get; set; }

        [DataMember(Name = "WNTW_HLRA")]
        public string WNTW_HLRA { get; set; }

        [DataMember(Name = "WNTW_HLRB")]
        public string WNTW_HLRB { get; set; }

        [DataMember(Name = "WNTW_HLRP")]
        public string WNTW_HLRP { get; set; }

        [DataMember(Name = "WNTW_HLRR")]
        public string WNTW_HLRR { get; set; }

        [DataMember(Name = "WNTW_RISKR")]
        public string WNTW_RISKR { get; set; }

        [DataMember(Name = "WNTW_RISKS")]
        public string WNTW_RISKS { get; set; }

        [DataMember(Name = "WNTW_RISKV")]
        public string WNTW_RISKV { get; set; }
    }
}