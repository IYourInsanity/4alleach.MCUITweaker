using _4alleach.MCRecipeEditor.Client.UIExtension.Helpers;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Extensions;

public static class EnumExtension
{
    public static T ToEnum<T>(this string value)
    {
        return (T)Enum.Parse(typeof(T), value);
    }

    public static T TryToEnum<T>(this string value, bool ignoreCase = false) where T : struct
    {
        T result = default(T);

        Enum.TryParse(value, ignoreCase, out result);

        return result;
    }

    public static TOutput TryToEnum<TOutput, TInput>(this TInput value, bool ignoreCase = false) where TOutput : struct
    {
        TOutput result = default;

        Enum.TryParse(value?.ToString(), ignoreCase, out result);

        return result;
    }

    public static TOutput GetEquivalent<TOutput, TInput>(this TInput value, bool ignoreCase = false)
        where TOutput : struct
        where TInput : struct
    {
        var inputIntValue = value as int?;

        if (inputIntValue.HasValue)
        {
            return (TOutput)Convert.ChangeType(inputIntValue, typeof(TOutput));
        }

        return default;
    }

    public static IEnumerable<Tuple<T, string>> GetAllValuesAndDescriptionsWithCustomNames<T>(List<string> newNameList)
        where T : struct, IConvertible, IComparable, IFormattable
    {
        var currentTable = EnumerationHelper.GetAllValuesAndDescriptions<T>();
        var index = 0;

        return currentTable.Select(val => new Tuple<T, string>(val.Item1, newNameList[index++])).ToList();
    }
}
