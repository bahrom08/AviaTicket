using Domain.Entities.Regions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Regions;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.IATACode)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.CountryId)
            .IsRequired();

        builder.HasOne(x => x.Country)
            .WithMany()
            .HasForeignKey(x => x.CountryId)
            .IsRequired();

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<City> builder)
    {
        builder.HasData(new List<City>()
        {
            new City
            {
                Id = Guid.Parse("ee1d374f-f06d-4753-baf3-8ed52881714e"),
                Name = "Худжанд",
                CountryId = Guid.Parse("ae32ad92-286d-41e6-8ea7-436c69c91025"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "LBD"
            },
            new City
            {
                Id = Guid.Parse("09f7eea6-ca7c-4bd9-842c-0916d0df8042"),
                Name = "Душанбе",
                CountryId = Guid.Parse("ae32ad92-286d-41e6-8ea7-436c69c91025"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "DYU"
            },
            new City
            {
                Id = Guid.Parse("0f41b6ff-bdda-42c7-883e-012d82c37791"),
                Name = "Москва",
                CountryId = Guid.Parse("0541a1ab-fae2-4ffc-a361-1b5c84ca56bf"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "MOW"
            },
            new City
            {
                Id = Guid.Parse("1c83a698-c96c-4bbd-9b05-1b1f2abcce82"),
                Name = "Санкт-Петербург",
                CountryId = Guid.Parse("0541a1ab-fae2-4ffc-a361-1b5c84ca56bf"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "LED"
            },
            new City
            {
                Id = Guid.Parse("ff84a563-0807-453e-a1c2-2c87401726f8"),
                Name = "Лос-Анджелес",
                CountryId = Guid.Parse("4083740c-d960-4950-83cf-65e4f89e4875"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "LAX"
            },
            new City
            {
                Id = Guid.Parse("8857dc1f-a51c-489e-9586-19db5372c711"),
                Name = "Нью-Йорк",
                CountryId = Guid.Parse("4083740c-d960-4950-83cf-65e4f89e4875"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "NYC"
            },
            new City
            {
                Id = Guid.Parse("bac8b8e0-b639-4a3b-a063-5f874315e49d"),
                Name = "Абу-Даби",
                CountryId = Guid.Parse("635bf746-fb46-42e7-b98e-d11c8596c798"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "AUH"
            },
            new City
            {
                Id = Guid.Parse("42072f36-e9a0-4184-a189-ace3e0036efa"),
                Name = "Дубай",
                CountryId = Guid.Parse("635bf746-fb46-42e7-b98e-d11c8596c798"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "DXB"
            },
            new City
            {
                Id = Guid.Parse("f737ab45-3dee-4024-8e40-639d3680fc14"),
                Name = "Ташкент",
                CountryId = Guid.Parse("675fa316-9670-435b-800f-fd4e076e76ae"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "TAS"
            },
            new City
            {
                Id = Guid.Parse("a7f55e3b-4dd1-4903-80d9-40ce44007734"),
                Name = "Андижан",
                CountryId = Guid.Parse("675fa316-9670-435b-800f-fd4e076e76ae"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "AZN"
            }
        });
    }
}