namespace Products.Application.Common.Contracts.Persistence;

public interface IJewelryRepository
{
    Task<IEnumerable<Jewelry>> GetJewelriesAsync();
    Task<Jewelry> GetJewelryAsync(int id);
    Task<Jewelry> CreateJewelryAsync(Jewelry jewelry);
    Task UpdateJewelryAsync(Jewelry jewelry);
    Task DeleteJewelryAsync(Jewelry jewelry);
}