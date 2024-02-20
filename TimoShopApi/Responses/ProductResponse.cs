namespace TimoShopApi.Responses;

public class ProductResponse
{
    public int ID { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public string? ImageUrl { get; init; }
    public int StorageAmount { get; init; }
    public int StorageAvailableAmount { get; init; }
    public int CartAmount { get; init; }
}
