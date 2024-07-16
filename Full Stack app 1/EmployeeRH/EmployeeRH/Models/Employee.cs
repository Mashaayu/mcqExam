namespace EmployeeRH.Models
{
    public class Employee:BaseEntity
    {
        public string name { get; set; } = null!;
        public int RHId { get; set; }
        public RH RH { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set;}
    }
}
