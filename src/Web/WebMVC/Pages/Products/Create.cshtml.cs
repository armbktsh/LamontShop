using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Pages.Products;

[Authorize]
public class Create : PageModel
{
    private readonly IProductService _productService;

    public Create(IProductService productService)
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
            await _productService.CreateJewelryAsync(new Jewelry
            {
                Country = InputModel.Country,
                Name = InputModel.Name,
                Price = InputModel.Price,
                Substance = InputModel.Substance,
                Image = Guid.NewGuid().ToString() + Path.GetExtension(InputModel.Image!.FileName)
            }, InputModel.Image!);

            return RedirectToPage("./Index");
        }

        return Page();
    }
}