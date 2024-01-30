namespace Categories.API.DTOs;

public class UpdateCategoryDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    [MinLength(2)]
    public string? Title { get; set; }
}