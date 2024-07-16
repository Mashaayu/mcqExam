using E_Commerce.Interfaces.Specification_Interface;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQury(IQueryable<TEntity> query, ISpecification<TEntity> Spec)
        {
            var Query = query;
            if(Spec.Criteria != null)
            {
                Query = Query.Where(Spec.Criteria);
            }

            Query = Spec.Includes.Aggregate(Query, (current, include) => current.Include(include));
            return Query;
        }
    }
}
