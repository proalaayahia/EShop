using EShop.Domain.Orders;
using EShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Infrastructure.Configurations;

public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.HasKey(l => l.Id);
        builder
            .Property(l => l.Id)
            .HasConversion(l => l.Id, value => new LineItemId(value));
        builder
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(l => l.ProductId)
            .IsRequired();
        builder.OwnsOne(l => l.Price);
    }
}
