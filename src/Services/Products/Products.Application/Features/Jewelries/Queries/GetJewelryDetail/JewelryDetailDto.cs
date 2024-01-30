namespace Products.Application.Features.Jewelries.Queries.GetJewelryDetail;

public class JewelryDetailDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Price { get; set; }
    public string? Image { get; set; }
    public string? Country { get; set; }
    public string? Substance { get; set; }
    public string? CategoryName { get; set; }
    public int CategoryId { get; set; }
}