using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Orders;

public class OrderPassengerConfiguration : IEntityTypeConfiguration<OrderPassenger>
{
    public void Configure(EntityTypeBuilder<OrderPassenger> builder)
    {
        builder.Property(x => x.OrderId)
            .IsRequired();

        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderPassengers)
            .HasForeignKey(x => x.OrderId)
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.DateOfBirth)
            .IsRequired();
        
        builder.Property(x => x.Gender)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.Property(x => x.CitizenshipId)
            .IsRequired();

        builder.HasOne(x => x.Citizenship)
            .WithMany()
            .HasForeignKey(x => x.CitizenshipId)
            .IsRequired();

        builder.Property(x => x.DocumentType)
            .HasColumnType("jsonb")
            .IsRequired();

        builder.Property(x => x.DocumentNumber)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.DocumentNumber)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.IssueAt)
            .IsRequired(false);

        builder.Property(x => x.ExpiredAt)
            .IsRequired(false);
    }
}
