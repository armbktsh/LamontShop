namespace Identity.API.Infrastructure;

public class SeedDbContext
{
    public static void Seed(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        var admin = new IdentityUser
        {
            UserName = "Admin",
            EmailConfirmed = true,
            Email = "admin@admin"
        };

        if (!userManager.Users.Any())
        {
            userManager.CreateAsync(admin, "12qwAS!@").Wait();
        }

        if (!roleManager.Roles.Any())
        {
            roleManager.CreateAsync(new IdentityRole { Name = "Admin" }).Wait();

            userManager.AddToRoleAsync(admin, "Admin").Wait();
        }
    }
}