﻿using ExamPrep.sever.Context;
using ExamPrep.sever.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;
using System.Text;

namespace ExamPrep.sever.Exetention
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIndetityService(this IServiceCollection services,IConfiguration configuration)

        {
            var builder = services.AddIdentityCore<AppUser>()
                            .AddRoles<AppRole>()
                            .AddRoleManager<RoleManager<AppRole>>();
            builder = new IdentityBuilder(builder.UserType, builder.RoleType, builder.Services);
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
                            ValidateAudience = false,

                        };
                    }
                );

            services.AddLogging();

            return services;
        }
    }
}
