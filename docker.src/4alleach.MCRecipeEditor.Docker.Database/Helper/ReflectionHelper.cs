namespace _4alleach.MCRecipeEditor.Docker.Database.Helper;

internal static class ReflectionHelper
{
    internal static IEnumerable<Type> GetAssignableFromType<T>(bool includeAbstract = false)
    {
        var type = typeof(T);

        return type.Assembly.ExportedTypes.Where(source =>
        {
            var isDesired = type.IsAssignableFrom(source) && source.IsClass;

            switch (isDesired)
            {
                case true when source.IsAbstract && includeAbstract:
                case true when source.IsAbstract == false:
                    return true;
                default:
                    return false;
            }
        });
    }
}
