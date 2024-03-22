using Domain.Entities.Regions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Regions;

public class CounrtyConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(x => x.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<Country> builder)
    {
        builder.HasData(new List<Country>
        {
            new Country
            {
                Id = Guid.Parse("ae32ad92-286d-41e6-8ea7-436c69c91025"),
                Name = "Таджикистан",
                Code = "TJ",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
            },
            new Country
            {
                Id = Guid.Parse("0541a1ab-fae2-4ffc-a361-1b5c84ca56bf"),
                Name = "Россия",
                Code = "RU",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
            },
            new Country
            {
                Id = Guid.Parse("4083740c-d960-4950-83cf-65e4f89e4875"),
                Name = "США",
                Code = "US",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
            },
            new Country
            {
                Id = Guid.Parse("635bf746-fb46-42e7-b98e-d11c8596c798"),
                Name = "ОАЭ",
                Code = "AE",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
            },
            new Country
            {
                Id = Guid.Parse("675fa316-9670-435b-800f-fd4e076e76ae"),
                Name = "Узбекистан",
                Code = "UZ",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
            },
        });
    }
}
