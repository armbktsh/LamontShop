namespace WebMVC.Pages.Products;

public class Index : PageModel
{
    private readonly IProductService _productService;

    public Index(IProductService productService)
    {
        _productService = productService;
    }

    public IEnumerable<Jewelry> Jewelries { get; set; }

    public async Task OnGetAsync()
    {
        Jewelries = await _productService.GetJewelriesAsync();
    }
}