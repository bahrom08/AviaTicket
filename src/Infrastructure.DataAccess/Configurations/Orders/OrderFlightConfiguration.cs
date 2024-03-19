using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Orders;

public class OrderFlightConfiguration : IEntityTypeConfiguration<OrderFlight>
{
    public void Configure(EntityTypeBuilder<OrderFlight> builder)
    {
        builder.Property(x => x.RoteId)
            .IsRequired();

        builder.HasOne(x => x.OrderRoute)
            .WithMany(x => x.OrderFlights)
            .HasForeignKey(x => x.RoteId)
            .IsRequired();

        builder.Property(x => x.Number)
            .IsRequired();

        builder.HasIndex(x => x.Number)
            .IsUnique();

        builder.Property(x => x.AirlineId)
            .IsRequired();

        builder.HasOne(x => x.Airlain)
            .WithMany()
            .HasForeignKey(x => x.AirlineId)
            .IsRequired();

        builder.Property(x => x.Aircraft)
            .HasMaxLength(150)
            .IsRequired(false);

        builder.Property(x => x.DurationInSeconds)
            .IsRequired();

        builder.Property(x => x.DistanceInKm)
            .IsRequired();

        builder.Property(x => x.ClassType)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.Property(x => x.BaggageJson)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.Property(x => x.ArrivalAirportId)
            .IsRequired();

        builder.HasOne(x => x.ArrivalAirport)
            .WithMany()
            .HasForeignKey(x => x.ArrivalAirportId)
            .IsRequired();

        builder.HasOne(x => x.DepatureAirport)
            .WithMany()
            .HasForeignKey(x => x.DepatureAirportId)
            .IsRequired();
    }
}
