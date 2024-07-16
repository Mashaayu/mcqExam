using EmployeeRH.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRH.Specification_Pattern
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQury(IQueryable<TEntity> query,
            ISpecification<TEntity> specification)
        {
            var Query = query;
            if(specification.Criteria != null)
            {
               Query =  Query.Where(specification.Criteria);
            }

            Query = specification.Includes.Aggregate(Query, (currrent, include) =>
                    currrent.Include(include)
            );
            return Query;
        }
    }
}
