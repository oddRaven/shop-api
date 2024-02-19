using TimoShopApi.Database;
using TimoShopApi.Models;

namespace TimoShopApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ShopContext _shopContext;

        public ProductService(IConfiguration configuration)
        {
            _shopContext = new(configuration);
        }

        public Product? Get(int id)
        {
            return _shopContext.Products.FirstOrDefault(product => product.ID == id);
        }

        public IEnumerable<Product> GetAll() => [.. _shopContext.Products];
    }
}
