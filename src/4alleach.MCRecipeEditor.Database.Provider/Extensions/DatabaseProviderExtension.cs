using _4alleach.MCRecipeEditor.Database.Provider.Abstractions;
using _4alleach.MCRecipeEditor.Database.Provider.Abstractions.Wrappers;
using _4alleach.MCRecipeEditor.Database.Provider.Wrappers;

namespace _4alleach.MCRecipeEditor.Database.Provider.Extensions;

public static class DatabaseProviderExtension
{
    public static object Map<TSource>(this IDatabaseProvider provider, TSource source)
        where TSource : class
    {
        if (provider is DatabaseProvider dbProvider)
        {
            return dbProvider.mapper.Map(source);
        }

        throw new NotImplementedException();
    }

    public static TDestination Map<TDestination>(this IDatabaseProvider provider, object source)
        where TDestination : class
    {
        if (provider is DatabaseProvider dbProvider)
        {
            return dbProvider.mapper.Map<TDestination>(source);
        }

        throw new NotImplementedException();
    }

    public static IEnumerable<TDestination> Map<TDestination>(this IDatabaseProvider provider, IEnumerable<object> source)
        where TDestination : class
    {
        if (provider is DatabaseProvider dbProvider)
        {
            return dbProvider.mapper.Map<TDestination>(source);
        }

        throw new NotImplementedException();
    }

    public static void UseHandler<TSource>(this IDatabaseProvider provider, Action<IWrapperQueryHandler<TSource>> action)
        where TSource : class
    {
        if (provider is DatabaseProvider dbProvider)
        {
            var type = dbProvider.mapper.Map<TSource>();
            var queryHandler = dbProvider.context.CreateHandler(type);
            var wrapperQueryHandler = new WrapperQueryHandler<TSource>(provider, queryHandler);

            action(wrapperQueryHandler);
        }
    }

    public static Task UseHandlerAsync<TSource>(this IDatabaseProvider provider, Action<IWrapperQueryHandler<TSource>, CancellationToken> action, CancellationToken token)
        where TSource : class
    {
        if (provider is DatabaseProvider dbProvider)
        {
            var type = dbProvider.mapper.Map<TSource>();
            var queryHandler = dbProvider.context.CreateHandler(type);
            var wrapperQueryHandler = new WrapperQueryHandler<TSource>(provider, queryHandler);

            return Task.Run(() => action(wrapperQueryHandler, token), token);
        }

        return Task.CompletedTask;
    }
}
