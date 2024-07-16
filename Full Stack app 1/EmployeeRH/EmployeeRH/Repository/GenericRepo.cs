using EmployeeRH.Context;
using EmployeeRH.Repository.IRepository;
using EmployeeRH.Specification_Pattern;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NuGet.Packaging.Signing;

namespace EmployeeRH.Repository
{
    public class GenericRepo<T>:IGenericRepo<T> where T : class
    {
        private readonly EmployeeRHDbContext dbcontext;
        public GenericRepo(EmployeeRHDbContext context) {
            this.dbcontext = context;
        }
        public async Task<List<T>> GetAll()
        {
            return await dbcontext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByID(int Id)
        {
            return await dbcontext.Set<T>().FindAsync(Id);
        }
        
        public async Task<List<T>> DeleteById(int Id)
        {
            T data = await dbcontext.Set<T>().FindAsync(Id);
            dbcontext.Set<T>().Remove(data);
            await dbcontext.SaveChangesAsync();
            return await GetAll();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> Specification)
        {
            return SpecificationEvaluator<T>.GetQury(dbcontext.Set<T>().AsQueryable(), Specification);
        }
    }
}
