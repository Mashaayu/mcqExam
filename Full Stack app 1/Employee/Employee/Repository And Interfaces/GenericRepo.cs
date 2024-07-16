using Hospital.Data;
using Hospital.Repository_And_Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository_And_Interfaces
{
    public class GenericRepo<T> :ControllerBase, IGenericRepo<T> where T : class
    {
        private readonly EmployeeDbcontext _context;

        public GenericRepo(EmployeeDbcontext context)
        {
            _context = context;
        }
        //get all data method
        public async Task<ActionResult<List<T>>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        //get by id method
        public async Task<ActionResult<T>> GetByID(int id)
        {
            T Data = await _context.Set<T>().FindAsync(id);
            if (Data != null)
            {
                return NotFound();
            }
            return Data;
        }

        //delete method by id

        public async Task<ActionResult<List<T>>> DeleteById(int id)
        {
            T Data = await _context.Set<T>().FindAsync(id);
            if(Data != null)
            {
                return NotFound();
            }
            _context.Set<T>().Remove(Data); 

            return Ok(GetAll());
        }

    }
}
