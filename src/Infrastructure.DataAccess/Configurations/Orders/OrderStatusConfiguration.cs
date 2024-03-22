using Domain.Entities.Orders;
using Domain.Enums.OrderStatuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations.Orders;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Code)
            .IsRequired();

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.HasData(new List<OrderStatus> 
        {
            new OrderStatus
            {
                Id = OrderStatusEnum.Created.Value,
                Name = OrderStatusEnum.Created.Name,
                Code = nameof(OrderStatusEnum.Created),
                CreatedAt = new DateTime(2024, 03, 14, 0, 0, 0, DateTimeKind.Utc)
            }
        });
    }
}