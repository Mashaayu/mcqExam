using EmployeeRH.Context;
using EmployeeRH.Identity;
using EmployeeRH.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Collections.Generic;
namespace EmployeeRH.SeedData
{
    public  class DBContextSeed
    {
        private static readonly EmployeeRHDbContext dbcontext;
        private static readonly AppIdentityDbContext IdentityContext;
        private static readonly UserManager<AppUser> userManager;
        static DBContextSeed()
        {
            dbcontext = new EmployeeRHDbContext ();
            IdentityContext = new AppIdentityDbContext();

            UserManager<AppUser> _userManager;

            userManager = _userManager;
        }
        public static async void AddSeedData()
        {

            try
            {
                

                RH rh1 = new RH()
                {
                    name = "Sweta",

                };

                RH rh2 = new RH()
                {

                    name = "Maya",
                };
                RH rh3 = new RH()
                {

                    name = "Vinod",
                };
                RH rh4 = new RH()
                {

                    name = "Jay",
                };


                Employee employee1 = new Employee()
                {

                    name = "Payal",
                    RHId = rh2.Id,
                    RH = rh2
                };

                Employee employee2 = new Employee()
                {

                    name = "Mamta",
                    RHId = rh3.Id,
                    RH = rh3
                };
                Employee employee3 = new Employee()
                {

                    name = "Uday",
                    RHId = rh4.Id,
                    RH = rh4
                };
                Employee employee4 = new Employee()
                {

                    name = "Ram",
                    RHId = rh2.Id,
                    RH = rh2
                };
                Employee employee5 = new Employee()
                {

                    name = "Hari",
                    RHId = rh3.Id,
                    RH = rh3
                };
                Employee employee6 = new Employee()
                {

                    name = "Shyam",
                    RHId = rh1.Id,
                    RH = rh1
                };
                Employee employee7 = new Employee()
                {

                    name = "Krishna",
                    RHId = rh2.Id,
                    RH = rh2
                };

                await dbcontext.AddRangeAsync(rh1, rh2, rh3, rh4);
                await dbcontext.AddRangeAsync(employee1, employee2, employee3, employee4, employee5, employee6, employee7);

                await dbcontext.SaveChangesAsync();

                List<Employee> emps = dbcontext.Employees.ToList();
                foreach (Employee emp in emps)
                {
                    AddtoRH(emp);
                }
                dbcontext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                
        }
         
        public static async Task AddtoRH(Employee emp)
        {
            
            RH rh = dbcontext.RH.Where(rh=>rh.Id == emp.RHId).SingleOrDefault();
            int x = 0;
            if (rh != null)
            {
                rh.Employees.Add(emp);
            }
            else
            {
                Console.WriteLine("null rh");
            }
            
        }
        
    }
}

