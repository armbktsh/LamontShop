namespace Baskets.API.Models;

public class Basket
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<BasketItem> Items { get; set; }
}