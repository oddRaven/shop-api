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

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product? product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> Update(int id, [FromBody] int cartAmount)
        {
            Product? product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            product.CartAmount = cartAmount;

            return Ok(product);
        }
    }
}
