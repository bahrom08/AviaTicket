using Domain.Common;

namespace Domain.Enums.DocumentTypes;

public class PassengerDocumentTypeEnum : BaseEnum<PassengerDocumentTypeEnum, string>
{
    public static PassengerDocumentTypeEnum Passport { get; } =
        new("PS", "Паспорт");

    public static PassengerDocumentTypeEnum InternationalPassport { get; } =
        new("IPS", "Загранпаспорт");

    protected PassengerDocumentTypeEnum(string val, string name) : base(val, name)
    {
    }
}