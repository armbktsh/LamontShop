namespace WebMVC.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _client;

    public ProductService(IHttpClientFactory httpClientFactory,
        IHttpContextAccessor accessor)
    {
        _client = httpClientFactory.CreateClient("Api");

        _client.DefaultRequestHeaders.Authorization =
            new("Bearer",
                accessor.HttpContext!.GetTokenAsync("access_token").Result ?? "");
    }

    public async Task<IEnumerable<Jewelry>> GetJewelriesAsync()
    {
        var response = await _client.GetAsync("jewelry");

        response.EnsureSuccessStatusCode();

        return JsonConvert.DeserializeObject<IEnumerable<Jewelry>>(
            await response.Content.ReadAsStringAsync())!;
    }

    public async Task<Jewelry> GetJewelryAsync(int id)
    {
        var httpResponseMessage = await _client.GetAsync($"jewelry/{id}");

        httpResponseMessage.EnsureSuccessStatusCode();

        return JsonConvert.DeserializeObject<Jewelry>(
            await httpResponseMessage.Content.ReadAsStringAsync())!;
    }

    public async Task CreateJewelryAsync(Jewelry jewelry, IFormFile image)
    {
        var body = new StringContent(
           JsonConvert.SerializeObject(jewelry),
           Encoding.UTF8,
           MediaTypeNames.Application.Json);

        using var httpResponseMessage =
            await _client.PostAsync("jewelry", body);

        httpResponseMessage.EnsureSuccessStatusCode();

        await UploadImageAsync(image, jewelry.Image!);
    }

    public async Task UpdateJewelryAsync(Jewelry jewelry, IFormFile? image)
    {
        var body = new StringContent(
            JsonConvert.SerializeObject(jewelry),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);

        using var httpResponseMessage =
            await _client.PutAsync($"jewelry", body);

        httpResponseMessage.EnsureSuccessStatusCode();

        if (image != null)
            await UploadImageAsync(image, jewelry.Image!);
    }

    public async Task DeleteJewelryAsync(int id)
    {
        using var httpResponseMessage =
            await _client.DeleteAsync($"/jewelry/{id}");

        httpResponseMessage.EnsureSuccessStatusCode();
    }

    private async Task UploadImageAsync(IFormFile image, string fileName)
    {
        using var body = new MultipartFormDataContent();

        body.Add(new StreamContent(image.OpenReadStream()), "image", fileName);

        using var httpResponseMessage =
            await _client.PostAsync("jewelry/UploadImage", body);

        httpResponseMessage.EnsureSuccessStatusCode();
    }

    public async Task<byte[]> GetImageAsync(int jewelryId)
    {
        var httpResponseMessage = await _client.GetAsync($"jewelry/GetImage/{jewelryId}");

        httpResponseMessage.EnsureSuccessStatusCode();

        return await httpResponseMessage.Content.ReadAsByteArrayAsync();
    }
}