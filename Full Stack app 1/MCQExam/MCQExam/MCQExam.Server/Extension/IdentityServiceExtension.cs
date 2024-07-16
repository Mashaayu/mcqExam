using MCQExam.Server.Context;
using MCQExam.Server.Identity;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.SymbolStore;

namespace MCQExam.Server.Extension
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services 
            ,IConfiguration configuration)
        {
            var builder = services.AddIdentityCore<AppUser>()
                            .AddRoles<AppRole>()
                            .AddRoleManager<RoleManager<AppRole>>();

            builder = new IdentityBuilder(builder.UserType,builder.RoleType,builder.Services);
           
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            
            builder.AddUserManager<UserManager<AppUser>>();
            builder.AddRoleManager<RoleManager<AppRole>>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options =>
                {
                     options.TokenValidationParameters = new TokenValidationParameters()
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                         ValidIssuer = configuration["Token:Issuer"],
                         ValidateIssuer = true,
                         ValidateAudience = false
                     };

                });
            services.AddLogging();
            return services;
            
        }
    }
}
