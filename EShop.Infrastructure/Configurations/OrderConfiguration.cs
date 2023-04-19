using EShop.Domain.Customers;
using EShop.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder
            .Property(o => o.Id)
            .HasConversion(o => o.Id, value => new OrderId(value));
        builder
            .HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();
        builder
            .HasMany(o => o.LineItems)
            .WithOne()
            .HasForeignKey(o => o.OrderId);
    }
}
