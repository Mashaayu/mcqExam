using MCQExam.Server.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace MCQExam.Server.Context
{
    public class MCQExamDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public MCQExamDbContext(DbContextOptions<MCQExamDbContext> dbContextOptions, IConfiguration configuration)
            : base(dbContextOptions)
        {
            this.configuration = configuration;
        }

        public DbSet<Course> Courses  {get;set;} = null!;
        public DbSet<Exam>   Exams {get;set;} = null!;
        public DbSet<Instructor> Instructors {get;set;} = null!;
        public DbSet<Question> Questions {get;set;} = null!;
        public DbSet<Subject> Subjects {get;set;}=null!;
        public DbSet<Result> Results  {get;set;} = null!;
        public DbSet<Student> Students   {get;set;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDbCon"));
        }
    }
}
