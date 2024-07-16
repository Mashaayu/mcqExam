using Hospital.Data;
using Hospital.Models;
using Hospital.Repository_And_Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository_And_Interfaces
{
    public class EmployeeRepo<T> : ControllerBase,IEmployeeRepo<T> where T : class
    {
        private readonly EmployeeDbcontext _context;

        public EmployeeRepo(EmployeeDbcontext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<T>>> PostData(T data)
        {
            var dataList = _context;   
            
            dataList.Set<T>().Add(data);
            dataList.SaveChanges();

            return await _context.Set<T>().ToListAsync();
        }

        public async Task<ActionResult<List<T>>> PutData(int id , T data)
        {
            var dataList = _context;

            
            dataList.SaveChanges();

            return await _context.Set<T>().ToListAsync();
        }
    }
}
