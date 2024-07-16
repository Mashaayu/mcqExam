using E_Commerce.Interfaces.Specification_Interface;
using E_Commerce.Models;

namespace E_Commerce.Repository.Specofication
{
    public class ProductWithTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductWithTypeAndBrandSpecification()
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
        public ProductWithTypeAndBrandSpecification(int Id): base(x => x.Id == Id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}
