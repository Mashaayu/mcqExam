using E_Commerce.Models;
using System.Linq.Expressions;

namespace E_Commerce.Interfaces.Specification_Interface
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}
