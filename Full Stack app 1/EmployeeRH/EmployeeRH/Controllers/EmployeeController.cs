using EmployeeRH.Context;
using EmployeeRH.Models;
using EmployeeRH.Models.DTOs;
using EmployeeRH.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;
using System.Linq.Expressions;
using EmployeeRH.SeedData;
using Microsoft.AspNetCore.Authorization;
using EmployeeRH.Specification_Pattern;

namespace EmployeeRH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController:ControllerBase
    {
        private readonly EmployeeRHDbContext dbContext;
        private readonly IGenericRepo<Employee> genericRepo;
        private readonly IMapper mapper;

        public EmployeeController(EmployeeRHDbContext dbContext,
            IGenericRepo<Employee> genericRepo,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.genericRepo = genericRepo;
            this.mapper = mapper;
        }

        [HttpGet("Get")]
        [Authorize(Roles = "admin,employee,rh")]
        public async Task<ActionResult<List<EmployeeDTO>>> GetEmployees() //not used generic repo
        {
            var specification = new EmployeeWithRHSpecification();

            List<Employee> emps = await genericRepo.ListAsync(specification);

            if(emps == null)
            {
                return NotFound();
            }
            return mapper.Map<List<Employee>,List<EmployeeDTO>>(emps);
            
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,employee,rh")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeebyId(int id) //not used
        {
            var specification = new EmployeeWithRHSpecification(id);
            var emp = await genericRepo.GetEntityWithSpec(specification);

            if(emp == null)
            {
                return NotFound();
            }
            return mapper.Map<Employee,EmployeeDTO>(emp);
        }

        [HttpPost("Post")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeePostDTO employeepostDTO)
        {
            RH rh = await dbContext.RH.Where(r => r.Id == employeepostDTO.RHId).FirstOrDefaultAsync();

            if (rh != null)
            {
                Employee emp = new Employee()
                {
                    /*Id = employeepostDTO.Id,*/
                    name = employeepostDTO.Name,
                    RHId = rh.Id,
                   /* RH = new RH() { Id = rh.Id, name = rh.name }*/
                };

                dbContext.Add(emp);
                await dbContext.SaveChangesAsync();
        /*        rh.Employees.Add(emp);
                await dbContext.SaveChangesAsync();*/

                return Ok(emp);
                
            }
            return NotFound("RH not found !");

        }
       
        [HttpDelete("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<EmployeeDTO>>> DeleteEmployee(int id)
        {
            Employee emp = await dbContext.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }

            List<Employee> emps = await genericRepo.DeleteById(id);
            
            return await GetEmployees();
        }

        [HttpPut("put")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<EmployeeDTO>> PutEmployee(int id,EmployeePostDTO employeepostDTO)
        {
            Employee emp = await dbContext.Employees.FindAsync(employeepostDTO.Id);
            if(emp == null)
            {
                return NotFound("Employee Not Found");
            }

            RH rh = await dbContext.RH.FindAsync(employeepostDTO.RHId);
            if (rh != null)
            {
                return NotFound("RH is Not Found");
            }

            emp.RH = rh;
            emp.RHId = employeepostDTO.RHId;
            emp.name = employeepostDTO.Name;

            await dbContext.SaveChangesAsync();

            return mapper.Map<Employee,EmployeeDTO>(emp);
        }

    }
}
