using EmployeeRH.Identity;
using Microsoft.AspNetCore.Identity;

namespace EmployeeRH.SeedData
{
    public class AppIdentitySeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                AppUser user = new AppUser()
                {
                    UserName = "Ayushi11",
                    Email = "ayushi@gmail.com",
                    Name = "Ayushi",
                };

                await userManager.CreateAsync(user, "b4CA440k$");
                await userManager.AddToRoleAsync(user, "admin");
            }

            List<string> Roles = new List<string>() { "admin", "employee","rh" };

            if (!roleManager.Roles.Any())
            {
                foreach (string role in Roles)
                {
                    AppRole newRole = new AppRole()
                    {
                        Name = role,
                    };
                    await roleManager.CreateAsync(newRole);

                }
            }
        }
    }
}
