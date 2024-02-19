using TimoShopApi.Models;

namespace TimoShopApi.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(Guid guid);
    }
}
