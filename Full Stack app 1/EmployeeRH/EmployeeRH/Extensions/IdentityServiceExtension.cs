using EmployeeRH.Context;
using EmployeeRH.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EmployeeRH.Extensions
{
    public static class IdentityServiceExtension
    {
        
        public static IServiceCollection AddIdentityService(this IServiceCollection services
            ,IConfiguration configuration)
        {
            var builder = services.AddIdentityCore<AppUser>()
                                    .AddRoles<AppRole>()
                                    .AddRoleManager<RoleManager<AppRole>>();
            builder = new IdentityBuilder(builder.UserType,builder.RoleType,builder.Services);

            builder.AddEntityFrameworkStores<AppIdentityDbContext>();

            builder.AddSignInManager<SignInManager<AppUser>>();
            builder.AddUserManager<UserManager<AppUser>>();
            builder.AddRoleManager<RoleManager<AppRole>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
            opts.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                ValidIssuer = configuration["Token:Issuer"],
                ValidateIssuer = true,
                ValidateAudience = true,
            });

            return services;
        }
    }
}
