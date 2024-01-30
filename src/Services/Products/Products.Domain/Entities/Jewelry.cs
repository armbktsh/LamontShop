namespace Products.Domain.Entities;

public class Jewelry
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public string? Image { get; set; }
    public string? Country { get; set; }
    public string? Substance { get; set; }
}
