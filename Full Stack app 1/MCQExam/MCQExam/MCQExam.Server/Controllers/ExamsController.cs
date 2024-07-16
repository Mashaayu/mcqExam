using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCQExam.Server.Context;
using MCQExam.Server.Models;
using MCQExam.Server.Repository;
using System.Security.Cryptography.X509Certificates;
using MCQExam.Server.Models.DTOs;

namespace MCQExam.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly MCQExamDbContext _context;
        private readonly GenericRepo<Exam> genericRepo;
        private readonly int UserId; 

        public ExamsController(MCQExamDbContext context,GenericRepo<Exam> genericRepo) 
        {
            _context = context;
            this.genericRepo = genericRepo;
            UserId = AccountController.UserID;
        }

        // GET: api/Exams
        [HttpGet]
        public async Task<ActionResult<List<Exam>>> GetExams()
        {
            List<Exam> exams = await genericRepo.GetAllAsync();
            if (exams == null)
            {
                return NotFound();
            }
            return exams;
          
        }

        // GET: api/Exams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            Exam exam = await genericRepo.GetByID(id);
            if(exam == null)
            {
                return NotFound();
            }
            return exam;
        }

        // PUT: api/Exams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExam(int id, Exam exam)
        {
            if (id != exam.Id)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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

        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
          if (_context.Exams == null)
          {
              return Problem("Entity set 'MCQExamDbContext.Exams'  is null.");
          }
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExam", new { id = exam.Id }, exam);
        }

        // DELETE: api/Exams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            if (_context.Exams == null)
            {
                return NotFound();
            }
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamExists(int id)
        {
            return (_context.Exams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
