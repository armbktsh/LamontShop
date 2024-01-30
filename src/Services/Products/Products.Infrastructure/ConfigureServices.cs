namespace Products.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(configuration["ConnectionString"]));

        services.AddScoped<IJewelryRepository, JewelryRepository>();

        services.AddScoped<IFileService, FileService>();

        return services;
    }
}