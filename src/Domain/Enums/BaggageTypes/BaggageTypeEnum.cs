using Domain.Common;

namespace Domain.Enums.BaggageTypes;

public class BaggageTypeEnum : BaseEnum<BaggageTypeEnum, string>
{

    public static BaggageTypeEnum CarryOn { get; } =
        new BaggageTypeEnum("CARRAY_ON", "Ручная кладь");

    public static BaggageTypeEnum Checked { get; } =
        new BaggageTypeEnum("CHECKED", "Регистрируемый багаж");

    protected BaggageTypeEnum(string val, string name) : base(val, name)
    {
    }
}
