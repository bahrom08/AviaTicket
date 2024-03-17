using Domain.Common;

namespace Domain.Enums.Currencies;

public class CurrencyEnum : BaseEnum<CurrencyEnum, Guid>
{
    public static CurrencyEnum USD { get; } =
           new CurrencyEnum(Guid.Parse("d731c30e-6944-4813-aafc-9c2f789da5bb"), "Американский доллар");
    public static CurrencyEnum RUB { get; } =
      new CurrencyEnum(Guid.Parse("53fd9edd-e622-491c-909e-3748b4668764"), "Российский рубль");
    public static CurrencyEnum EUR { get; } =
      new CurrencyEnum(Guid.Parse("4764fd15-1017-43a8-8fef-8f3312f34956"), "Евро");
    public static CurrencyEnum TJS { get; } =
      new CurrencyEnum(Guid.Parse("de762a85-2f06-456b-bfb1-75ca0206e8c7"), "Таджикский сомони");
    public static CurrencyEnum UZS { get; } =
      new CurrencyEnum(Guid.Parse("041e859a-4a7b-4883-b7ee-104d22b2542b"), "Узбекский сум");

    protected CurrencyEnum(Guid val, string name) : base(val, name)
    {
    }

}