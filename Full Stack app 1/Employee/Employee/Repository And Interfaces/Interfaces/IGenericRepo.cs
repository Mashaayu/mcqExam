using Microsoft.AspNetCore.Mvc;

namespace Hospital.Repository_And_Interfaces.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {

        public Task<ActionResult<List<T>>> GetAll();
        public Task<ActionResult<T>> GetByID(int id);
        public Task<ActionResult<List<T>>> DeleteById(int id);


    }
}
