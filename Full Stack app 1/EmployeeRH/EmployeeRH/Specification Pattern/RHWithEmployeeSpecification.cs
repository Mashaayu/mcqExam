using EmployeeRH.Models;

namespace EmployeeRH.Specification_Pattern
{
    public class RHWithEmployeeSpecification:BaseSpecification<RH>
    {
        public RHWithEmployeeSpecification()
        {
            AddIncludes(rh => rh.Employees);
        }
        public RHWithEmployeeSpecification(int id):base(r=>r.Id == id)
        {
            AddIncludes(rh=>rh.Employees);
        }
    }
}
