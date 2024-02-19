using Microsoft.AspNetCore.Mvc;
using TimoShopApi.Models;
using TimoShopApi.Services;

namespace TimoShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            IEnumerable<Product> products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{guid}")]
        public ActionResult<Product> Get(Guid guid)
        {
            Product? product = _productService.Get(guid);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{guid}")]
        public ActionResult<Product> Update(Guid guid, [FromBody] int cartAmount)
        {
            Product? product = _productService.Get(guid);

            if (product == null)
            {
                return NotFound();
            }

            product.CartAmount = cartAmount;

            return Ok(product);
        }
    }
}
