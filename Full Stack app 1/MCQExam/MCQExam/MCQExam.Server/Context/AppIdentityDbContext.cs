
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MCQExam.Server.Identity;

namespace MCQExam.Server.Context
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        private readonly IConfiguration configuration;

        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> Options,IConfiguration configuration)
        :base(Options)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDbConnection"));
        }
    }
}
