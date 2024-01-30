namespace Categories.API.Infrastructure.EntityConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Title).HasMaxLength(50).IsRequired();
    }
}
