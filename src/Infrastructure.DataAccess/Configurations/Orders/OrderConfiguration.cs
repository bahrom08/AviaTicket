using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Orders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.OfferId)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasColumnType("decimal(20,2)")
            .IsRequired();

        builder.Property(x => x.BaggagePrice)
            .HasColumnType("decimal(20,2)")
            .IsRequired(false);

        builder.Property(x => x.CurrencyId)
            .IsRequired();

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyId)
            .IsRequired();

        builder.Property(x => x.CurrencyRate)
            .HasColumnType("decimal(20,2)")
            .IsRequired();

        builder.Property(x => x.TicketNumber)
            .HasMaxLength(50)
            .IsRequired(false);

        builder.Property(x => x.OrderStatusId)
            .IsRequired();

        builder.HasOne(x => x.OrderStatus)
            .WithMany()
            .HasForeignKey(x => x.OrderStatusId)
            .IsRequired();
    }
}