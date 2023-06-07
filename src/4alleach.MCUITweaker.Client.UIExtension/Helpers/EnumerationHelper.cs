using _4alleach.MCRecipeEditor.Client.UIExtension.Components;
using System.ComponentModel;
using System.Reflection;
using System.Xml.Serialization;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Helpers;
public static class EnumerationHelper
{
    public static IEnumerable<Tuple<T, string>> GetAllValuesAndDescriptions<T>(Func<T, int>? orderSelector = null, Func<T, bool>? filter = null)
        where T : struct, IConvertible, IComparable, IFormattable
    {
        if (typeof(T).IsEnum == false)
        {
            throw new ArgumentException("T must be an Enumeration type");
        }

        var values = Enum.GetValues(typeof(T)).Cast<T>();
        if (orderSelector != null)
        {
            values = values.OrderBy(orderSelector);
        }

        if (filter != null)
        {
            values = values.Where(filter);
        }

        return values.Select(_ => new Tuple<T, string>(_, ((Enum)(object)_).GetDescription())).ToList();
    }

    public static IEnumerable<T> GetAllValues<T>()
        where T : struct, IConvertible, IComparable, IFormattable
    {
        if (typeof(T).IsEnum == false)
        {
            throw new ArgumentException("T must be an Enumeration type");
        }

        var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        return values;
    }

    public static string GetDescription(this Enum value)
    {
        return GetEnumerationAttribute<DescriptionAttribute, string>(value, attribute => attribute.Description, value.ToString());
    }

    public static int GetId(this Enum value)
    {
        return GetEnumerationAttribute<IdAttribute, int>(value, attribute => attribute.Id, -1);
    }

    public static object? GetValueByAttribute(string attributeName, Type type, bool useAttributeIfValueNotFound = true)
    {
        foreach (var field in type.GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field, typeof(XmlEnumAttribute)) as XmlEnumAttribute;
            if (attribute == null)
            {
                if (field.Name == attributeName)
                {
                    return field.GetValue(null)!;
                }
            }
            else
            {
                if (attribute.Name == attributeName)
                {
                    return field.GetValue(null)!;
                }
            }
        }

        return useAttributeIfValueNotFound
            ? attributeName
            : null;
    }

    private static TAttributeValue GetEnumerationAttribute<TAttribute, TAttributeValue>(Enum value, Func<TAttribute, TAttributeValue> getAttribute, TAttributeValue defaultValue)
        where TAttribute : Attribute
    {
        var stringValue = value.ToString();
        var field = value.GetType().GetField(stringValue);

        var attribute = (field == null)
            ? null
            : GetAttribute<TAttribute>(field);

        return (attribute != null)
            ? getAttribute(attribute)
            : defaultValue;
    }

    private static TAttribute? GetAttribute<TAttribute>(FieldInfo field)
        where TAttribute : Attribute
    {
        return (TAttribute?)field.GetCustomAttributes(typeof(TAttribute), false).FirstOrDefault();
    }

    public static TEnum ToEnum<TEnum>(int value)
    {
        return (TEnum)Enum.Parse(typeof(TEnum), value.ToString());
    }
}
