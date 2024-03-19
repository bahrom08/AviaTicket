using Domain.Common;

namespace Domain.Enums.Genders;

public class GenderEnum : BaseEnum<GenderEnum, string>
{
    public static GenderEnum Male { get; } =
        new("MALE", "Мужчина");

    public static GenderEnum Female { get; } =
        new("FEMALE", "Женщина");

    protected GenderEnum(string val, string name) : base(val, name)
    {
    }
}