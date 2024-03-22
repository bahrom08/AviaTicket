using Domain.Common;

namespace Domain.Enums.OrderStatuses;

public class OrderStatusEnum : BaseEnum<OrderStatusEnum, Guid>
{
    public static OrderStatusEnum Created { get; } =
        new OrderStatusEnum(Guid.Parse("105abf8d-2f8b-4bc9-9f89-640acd6cce1c"), "Создан");

    public static OrderStatusEnum Completed { get; } =
        new OrderStatusEnum(Guid.Parse("39bd5721-0cd5-4ed5-b2b0-f4a0022d4f38"), "Завершен");

    public static OrderStatusEnum Canceled { get; } =
        new OrderStatusEnum(Guid.Parse("97fc365f-fdc7-4b33-8fd6-a7a607d5a521"), "Отменен");

    protected OrderStatusEnum(Guid val, string name) : base(val, name)
    {
    }
}
