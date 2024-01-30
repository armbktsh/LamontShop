using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ErrorModel : PageModel
{
    public string? ExceptionMessage { get; set; }

    public void OnGet()
    {
        var exceptionHandlerPathFeature =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        if (exceptionHandlerPathFeature?.Error is HttpRequestException)
        {
            ExceptionMessage = exceptionHandlerPathFeature
                .Error
                .GetBaseException()
                .Message;
        }

        ExceptionMessage = "Something went wrong!";
    }
}