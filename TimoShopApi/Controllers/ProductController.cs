using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimoShopApi.Models;
using TimoShopApi.Requests;
using TimoShopApi.Responses;
using TimoShopApi.Services;

namespace TimoShopApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public ProductController(IMapper mapper, IProductService productService)
    {
        _mapper = mapper;
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductResponse>> Get()
    {
        IEnumerable<Product> products = _productService.GetAll();
        var productsResponse = _mapper.Map<IEnumerable<ProductResponse>>(products);
        return Ok(productsResponse);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductResponse> Get(int id)
    {
        Product? product = _productService.Get(id);

        if (product == null)
        {
            return NotFound();
        }

        var productResponse = _mapper.Map<ProductResponse>(product);

        return Ok(productResponse);
    }

    [HttpPut("{id}")]
    public ActionResult<ProductResponse> Update(int id, [FromBody] ProductRequest productRequest)
    {
        Product? product = _productService.Get(id);

        if (product == null)
        {
            return NotFound();
        }

        _mapper.Map(productRequest, product);
        _productService.Update(product);

        var productResponse = _mapper.Map<ProductResponse>(product);

        return Ok(productResponse);
    }
}
