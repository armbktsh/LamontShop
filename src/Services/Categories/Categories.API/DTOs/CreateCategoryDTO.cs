namespace Categories.API.DTOs;

public class CreateCategoryDto
{
    [Required]
    [MaxLength(150)]
    [MinLength(2)]
    public string? Title { get; set; }
}