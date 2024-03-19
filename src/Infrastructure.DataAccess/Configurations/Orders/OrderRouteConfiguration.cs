using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Orders;

public class OrderRouteConfiguration : IEntityTypeConfiguration<OrderRoute>
{
    public void Configure(EntityTypeBuilder<OrderRoute> builder)
    {
        builder.Property(x => x.OrderId)
            .IsRequired();

        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderRoutes)
            .HasForeignKey(x => x.OrderId)
            .IsRequired();

        builder.Property(x => x.DurationInSeconds)
            .IsRequired();

        builder.Property(x => x.CanRefund)
            .IsRequired();

        builder.Property(x => x.CanChange)
            .IsRequired();

        builder.Property(x => x.ArrivalAirportId)
            .IsRequired();

        builder.HasOne(x => x.ArrivalAirport)
            .WithMany()
            .HasForeignKey(x => x.ArrivalAirportId)
            .IsRequired();

        builder.Property(x => x.ArrivalAt)
            .IsRequired();

        builder.Property(x => x.DepartureAirportId)
            .IsRequired();

        builder.HasOne(x => x.DepartureAirport)
            .WithMany()
            .HasForeignKey(x => x.DepartureAirportId)
            .IsRequired();

        builder.Property(x => x.DepartureAt)
            .IsRequired();
    }
}