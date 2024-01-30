using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Pages.Categories;

public class Update : PageModel
{
    private readonly ICategoryService _productService;

    public Update(ICategoryService productService)
    {
        _productService = productService;
    }

    [BindProperty] public UpdateInputModel InputModel { get; set; }

    public async Task OnGetAsync(int id)
    {
        var category = await _productService.GetCategoryAsync(id);
        InputModel = new()
        {
            Id = category.Id,
            Title = category.Title
        };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            //TODO:use auto mapper
            await _productService.UpdateCategoryAsync(new Category
            {
                Id = InputModel.Id,
                Title = InputModel.Title
            });

            return RedirectToPage("./Index");
        }

        return Page();
    }
}