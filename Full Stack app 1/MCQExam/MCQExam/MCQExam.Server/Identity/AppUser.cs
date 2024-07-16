using Microsoft.AspNetCore.Identity;

namespace MCQExam.Server.Identity
{
    public class AppUser:IdentityUser<int>
    {
        public string Password { get; set; }
        public string Role {  get; set; }
        public int PassKey { get; set; }
        public string? Course { get; set; }
        public string? Level { get; set; }

    }
}
