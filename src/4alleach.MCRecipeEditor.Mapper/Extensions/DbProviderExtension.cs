using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Mapper.Abstractions;

namespace _4alleach.MCRecipeEditor.Mapper.Extensions;
public static class DbProviderExtension
{

    public static IDbProvider Map<TSource>(this IDbProvider provider, TSource source)
        where TSource : class
    {
        if(provider is DbProvider dbProvider)
        {
            dbProvider.Destination = dbProvider.mapper.Map(source);
        }

        return provider;
    }

    public static TDestination Map<TDestination>(this IDbProvider provider, object source)
        where TDestination : class
    {
        if (provider is DbProvider dbProvider)
        {
            return dbProvider.mapper.Map<TDestination>(source);
        }

        throw new NotImplementedException();
    }

    public static IEnumerable<TDestination> Map<TDestination>(this IDbProvider provider, IEnumerable<object> source)
        where TDestination : class
    {
        if (provider is DbProvider dbProvider)
        {
            return dbProvider.mapper.Map<TDestination>(source);
        }

        throw new NotImplementedException();
    }

    public static void UseContext(this IDbProvider provider, Action<IDbContext> action)
    {
        if (provider is DbProvider dbProvider)
        {
            action(dbProvider.dbContext);
        }
    }

    public static void UseHandler<TSource>(this IDbProvider provider, Action<IBaseQueryHandler> action)
        where TSource : class
    {
        if (provider is DbProvider dbProvider)
        {
            var type = dbProvider.mapper.Map<TSource>();
            var queryHandler = dbProvider.dbContext.CreateHandler(type);

            action(queryHandler);
        }
    }

    public static void UseContext(this IDbProvider provider, Action<IDbContext, Type, object> action)
    {
        if (provider is DbProvider dbProvider)
        {
            action(dbProvider.dbContext, dbProvider.Destination!.GetType(), dbProvider.Destination!);
        }
    }
}
