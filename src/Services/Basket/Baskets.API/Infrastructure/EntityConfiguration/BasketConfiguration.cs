namespace Baskets.API.Infrastructure.EntityConfiguration;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        // builder.HasKey(b => b.UserId);
    }
}