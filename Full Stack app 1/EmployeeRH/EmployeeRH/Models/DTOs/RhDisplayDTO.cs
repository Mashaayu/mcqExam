namespace EmployeeRH.Models.DTOs
{
    public class RhDisplayDTO:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<EmployeeOnlyDTO> Employees { get; set;}
    }
}
