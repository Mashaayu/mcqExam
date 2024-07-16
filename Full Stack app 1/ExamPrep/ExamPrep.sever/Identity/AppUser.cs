using Microsoft.AspNetCore.Identity;

namespace ExamPrep.sever.Identity
{
    public class AppUser:IdentityUser<int>
    {
        public string Password { get; set; }

    }
}
