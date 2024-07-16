using AutoMapper;
using EmployeeRH.Context;
using EmployeeRH.Models;
using EmployeeRH.Models.DTOs;
using EmployeeRH.Repository.IRepository;
using EmployeeRH.Specification_Pattern;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RHController: ControllerBase

    {
        private readonly EmployeeRHDbContext dbContext;
        private readonly IGenericRepo<RH> genericRepo;
        private readonly IMapper mapper;

        public RHController(EmployeeRHDbContext dbContext,
            IGenericRepo<RH> genericRepo,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.genericRepo = genericRepo;
            this.mapper = mapper;
        }

        [HttpGet("getRh")]
        [Authorize(Roles ="admin,employee,rh")]
        public async Task<ActionResult<List<RhDisplayDTO>>> GetRHs()
        {
            var specification = new RHWithEmployeeSpecification();
            List<RH> RHs = await genericRepo.ListAsync(specification);

            if(RHs == null)
            {
                return NotFound();
            }

            return  RHs.Select(r => new RhDisplayDTO()
            {
                Id = r.Id,
                Name = r.name,
                Employees = r.Employees
                                   .Select(e => new EmployeeOnlyDTO()
                                   {
                                       Id = e.Id,
                                       Name = e.name
                                   }).ToList(),
            }).ToList();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,rh")]
        public async Task<ActionResult<RhDisplayDTO>> GetRhById(int id)
        {
            var specification = new RHWithEmployeeSpecification(id);
            RH rh = await genericRepo.GetEntityWithSpec(specification);

            return new RhDisplayDTO() {

                Id = rh.Id,
                Name = rh.name,
                Employees = rh.Employees
                                   .Select(e => new EmployeeOnlyDTO()
                                   {
                                       Id = e.Id,
                                       Name = e.name
                                   }).ToList(),

            };

        }

        [HttpPost("Post RH")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<RH>> PostRh(RHDTO RhDTO)
        {
            if(RhDTO.Name == null)
            {
                return BadRequest("Please provide name");
            }
            RH rh = new RH() { 
                name = RhDTO.Name,
            };

             dbContext.Add(rh);
            await dbContext.SaveChangesAsync();

            return Ok(rh);
        }

        [HttpPut("Put")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<RH>> PutRH(int id,RHDTO RhDTO)
        {
            RH rh = await dbContext.RH.FindAsync(id);
            if(rh == null)
            {
                return NotFound();
            }
            rh.name = RhDTO.Name;
            await dbContext.SaveChangesAsync();

            return Ok(rh);
        }

        [HttpDelete("Delete RH")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<RH>>> DeleteRH(int id)
        {
            RH rh = await dbContext.RH.FindAsync(id);
            if(rh == null)
            {
                return NotFound();
            }
            return await genericRepo.DeleteById(id);
        }
    }
}
