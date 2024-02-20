using Microsoft.Extensions.Options;
using TimoShopApi.Configurations;
using TimoShopApi.Database;
using TimoShopApi.Models;

namespace TimoShopApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ShopContext _shopContext;

        public ProductService(IOptions<DatabaseConfiguration> databaseConfigurationOptions)
        {
            _shopContext = new(databaseConfigurationOptions);
        }

        public Product? Get(int id)
        {
            return _shopContext.Products.FirstOrDefault(product => product.ID == id);
        }

        public void Update(Product product)
        {
            _shopContext.Update(product);
            _shopContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll() => [.. _shopContext.Products];
    }
}
