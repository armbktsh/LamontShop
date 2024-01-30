namespace Products.Infrastructure.Persistence;

public static class SeedDbContext
{
    public static void Seed(ApplicationDbContext context)
    {
        if (!context.Jewelries.Any())
        {
            context.Jewelries.AddRange(new List<Jewelry>
            {

            });
            context.SaveChanges();
        }
    }
}
