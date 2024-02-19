using TimoShopApi.Models;

namespace TimoShopApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IEnumerable<Product> _products = new List<Product>()
        {
            new Product
            {
                Name = "product1",
                Price = 10.50m,
                StorageAmount = 3
            },
            new Product
            {
                Name = "product2",
                Price = 11.50m,
                StorageAmount = 3
            },
            new Product
            {
                Name = "product3",
                Price = 12.50m,
                StorageAmount = 3
            },
            new Product
            {
                Name = "product4",
                Price = 13.50m,
                StorageAmount = 3
            }
        };

        public Product? Get(Guid guid)
        {
            return _products.FirstOrDefault(product => product.Guid == guid);
        }

        public IEnumerable<Product> GetAll() => _products;
    }
}
