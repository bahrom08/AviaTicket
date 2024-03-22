using Domain.Entities.Airports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Airports;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.IATACode)
            .HasMaxLength(5)
            .IsRequired();

        builder.HasOne(x => x.City)
            .WithMany()
            .HasForeignKey(x => x.CityId)
            .IsRequired();

        builder.HasData(new List<Airport>
        {
            new Airport
            {
                Id = Guid.Parse("ee1d374f-f06d-4753-baf3-8ed52881714e"),
                Name = "Международный аэропорт Худжанд",
                CityId = Guid.Parse("ee1d374f-f06d-4753-baf3-8ed52881714e"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "LBD",
            },
            new Airport
            {
                Id = Guid.Parse("09f7eea6-ca7c-4bd9-842c-0916d0df8042"),
                Name = "Международный аэропорт  Душанбе",
                CityId = Guid.Parse("09f7eea6-ca7c-4bd9-842c-0916d0df8042"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "DYU"
            },
            new Airport
            {
                Id = Guid.Parse("0f41b6ff-bdda-42c7-883e-012d82c37791"),
                Name = "Домодедово",
                CityId = Guid.Parse("0f41b6ff-bdda-42c7-883e-012d82c37791"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "DME"
            },
            new Airport
            {
                Id = Guid.Parse("1c83a698-c96c-4bbd-9b05-1b1f2abcce82"),
                Name = "Аэропорт Пулково",
                CityId = Guid.Parse("1c83a698-c96c-4bbd-9b05-1b1f2abcce82"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "LED"
            },
            new Airport
            {
                Id = Guid.Parse("ff84a563-0807-453e-a1c2-2c87401726f8"),
                Name = "Лос-Анджелес",
                CityId = Guid.Parse("ff84a563-0807-453e-a1c2-2c87401726f8"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "LAX"
            },
            new Airport
            {
                Id = Guid.Parse("8857dc1f-a51c-489e-9586-19db5372c711"),
                Name = "Нью-Йорк",
                CityId = Guid.Parse("8857dc1f-a51c-489e-9586-19db5372c711"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "NYC"
            },
            new Airport
            {
                Id = Guid.Parse("bac8b8e0-b639-4a3b-a063-5f874315e49d"),
                Name = "Абу-Даби",
                CityId = Guid.Parse("bac8b8e0-b639-4a3b-a063-5f874315e49d"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "AUH"
            },
            new Airport
            {
                Id = Guid.Parse("42072f36-e9a0-4184-a189-ace3e0036efa"),
                Name = "Дубай",
                CityId = Guid.Parse("42072f36-e9a0-4184-a189-ace3e0036efa"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "DXB"
            },
            new Airport
            {
                Id = Guid.Parse("f737ab45-3dee-4024-8e40-639d3680fc14"),
                Name = "Ташкент",
                CityId = Guid.Parse("f737ab45-3dee-4024-8e40-639d3680fc14"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "TAS"
            },
            new Airport
            {
                Id = Guid.Parse("a7f55e3b-4dd1-4903-80d9-40ce44007734"),
                Name = "Андижан",
                CityId = Guid.Parse("a7f55e3b-4dd1-4903-80d9-40ce44007734"),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc),
                IATACode = "AZN"
            }
        });
    }
}