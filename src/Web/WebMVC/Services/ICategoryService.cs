namespace WebMVC.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryAsync(int id);
    Task CreateCategoryAsync(Category Category);
    Task UpdateCategoryAsync(Category Category);
    Task DeleteCategoryAsync(int id);
}
