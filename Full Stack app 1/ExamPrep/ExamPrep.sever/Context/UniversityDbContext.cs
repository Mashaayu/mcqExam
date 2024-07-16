using ExamPrep.sever.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamPrep.sever.Context
{
    public class UniversityDbContext:DbContext
    {
        private readonly IConfiguration configuration;

        public UniversityDbContext(DbContextOptions<UniversityDbContext> dbContextOps , IConfiguration  configuration)
            :base(dbContextOps)
        {
            this.configuration = configuration;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDatabaseConnection"));
        }
    }
}
