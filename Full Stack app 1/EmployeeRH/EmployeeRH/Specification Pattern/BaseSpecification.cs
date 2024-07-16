using EmployeeRH.Models;
using System.Linq.Expressions;

namespace EmployeeRH.Specification_Pattern
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T,bool>> Criteria)
        {
            this.Criteria = Criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddIncludes(Expression<Func<T,object>> IncludeExpression)
        {
            Includes.Add(IncludeExpression);
        }


    }
}
