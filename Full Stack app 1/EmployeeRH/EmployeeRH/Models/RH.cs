namespace EmployeeRH.Models
{
    public class RH:BaseEntity
    {
        public string name { get; set; }
        = null!;
        public ICollection<Employee> Employees { get; set; }

        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
