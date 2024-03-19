using Domain.Entities.Currencies;
using Domain.Enums.Currencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Currencies;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.IsoCode)
            .HasMaxLength(5)
            .IsRequired();

        builder.Property(x => x.IsoNum)
            .HasMaxLength(5)
            .IsRequired();

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<Currency> builder)
    {
        var currency = new List<Currency>()
        {
            new()
            {
                Id = CurrencyEnum.USD.Value,
                Name = CurrencyEnum.USD.Name,
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IsoCode = nameof(CurrencyEnum.USD),
                IsoNum = "840"
            },
            new()
            {
                Id = CurrencyEnum.EUR.Value,
                Name = CurrencyEnum.EUR.Name,
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IsoCode = nameof(CurrencyEnum.EUR),
                IsoNum = "978"
            },
            new()
            {
                Id = CurrencyEnum.RUB.Value,
                Name = CurrencyEnum.RUB.Name,
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IsoCode = nameof(CurrencyEnum.RUB),
                IsoNum = "643"
            },
            new()
            {
                Id = CurrencyEnum.TJS.Value,
                Name = CurrencyEnum.TJS.Name,
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IsoCode = nameof(CurrencyEnum.TJS),
                IsoNum = "972"
            },
            new()
            {
                Id = CurrencyEnum.UZS.Value,
                Name = CurrencyEnum.UZS.Name,
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IsoCode = nameof(CurrencyEnum.UZS),
                IsoNum = "860"
            }
        };

        builder.HasData(currency);
    }
}