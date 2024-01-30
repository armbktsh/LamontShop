using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Pages.Products;

public class Update : PageModel
{
    private readonly IProductService _productService;

    public Update(IProductService productService)
    {
        _productService = productService;
    }

    [BindProperty] public UpdateInputModel InputModel { get; set; }

    public async Task OnGetAsync(int id)
    {
        var jewelry = await _productService.GetJewelryAsync(id);
        InputModel = new()
        {
            Id = jewelry.Id,
            Name = jewelry.Name,
            Country = jewelry.Country,
            Price = jewelry.Price,
            Substance = jewelry.Substance,
            OldImage = jewelry.Image,
        };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            //TODO:use auto mapper
            await _productService.UpdateJewelryAsync(new Jewelry
            {
                Id = InputModel.Id,
                Country = InputModel.Country,
                Name = InputModel.Name,
                Price = InputModel.Price,
                Substance = InputModel.Substance,
                Image = InputModel.Image == null ? InputModel.OldImage : Guid.NewGuid().ToString() + Path.GetExtension(InputModel.Image!.FileName)
            }, InputModel.Image);

            return RedirectToPage("./Index");
        }

        return Page();
    }
}