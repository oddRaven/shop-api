using AutoMapper;
using FluentAssertions;
using TimoShopApi.Mappers;
using TimoShopApi.Models;
using TimoShopApi.Responses;

namespace TimoShopApi.Test.Mappers;

[TestClass]
public class ProductMapperProfileTests
{
    private readonly IMapper _mapper;

    public ProductMapperProfileTests()
    {
         _mapper = new MapperConfiguration(mc => mc.AddProfile(new ProductMapperProfile()))
            .CreateMapper();
    }

    [TestMethod]
    public void Map_ProductToProductResponse_SetStorageAvailableAmount()
    {
        // Arrange
        var product = new Product
        {
            ID = 1,
            Title = "Product 1",
            Description = "Product 1 description",
            Price = 10.5m,
            StorageAmount = 6,
            CartAmount = 2,
        };

        int expectedStorageAvailableAmount = 4;

        // Act
        var productResponse = _mapper.Map<ProductResponse>(product);

        // Assert
        productResponse.StorageAvailableAmount.Should().Be(expectedStorageAvailableAmount);
    }
}
