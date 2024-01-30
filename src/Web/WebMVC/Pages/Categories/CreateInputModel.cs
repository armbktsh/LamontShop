using System.ComponentModel.DataAnnotations;

namespace WebMVC.Pages.Categories;

public class CreateInputModel
{
    [Required]
    [MaxLength(150)]
    [MinLength(2)]
    public string? Title { get; set; }
}