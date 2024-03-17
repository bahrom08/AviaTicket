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
    }
}