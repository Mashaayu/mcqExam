using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public partial class BasicDetail : BaseEntity
    {
    
        public string? NameSuffix { get; set; }
        public DateTime HireDate { get; set; }
        public string? Honors { get; set; }
        public int LegalEntityId { get; set; }
        public string? MaritalStatus { get; set; }
        public int NationalId { get; set; }
        public string? NationalIdCountry { get; set; }
        public string? ActionCode { get; set; }
        public string? ActionReasonCode { get; set; }
        public string? DefaultExpenseAccount { get; set; }
        public int BusinessUnitId { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
