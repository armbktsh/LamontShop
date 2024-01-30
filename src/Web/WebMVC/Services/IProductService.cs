namespace WebMVC.Services;

public interface IProductService
{
    Task<IEnumerable<Jewelry>> GetJewelriesAsync();
    Task<Jewelry> GetJewelryAsync(int id);
    Task CreateJewelryAsync(Jewelry jewelry, IFormFile image);
    Task UpdateJewelryAsync(Jewelry jewelry, IFormFile? image);
    Task DeleteJewelryAsync(int id);
    Task<byte[]> GetImageAsync(int jewelryId);
}