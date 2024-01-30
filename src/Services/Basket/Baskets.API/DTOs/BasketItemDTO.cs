namespace Baskets.API.DTOs;

public class BasketItemDTO
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public int Price { get; set; }
    public int ProductId { get; set; }
}