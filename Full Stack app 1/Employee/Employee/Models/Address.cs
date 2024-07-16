using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public partial class Address : BaseEntity
    {

        public int LocationId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? HomeFaxAreaCode { get; set; }
        public string? HomeFaxCountryCode { get; set; }
        public string? HomeFaxExtension { get; set; }
        public string? HomeFaxLegislationCode { get; set; }
        public string? HomeFaxNumber { get; set; }
        public string? HomePhoneAreaCode { get; set; }
        public string? HomePhoneCountryCode { get; set; }
        public string? HomePhoneExtension { get; set; }
        public string? HomePhoneLegislationCode { get; set; }
        public string? HomePhoneNumber { get; set; }
        public string? City { get; set; }
        public string? CitizenshipId { get; set; }
        public string? CitizenshipLegislationCode { get; set; }
        public string? CitizenshipStatus { get; set; }
        public string? CitizenshipToDate { get; set; }
        public string? Country { get; set; }
        public string? CorrespondenceLanguage { get; set; }
        public string? Ethnicity { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
