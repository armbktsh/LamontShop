using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Pages
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
