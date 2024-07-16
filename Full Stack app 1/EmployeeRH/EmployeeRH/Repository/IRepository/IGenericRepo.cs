using EmployeeRH.Specification_Pattern;
using NuGet.Packaging.Signing;

namespace EmployeeRH.Repository.IRepository
{
    public interface IGenericRepo<T>
    {
        public Task<List<T>> GetAll();
        public Task<T> GetByID(int id);
        public Task<List<T>> DeleteById(int id);

        public Task<T> GetEntityWithSpec(ISpecification<T> specification);
        public Task<List<T>> ListAsync(ISpecification<T> specification);

    }
}
