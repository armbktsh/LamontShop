using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Pages.Categories;

[Authorize]
public class Create : PageModel
{
    private readonly ICategoryService _productService;

    public Create(ICategoryService productService)
    {
        _productService = productService;
    }

    [BindProperty] public CreateInputModel InputModel { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            //TODO:use auto mapper
            await _productService.CreateCategoryAsync(new Category
            {
                Title = InputModel.Title
            });

            return RedirectToPage("./Index");
        }

        return Page();
    }
}