namespace Baskets.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BasketController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Basket>))]
    public async Task<IActionResult> GetBaskets()
    {
        var baskets = await _context.Baskets.Include(b => b.Items).ToListAsync();

        var basketDtos = new List<BasketDTO>();
        foreach (var basket in baskets)
        {
            basketDtos.Add(_mapper.Map<BasketDTO>(basket));
        }

        return Ok(basketDtos);
    }

    [HttpGet("{userId:int}", Name = "GetBasket")]
    [ProducesResponseType(200, Type = typeof(Basket))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetBasket(int userId)
    {
        var basket = await _context.Baskets
            .Include(b => b.Items)
            .FirstOrDefaultAsync(b => b.UserId == userId);

        if (basket == null) return NotFound("The given id did not found");

        var basketDto = _mapper.Map<BasketDTO>(basket);

        return Ok(basketDto);
    }

    [HttpPost]
    [ProducesResponseType(400)]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateBasket([FromBody] int userId)
    {
        if (_context.Baskets.Any(b => b.UserId == userId))
            return BadRequest("This user already has an basket");

        var basket = _context.Baskets.Add(new Basket { UserId = userId }).Entity;

        await Save();

        return CreatedAtRoute("GetBasket", new { userId = userId }, basket);
    }

    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    public async Task<IActionResult> UpdateBasket(BasketDTO basketDto)
    {
        var basket = _mapper.Map<Basket>(basketDto);

        _context.Baskets.Update(basket);
        await Save();

        return NoContent();
    }

    [HttpDelete("{userId:int}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    public async Task<IActionResult> DeleteBasket(int userId)
    {
        var basket = await _context.Baskets.SingleOrDefaultAsync(b => b.UserId == userId);

        if (basket == null) return NotFound("The given id did not found");

        _context.Baskets.Remove(basket);
        await Save();

        return NoContent();
    }

    private async Task Save() => await _context.SaveChangesAsync();
}