using Spiritual.server.Context;
using Spiritual.Server.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;


namespace Spiritual.Server.Extension
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services,IConfiguration configuration) {
            var builder = services.AddIdentityCore<AppUser>()
                            .AddRoles<AppRole>()
                                    .AddRoleManager<RoleManager<AppRole>>();
            builder = new IdentityBuilder(builder.UserType, builder.RoleType, builder.Services);

            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddUserManager<UserManager<AppUser>>();
            builder.AddRoleManager<RoleManager<AppRole>>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                    ValidIssuer = configuration["Token:Issuer"]
                    ,ValidateIssuer = true,
                    ValidateAudience = false,
                    
                }
                );
            services.AddLogging();
            return services;

        }
    }
}
