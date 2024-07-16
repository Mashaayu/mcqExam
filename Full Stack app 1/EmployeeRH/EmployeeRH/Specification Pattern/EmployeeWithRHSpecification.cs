using EmployeeRH.Models;

namespace EmployeeRH.Specification_Pattern
{
    public class EmployeeWithRHSpecification :BaseSpecification<Employee>
    {
        public EmployeeWithRHSpecification()
        {
            AddIncludes(e => e.RH);
        }
        public EmployeeWithRHSpecification(int id) 
            : base(x=>x.Id == id)
        {
            AddIncludes(e=>e.RH);
        }
    }
}
