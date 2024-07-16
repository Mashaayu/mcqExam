using MCQExam.Server.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MCQExam.Server.Models.SeedData
{
    public class AppIdentityDbContextSeed
    {
         public static async Task SeedUser(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
         {
            try
            {
                if (!userManager.Users.Any())
                {
                    AppUser user = new AppUser()
                    {
                        UserName = "ayushi11",
                        Email = "ayushi@gmail.com",
                        Password = "b4CA440k?",
                        PassKey = 100,
                        Role = "admin"
                    };

                    await userManager.CreateAsync(user, user.Password);
                    await userManager.AddToRoleAsync(user, "admin");

                }


                List<string> roles = new List<string>() { "Admin", "Instructor", "Student" };

                if (!roleManager.Roles.Any())
                {
                    foreach (string role in roles)
                    {
                        AppRole Role = new AppRole()
                        {
                            Name = role.ToLower(),
                        };
                        await roleManager.CreateAsync(Role);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

         }
    }
}
