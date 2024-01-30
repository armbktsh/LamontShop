namespace Products.Infrastructure.Persistence.EntityConfiguration;

public class JewelryConfiguration : IEntityTypeConfiguration<Jewelry>
{
    public void Configure(EntityTypeBuilder<Jewelry> builder)
    {
        builder.Property(j => j.Name).HasMaxLength(150).IsRequired();

        builder.Property(j => j.Price).IsRequired();

        builder.Property(j => j.Country).IsRequired();

        builder.Property(j => j.Image).IsRequired();

        builder.Property(j => j.Substance).HasMaxLength(50).IsRequired();
    }
}
