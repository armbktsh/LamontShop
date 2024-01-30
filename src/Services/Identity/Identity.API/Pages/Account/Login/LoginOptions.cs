using System;

namespace IdentityServerHost.Pages.Login;

public class LoginOptions
{
    public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);
    public static string InvalidCredentialsErrorMessage = "Invalid username or password";
}