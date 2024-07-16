using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public partial class AssignmentExtraInformation : BaseEntity
    {

        public string? AssignmentCategory { get; set; }
        public string? AssignmentStatus { get; set; }
        public int AssignmentStatusTypeId { get; set; }
        public string? AssignmentDff { get; set; }
        public int GradeId { get; set; }
        public int GradeLadderId { get; set; }
        public int AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; } = null!;
    }
}
