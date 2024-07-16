using Microsoft.AspNetCore.Identity;

namespace EmployeeRH.Identity
{
    public class AppRole:IdentityRole<int>
    {
        public int CreatedById { get; set; }
    
    }
}
