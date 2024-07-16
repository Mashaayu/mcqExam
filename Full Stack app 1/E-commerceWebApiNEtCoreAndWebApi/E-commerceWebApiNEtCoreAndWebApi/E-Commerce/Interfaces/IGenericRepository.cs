using E_Commerce.Interfaces.Specification_Interface;
using E_Commerce.Models;

namespace E_Commerce.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<List<T>> ListAll();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<List<T>> ListAsync(ISpecification<T> spec);
    }
}
