namespace EmployeeRH.Models.DTOs
{
    public class EmployeeDTO:BaseEntity
    {
        public string Name { get; set; }
        public RHDTO RH { get; set; }
    }
}
