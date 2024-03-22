using Domain.Common;

namespace Domain.Enums.GatewayProvider;

public class GatewayProviderEnum : BaseEnum<GatewayProviderEnum, Guid>
{
    public static GatewayProviderEnum Kiwi { get; } =
            new(Guid.Parse("ab6d8fbb-2fab-4c01-9832-9580f0c1c7d6"), "Kiwi");
    
    public static GatewayProviderEnum GoogleFlights { get; } =
            new(Guid.Parse("9aba164b-080e-4eee-8319-048bb1db3cf6"), "GoogleFlights");

    protected GatewayProviderEnum(Guid val, string name) : base(val, name)
    {
    }

}
