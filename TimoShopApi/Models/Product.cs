using Microsoft.EntityFrameworkCore;

namespace TimoShopApi.Models;

public class Product
{
    private int _cartAmount = 0;

    public int ID { get; init; }
    public string Title { get; init; } = "";
    public string Description { get; init; } = "";
    [Precision(18, 2)]
    public decimal Price { get; init; }
    public string? ImageUrl { get; init; }
    public int StorageAmount { get; init; }

    public int CartAmount {
        get => _cartAmount; 
        set
        {
            if (value < 0)
            {
                _cartAmount = 0;
            }
            else if (value > StorageAmount)
            {
                _cartAmount = StorageAmount;
            }
            else
            {
                _cartAmount = value;
            }
        } 
    }
}
