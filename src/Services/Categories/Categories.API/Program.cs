var builder = WebApplication.CreateBuilder(args);

// TODO:Move serilog config to appsettings
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("CategoriesApiSpec", new()
    {
        Version = "1",
        Title = "CategoriesAPI"
    });
});

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration["ConnectionString"]));

builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "AllowedOrigins",
//        config =>
//        {
//            config.WithOrigins("http://localhost:50")
//                .AllowCredentials()
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//        });
//});

var app = builder.Build();

// Migration
app.MigrateToDatabase<AppDbContext>(SeedContext.Seed);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/CategoriesApiSpec/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseSerilogRequestLogging();

//app.UseCors("AllowedOrigins");

app.MapControllers();

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