using E_Commerce.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace E_Commerce.Data.IdentityDbContext
{
    public class AppIdentityDbcontext : IdentityDbContext<AppUser>
    {
        private readonly IConfiguration configuration;
        public AppIdentityDbcontext(DbContextOptions<AppIdentityDbcontext> options,IConfiguration config) : base(options)
        {
            configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDbcon"));
        }
    }
}
