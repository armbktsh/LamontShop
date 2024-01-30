using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Pages.Categories;

[Authorize]
public class Delete : PageModel
{
    private readonly ICategoryService _productService;

    public Delete(ICategoryService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        await _productService.DeleteCategoryAsync(id);

        return RedirectToPage("./Index");
    }
}