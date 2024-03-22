using Domain.Entities.Airlains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Airplains;

public class AirplainConfiguration : IEntityTypeConfiguration<Airlain>
{
    public void Configure(EntityTypeBuilder<Airlain> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.IATACode)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.ModifiedAt)
            .IsRequired(false);

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<Airlain> builder)
    {
        builder.HasData(new List<Airlain>
        {
            new Airlain
            {
                Id = Guid.Parse("42072f36-e9a0-4184-a189-ace3e0036efa"),
                Name = "Somon Air",
                IATACode = "SZ",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc)
            },
            new Airlain
            {
                Id = Guid.Parse("66ee2396-d593-4ad9-b6a2-435d82ce5b38"),
                Name = "United Airlines",
                IATACode = "UA",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc)
            },
            new Airlain
            {
                Id = Guid.Parse("ea608b7c-5982-4267-a276-69d257829d07"),
                Name = "Уральские авиалинии",
                IATACode = "U6",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc)
            },
            new Airlain
            {
                Id = Guid.Parse("799c5589-e720-4009-a4f8-88d507700d8f"),
                Name = "Emirates",
                IATACode = "EK",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc)
            },
            new Airlain
            {
                Id = Guid.Parse("98967639-2634-4924-b1be-4de33b90c02f"),
                Name = "Qanot Sharq",
                IATACode = "HH",
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc)
            },
        });
    }
}