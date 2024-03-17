using System.Reflection;

namespace Domain.Common;

public class BaseEnum<TEnum, TValue> where TEnum : BaseEnum<TEnum, TValue>
{
    private static readonly List<TEnum> _list = new List<TEnum>();
    public string Name { get; }
    public TValue Value { get; }

    protected BaseEnum(TValue val, string name)
    {
        Value = val;
        Name = name;

        var item = this as TEnum;
        List.Add(item);
    }

    public static TEnum FromName(string name)
    {
        return List.Single(item => string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    public static TEnum FromPropName(string name)
    {
        return Dictionary.Where(x => string.Equals(x.Key, name, StringComparison.OrdinalIgnoreCase)).Single().Value;
    }

    public static TEnum FromValue(TValue value)
    {
        return List.Single(item => EqualityComparer<TValue>.Default.Equals(item.Value, value));
    }

    public override string ToString() => $"{Name} ({Value})";

    private static bool _invoked;

    public static List<TEnum> List
    {
        get
        {
            if (!_invoked)
            {
                _invoked = true;

                typeof(TEnum).GetProperties(BindingFlags.Public | BindingFlags.Static).FirstOrDefault(p => p.PropertyType == typeof(TEnum))?.GetValue(null, null);
            }

            return _list;
        }
    }

    public static IDictionary<string, TEnum> Dictionary
    {
        get
        {
            var propertyInfos = typeof(TEnum).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(TEnum))
                .ToList();

            return propertyInfos.
                ToDictionary(propertyInfo => propertyInfo.Name, propertyInfo => propertyInfo.GetValue(null, null) as TEnum);
        }
    }
}