using E_Commerce.Data;
using E_Commerce.Infrastructure;
using E_Commerce.Interfaces;
using E_Commerce.Interfaces.Specification_Interface;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository
{
    public class GenericRepo<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreDbcontext _dbcontext;

        public GenericRepo(StoreDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAll()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec){
            return
                SpecificationEvaluator<T>.GetQury(_dbcontext.Set<T>().AsQueryable(),spec);
        }
    }
}
