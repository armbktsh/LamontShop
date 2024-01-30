using Microsoft.AspNetCore.Authorization;

namespace Categories.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<CategoryDto>))]
    public async Task<IActionResult> GetCategories()
        => Ok(_mapper.Map<IEnumerable<CategoryDto>>(await _context.Categories.ToListAsync()));

    [HttpGet("{id:int}", Name = "GetCategory")]
    [ProducesResponseType(200, Type = typeof(CategoryDto))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetCategory(int id)
    {
        var category = _mapper.Map<CategoryDto>(await _context.Categories.FindAsync(id));

        if (category == null) return NotFound("The given id did not found");

        return Ok(category);
    }

    [HttpPost]
    [ProducesResponseType(400)]
    [ProducesResponseType(201)]
    [Authorize]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);

        _context.Categories.Add(category);
        await Save();

        return CreatedAtRoute("GetCategory", new { id = category.Id }, category);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [Authorize]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto, int id)
    {
        if (categoryDto.Id != id)
            return BadRequest("'id' does not match in body and route parameter");

        var category = _mapper.Map<Category>(categoryDto);

        _context.Categories.Update(category);
        await Save();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [Authorize]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null) return NotFound("The given id did not found");

        _context.Categories.Remove(category);
        await Save();

        return NoContent();
    }

    private async Task Save() => await _context.SaveChangesAsync();
}
