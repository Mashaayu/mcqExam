using System;
using System.Collections.Generic;

namespace Hospital.Models
{
    public partial class Link : BaseEntity
    {
   
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
