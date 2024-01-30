using System.ComponentModel.DataAnnotations;

namespace WebMVC.Pages.Categories;

public class UpdateInputModel
{
    [Required] public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    [MinLength(2)]
    public string? Title { get; set; }
}