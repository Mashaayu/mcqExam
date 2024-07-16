using Microsoft.AspNetCore.Identity;

namespace EmployeeRH.Identity
{
    public class AppUser:IdentityUser<int>
    {
        public string Name { get; set; }
    }
}
