using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Models.Identity
{
    public class AppIdentityDbContectSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                AppUser User = new AppUser() { 
                    DisplayName = "Ayushi",
                    Email = "ayushi@gmail.com",
                    UserName = "ayushi11@",
                    Address = new Address{ 
                        FirstName = "Ayushi",
                        LastName = "Suthar",
                        Street = "Narmade 38",
                        City = "Mehsana",
                        State = "Gujarat",
                        ZipCode = "391760"
                    }

                };
               await userManager.CreateAsync(User,"b4CA440k$");
            }
        }
    }
}
