namespace Products.Infrastructure.Repositories;

#nullable disable
public class JewelryRepository : IJewelryRepository
{
    private readonly ApplicationDbContext _context;

    public JewelryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Jewelry> CreateJewelryAsync(Jewelry jewelry)
    {
        _context.Add(jewelry);
        await _context.SaveChangesAsync();

        return jewelry;
    }

    public async Task DeleteJewelryAsync(Jewelry jewelry)
    {
        _context.Remove(jewelry);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Jewelry>> GetJewelriesAsync() => await _context.Jewelries.ToListAsync();

    public async Task<Jewelry> GetJewelryAsync(int id) => await _context.Jewelries.FindAsync(id);

    public async Task UpdateJewelryAsync(Jewelry jewelry)
    {
        _context.Jewelries.Update(jewelry);
        await _context.SaveChangesAsync();
    }
}
