namespace _4alleach.MCRecipeEditor.Common.Extensions;

public static class EnumerableExtension
{
    public static IEnumerable<TSource> AsList<TSource>(this IEnumerable<TSource> source)
    {
        return source as List<TSource> ?? source.ToList();
    }
}
