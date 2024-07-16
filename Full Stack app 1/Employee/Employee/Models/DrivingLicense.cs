using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public partial class DrivingLicense : BaseEntity
    {
       
        public DateTime DriversLicenseExpirationDate { get; set; }
        public string? DriversLicenseIssuingCountry { get; set; }
        public string? EffectiveStartDate { get; set; }
        public string? LicenseNumber { get; set; }
        public string? EffectiveEndDate { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
