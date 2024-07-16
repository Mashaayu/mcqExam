using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public partial class Employee : BaseEntity
    {
        public Employee()
        {
            Addresses = new HashSet<Address>();
            Assignments = new HashSet<Assignment>();
            BasicDetails = new HashSet<BasicDetail>();
            DirectiveReports = new HashSet<DirectiveReport>();
            DrivingLicenses = new HashSet<DrivingLicense>();
            Links = new HashSet<Link>();
        }

      
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<BasicDetail> BasicDetails { get; set; }
        public virtual ICollection<DirectiveReport> DirectiveReports { get; set; }
        public virtual ICollection<DrivingLicense> DrivingLicenses { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}
