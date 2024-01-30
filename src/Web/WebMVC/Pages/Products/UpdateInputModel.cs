using System.ComponentModel.DataAnnotations;

namespace WebMVC.Pages.Products;

public class UpdateInputModel
{
    [Required] public int Id { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public int Price { get; set; }
    public IFormFile? Image { get; set; }
    [Required] public string? OldImage { get; set; }
    [Required] public string? Country { get; set; }
    [Required] public string? Substance { get; set; }
}