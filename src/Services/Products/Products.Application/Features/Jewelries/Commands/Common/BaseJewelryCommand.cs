namespace Products.Application.Features.Jewelries.Commands.Common;

public class BaseJewelryCommand
{
    public string? Name { get; set; }
    public int Price { get; set; }
    public string? Image { get; set; }
    public string? Country { get; set; }
    public string? Substance { get; set; }
    public int CategoryId { get; set; }
}