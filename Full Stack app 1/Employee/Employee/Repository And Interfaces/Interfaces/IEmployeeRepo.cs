using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Repository_And_Interfaces.Interfaces
{
    public interface IEmployeeRepo<T>
    {
        public Task<ActionResult<List<T>>> PostData(T data);
        public Task<ActionResult<List<T>>> PutData(int id , T data);
        
    }
}
