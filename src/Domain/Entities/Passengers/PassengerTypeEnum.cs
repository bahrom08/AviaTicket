using Domain.Common;

namespace Domain.Entities.Passengers;

public class PassengerTypeEnum : BaseEnum<PassengerTypeEnum, string>
{
    public static PassengerTypeEnum Adult { get; } =
        new("ADULT", "Взрослый");

    public static PassengerTypeEnum Child { get; } =
        new("CHILD", "Ребенок");

    public static PassengerTypeEnum Infant { get; } =
        new("INFANT", "Младенец");

    protected PassengerTypeEnum(string val, string name) : base(val, name)
    {
    }
}