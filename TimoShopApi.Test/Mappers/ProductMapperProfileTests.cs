using AutoMapper;
using FluentAssertions;
using TimoShopApi.Mappers;
using TimoShopApi.Models;
using TimoShopApi.Requests;
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
    [DataRow(4, 4)]
    [DataRow(8, 6)]
    public void Map_ProductRequestToProduct_SetCartAmount(int newCartAmount, int expectedCartAmount)
    {
        // Arrange
        var productRequest = new ProductRequest
        {
            CartAmount = newCartAmount
        };

        var product = new Product
        {
            ID = 1,
            Title = "Product 1",
            Description = "Product 1 description",
            Price = 10.5m,
            StorageAmount = 6,
            CartAmount = 2
        };

        var expectedProduct = new Product
        {
            ID = 1,
            Title = "Product 1",
            Description = "Product 1 description",
            Price = 10.5m,
            StorageAmount = 6,
            CartAmount = expectedCartAmount
        };

        // Act
        _mapper.Map(productRequest, product);

        // Assert
        product.Should().BeEquivalentTo(expectedProduct);
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
            CartAmount = 2
        };

        int expectedStorageAvailableAmount = 4;

        // Act
        var productResponse = _mapper.Map<ProductResponse>(product);

        // Assert
        productResponse.StorageAvailableAmount.Should().Be(expectedStorageAvailableAmount);
    }
}
