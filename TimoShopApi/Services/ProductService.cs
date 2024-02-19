using TimoShopApi.Models;

namespace TimoShopApi.Services
{
    public class ProductService : IProductService
    {
        private const string loremIpsumText = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ac turpis nibh. Curabitur consequat id eros at vestibulum. Maecenas sit amet leo id ipsum sollicitudin maximus quis at metus. Sed non ex eu est dignissim ultrices. Aenean ac tempor mauris. Nullam tincidunt eget felis vitae condimentum. Mauris ut augue sit amet massa dictum mattis eu ut metus. Praesent pulvinar neque id dolor pellentesque, blandit euismod eros aliquam. Nunc ut auctor leo. Proin id diam quis purus suscipit efficitur vel vel sem.

Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Duis vel arcu ut leo laoreet aliquam id non nibh. Integer risus ipsum, commodo in malesuada ac, lobortis eu augue. Morbi ullamcorper ante arcu, eu blandit sem fringilla vel. Nam facilisis auctor ante quis commodo. Proin ex magna, pulvinar sed lorem at, mollis egestas nibh. Aliquam quis mollis augue. Duis volutpat ornare metus eu egestas. Nulla condimentum neque non congue dignissim. Mauris lectus nisi, mollis a sagittis vel, mollis vitae lacus. Morbi pharetra quam non euismod lacinia. Proin quis urna leo. Nam ac magna id elit interdum tempus. Integer aliquam dignissim laoreet. In vel sapien turpis. Nullam molestie ex vitae nibh vulputate commodo.";

        private readonly IEnumerable<Product> _products = new List<Product>()
        {
            new Product
            {
                Title = "product1",
                Description = loremIpsumText,
                Price = 10.50m,
                StorageAmount = 3
            },
            new Product
            {
                Title = "product2",
                Description = loremIpsumText,
                Price = 11.50m,
                StorageAmount = 3
            },
            new Product
            {
                Title = "product3",
                Description = loremIpsumText,
                Price = 12.50m,
                StorageAmount = 3
            },
            new Product
            {
                Title = "product4",
                Description = loremIpsumText,
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
