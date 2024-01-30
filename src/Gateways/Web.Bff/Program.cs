var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((context, config) =>
{
    var env = context.HostingEnvironment;
    config
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile($"ocelot.json", true, true)
        .AddJsonFile($"ocelot.{env.EnvironmentName}.json", true, true)
        .AddEnvironmentVariables();
});

// TODO:Move serilog config to appsettings
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
            .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddOcelot();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.MapGet("/", () => "This is API Gateway");

app.UseOcelot().Wait();

try
{
    Log.Information("Starting web host ...");
    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
