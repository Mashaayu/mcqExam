using EmployeeRH.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace EmployeeRH.Context
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        private readonly IConfiguration configuration;

        public AppIdentityDbContext()
        {
            
        }
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> dbContextOptions, IConfiguration config)
            : base(dbContextOptions)
        {
            configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDbcon"));
        }

    }

}

