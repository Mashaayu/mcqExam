using ExamPrep.sever.Context;
using ExamPrep.sever.Identity;
using Microsoft.AspNetCore.Identity;

namespace ExamPrep.sever.SeedData
{
    public class AppIdentityDbContextSeed
    {

        public static async Task SeedUserAsync(AppIdentityDbContext dbContext,UserManager<AppUser> userManger,RoleManager<AppRole> roleManger)
        {
           

            if (    !roleManger.Roles.Any()) {

                AppRole Role = new AppRole()
                {
                    Name = "Admin"
                };
                AppRole Role1 = new AppRole()
                {
                    Name = "User"
                };

                await roleManger.CreateAsync(Role);

                await roleManger.CreateAsync(Role1);

            }

            if (!userManger.Users.Any())
            {
                AppUser User = new AppUser()
                {
                    UserName = "Ayushi",
                    Password = "123Ca$",
                    Email = "ayushi@gmail.com"
                };
                await userManger.CreateAsync(User, User.Password);
                await userManger.AddToRoleAsync(User, "Admin");
            }

        }   
    }
}
