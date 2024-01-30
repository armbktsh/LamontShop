namespace Baskets.API.Models;

public class BasketItem
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Price { get; set; }
    public int ProductId { get; set; }
    public int BasketId { get; set; }
    public Basket Basket { get; set; }
}