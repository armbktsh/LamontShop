namespace Identity.API.Extensions;

public static class HostExtensions
{
    public static WebApplication MigrateToDatabase<TDbContext>(this WebApplication host,
        Action<UserManager<IdentityUser>, RoleManager<IdentityRole>> seed, int count = 0) where TDbContext : DbContext
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();
        var context = services.GetRequiredService<TDbContext>();

        try
        {
            logger.LogInformation("Migrating to the database ...");
            context.Database.Migrate();
            logger.LogInformation("Migrated successfully.");

            logger.LogInformation("Seeding the database ...");
            seed(services.GetRequiredService<UserManager<IdentityUser>>(),
                services.GetRequiredService<RoleManager<IdentityRole>>());
            logger.LogInformation("Seeded successfully.");
        }
        catch (Exception ex)
        {
            //TODO:Use Polly
            logger.LogInformation($"Something went wrong!\n  {ex.Message}");
            count++;
            if (count < 50) MigrateToDatabase<TDbContext>(host, seed, count);
        }

        return host;
    }
}