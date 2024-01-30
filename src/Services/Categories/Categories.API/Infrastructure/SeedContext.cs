namespace Categories.API.Infrastructure;

public static class SeedContext
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Categories.Any())
        {
            context.Categories.AddRange(new List<Category>
            {
                new()
                {
                    Title = "test"
                }
            });
            context.SaveChanges();
        }
    }
}
