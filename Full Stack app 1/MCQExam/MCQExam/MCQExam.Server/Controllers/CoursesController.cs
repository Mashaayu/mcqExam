using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCQExam.Server.Context;
using MCQExam.Server.Models;
using MCQExam.Server.Repository;
using Microsoft.Extensions.Configuration.UserSecrets;
using MCQExam.Server.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace MCQExam.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly MCQExamDbContext _context;
        private readonly IGenericRepo<Course> genericRepo;
        private readonly IMapper mapper;
        private readonly int userID;
        public CoursesController(MCQExamDbContext context,IGenericRepo<Course> genericRepo,
            IMapper _mapper)
        {
            _context = context;
            this.genericRepo = genericRepo;
            mapper = _mapper;
            userID = AccountController.UserID;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<List<CourseDTO>>> GetCourses()
        {
            List<Course> Courses = await genericRepo.GetAllAsync();
            if(Courses == null)
            {
                return NotFound();
            }
            return mapper.Map<List<Course>,List<CourseDTO>>(Courses);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourse(int id)
        {
            Course course = await genericRepo.GetByID(id);

            if (course == null)
            {
                return NotFound();
            }
            return mapper.Map<Course,CourseDTO>(course);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseDTO CourseDTO)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(x=>x.Id == id);
            if(course == null)
            {
                return NotFound();
            }

            course.Name = CourseDTO.Name;
            course.ModifiedById = userID;
            course.ModifiedDate = DateTime.Now;

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseDTO courseDTO)
        {
          if (_context.Courses == null)
          {
              return Problem("Entity set 'MCQExamDbContext.Courses'  is null.");
          }
            Course course = new Course() { 
               
                Name = courseDTO.Name,
                CreatedById = userID,
                CreatedDate = DateTime.Now,
                ModifiedById = userID,
                ModifiedDate = DateTime.Now,

            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CourseDTO>>> DeleteCourse(int id)
        {
            List<Course> Courses = await genericRepo.DeleteByID(id);
            if (Courses == null)
            {
                return NotFound();
            }
            return mapper.Map<List<Course>,List<CourseDTO>>(Courses);

        }

        private bool CourseExists(int id)
        {
            return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
