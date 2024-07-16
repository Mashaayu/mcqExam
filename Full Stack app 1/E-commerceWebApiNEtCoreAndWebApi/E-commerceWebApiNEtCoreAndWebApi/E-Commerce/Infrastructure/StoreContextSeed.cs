using E_Commerce.Data;
using E_Commerce.Models;
using System.Text.Json;

namespace E_Commerce.Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbcontext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //add brands
                if (!context.ProductBrands.Any())
                {
                    var brandfile = File.ReadAllText(@"Data/SeedData/brands.json");
                    
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandfile).ToList();

                    foreach (var brand in brands)
                    {
                       // context.ProductBrands.Add(brand);
                    }

                }
                await context.SaveChangesAsync();

                //adding tpes

                if (!context.ProductTypes.Any())
                {
                    var typefile = File.ReadAllText("Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typefile);
                    foreach (var type in types)
                    {
                      //  context.ProductTypes.Add(type);
                    }
                }
                await context.SaveChangesAsync();

                //adding Products
                Console.WriteLine(context.Products.ToList().ToString());
                if (!context.Products.Any())
                {
                    var productfile = File.ReadAllText("Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productfile);
                    foreach (var product in products)
                    {
                      //  context.Products.Add(product);
                    }

                }
                await context.SaveChangesAsync();
                Console.WriteLine(context.Products.ToList().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
