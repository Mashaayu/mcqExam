using ExamPrep.sever.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamPrep.sever.Context
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        private readonly IConfiguration configuration;

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> Options,IConfiguration configuration)
            :base(Options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDatabaseConnection"));
        }
    }
}
 