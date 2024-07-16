using EmployeeRH.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRH.Context
{
    public class EmployeeRHDbContext:DbContext
    {
        private readonly IConfiguration configuration;

        public EmployeeRHDbContext() :base()
        {
            
        }
        public EmployeeRHDbContext(DbContextOptions<EmployeeRHDbContext> options,IConfiguration configuration)
            :base(options) 
        {
            this.configuration = configuration;
        }
        
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<RH>? RH { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDbcon"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
