using E_Commerce.Models;

namespace E_Commerce.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByProductsIdAsync(int id);
        Task<List<Product>> GetProducts();
        Task<List<ProductBrand>> GetBrands();
        Task<List<ProductType>> GetTypes();

    }
}
