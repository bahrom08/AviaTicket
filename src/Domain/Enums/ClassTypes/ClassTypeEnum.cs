using Domain.Common;

namespace Domain.Enums.ClassTypes;

public class ClassTypeEnum : BaseEnum<ClassTypeEnum, string>
{
    public static ClassTypeEnum Economy { get; } =
        new ClassTypeEnum("ECONOMY", "Эконом класс");

    public static ClassTypeEnum First { get; } =
        new ClassTypeEnum("FIRST", "Первый класс");

    public static ClassTypeEnum Business { get; } =
        new ClassTypeEnum("BUSINESS", "Бизнес класс");

    public static ClassTypeEnum PremiumEconomy { get; } =
        new ClassTypeEnum("PREMIUM_ECONOMY", "Премиум-эконом класс");

    protected ClassTypeEnum(string val, string name) : base(val, name)
    {
    }
}
