namespace _4alleach.MCRecipeEditor.Common.Extensions;

public static class StringExtension
{
    public static string Format(this string source, params object[] args)
    {
        return string.Format(source, args);
    }
}
