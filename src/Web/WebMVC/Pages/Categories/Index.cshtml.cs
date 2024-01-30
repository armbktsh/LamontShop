namespace WebMVC.Pages.Categories;

public class Index : PageModel
{
    private readonly ICategoryService _productService;
    private readonly IHttpContextAccessor _contextAccessor;

    public Index(ICategoryService productService, IHttpContextAccessor contextAccessor)
    {
        _productService = productService;
        _contextAccessor = contextAccessor;
    }

    public IEnumerable<Category> Categories { get; set; }

    public async Task OnGetAsync()
    {
        //ViewData["User"] = _contextAccessor.HttpContext.User.FindFirst(c => c.Type == "email");

        Categories = await _productService.GetCategoriesAsync();
    }
}