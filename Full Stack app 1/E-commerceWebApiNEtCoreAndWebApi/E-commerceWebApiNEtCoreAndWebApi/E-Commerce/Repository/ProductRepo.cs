using E_Commerce.Data;
using E_Commerce.Interfaces;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository
{
    public class ProductRepo : IProductRepository
    {
        private readonly StoreDbcontext _dbcontext;

        public ProductRepo(StoreDbcontext dbcontext)
        {
           _dbcontext = dbcontext;
        }
        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = await _dbcontext.Products.ToListAsync();

            return products;
        }

        public async Task<Product> GetByProductsIdAsync(int id)
        {
            Product product = await _dbcontext.Products.FindAsync(id);

            return product;
        }

        public async Task<List<ProductBrand>> GetBrands()
        {
            List<ProductBrand> Brands = await _dbcontext.ProductBrands.ToListAsync();
            return Brands;

        }

        public async Task<List<ProductType>> GetTypes()
        {
           List<ProductType> productTypes = await _dbcontext.ProductTypes.ToListAsync();
            return productTypes;
        }

    }
}
