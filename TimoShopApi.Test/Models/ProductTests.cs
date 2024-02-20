using FluentAssertions;
using TimoShopApi.Models;

namespace TimoShopApi.Test.Models;

[TestClass]
public class ProductTests
{
    [TestMethod]
    [DataRow(3, 3)]
    [DataRow(-1, 0)]
    [DataRow(6, 5)]
    public void CartAmount_Sets_IsSet(int inputCartAmount, int expectedCartAmount)
    {
        // Arrange
        var product = new Product
        {
            StorageAmount = 5
        };

        // Act
        product.CartAmount = inputCartAmount;

        // Assert
        product.CartAmount.Should().Be(expectedCartAmount);
    }
}
