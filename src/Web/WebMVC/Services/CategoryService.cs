namespace WebMVC.Services;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _client;

    public CategoryService(IHttpClientFactory httpClientFactory,
        IHttpContextAccessor accessor)
    {
        _client = httpClientFactory.CreateClient("Api");

        _client.DefaultRequestHeaders.Authorization =
            new("Bearer",
                accessor.HttpContext!.GetTokenAsync("access_token").Result ?? "");
    }


    public Task CreateCategoryAsync(Category Category)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        var response = await _client.GetAsync("category");

        response.EnsureSuccessStatusCode();

        return JsonConvert.DeserializeObject<IEnumerable<Category>>(
            await response.Content.ReadAsStringAsync())!;
    }

    public Task<Category> GetCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(Category Category)
    {
        throw new NotImplementedException();
    }
}
