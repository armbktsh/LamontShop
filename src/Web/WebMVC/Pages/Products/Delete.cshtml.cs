using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Pages.Products;

[Authorize]
public class Delete : PageModel
{
    private readonly IProductService _productService;

    public Delete(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        await _productService.DeleteJewelryAsync(id);

        return RedirectToPage("./Index");
    }
}