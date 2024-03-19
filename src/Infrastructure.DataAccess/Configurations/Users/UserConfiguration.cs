using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasIndex(x => x.PhoneNumber)
            .IsUnique();

        builder.Property(x => x.LastLoginAt)
            .IsRequired(false);

        builder.Property(x => x.CitizenshipId)
            .IsRequired(false);

        builder.HasOne(x => x.Citizenship)
            .WithMany()
            .HasForeignKey(x => x.CitizenshipId)
            .IsRequired(false);

        builder.Property(x => x.CityResidenceId)
            .IsRequired(false);

        builder.HasOne(x => x.CityResidence)
            .WithMany()
            .HasForeignKey(x => x.CityResidenceId)
            .IsRequired(false);

        builder.Property(x => x.Gender)
            .IsRequired();

        builder.Property(x => x.DateOfBirth)
            .IsRequired(false);

        builder.Property(x => x.CurrencyId)
            .IsRequired(false);

        builder.HasOne(x => x.Currency)
            .WithMany()
            .HasForeignKey(x => x.CurrencyId)
            .IsRequired(false);

    }
}
