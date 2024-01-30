using System.ComponentModel.DataAnnotations;

namespace WebMVC.Pages.Products;

public class CreateInputModel
{
    [Required] public string? Name { get; set; }
    [Required] public int Price { get; set; }
    [Required] public IFormFile? Image { get; set; }
    [Required] public string? Country { get; set; }
    [Required] public string? Substance { get; set; }
}