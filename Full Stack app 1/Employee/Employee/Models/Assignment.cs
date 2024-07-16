using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public partial class Assignment :BaseEntity
    {
        public Assignment()
        {
            AssignmentExtraInformations = new HashSet<AssignmentExtraInformation>();
        }

        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime AssignmentProjectedEndDate { get; set; }
        public DateTime ActualTerminationDate { get; set; }
        public int ManagerAssignmentId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<AssignmentExtraInformation> AssignmentExtraInformations { get; set; }
    }
}
