using EShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder
            .Property(p => p.Id)
            .HasConversion(p => p.Id, value => new ProductId(value));
        builder.Property(p => p.Name).HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(255);
        builder.Property(p => p.SKU)
            .HasConversion(sku => sku.Value, value => SKU.Create(value)!);
        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.Currency).HasMaxLength(3);
        });
    }
}
