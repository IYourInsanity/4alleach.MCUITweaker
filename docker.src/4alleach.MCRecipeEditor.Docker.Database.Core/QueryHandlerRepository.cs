using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core;

public sealed class QueryHandlerRepository : IQueryHandlerRepository
{
    private readonly ConcurrentDictionary<Type, Func<IQueryHandler>> storage;

    public QueryHandlerRepository()
    {
        storage = new ConcurrentDictionary<Type, Func<IQueryHandler>>();

        storage.TryAdd(typeof(Item), ExpressionsHelper.BuildLambdaWithConstructor<QueryHandler<Item>>());
        storage.TryAdd(typeof(ItemPostfix), ExpressionsHelper.BuildLambdaWithConstructor<QueryHandler<ItemPostfix>>());
        storage.TryAdd(typeof(ItemPrefix), ExpressionsHelper.BuildLambdaWithConstructor<QueryHandler<ItemPrefix>>());
        storage.TryAdd(typeof(ItemType), ExpressionsHelper.BuildLambdaWithConstructor<QueryHandler<ItemType>>());
        storage.TryAdd(typeof(ModType), ExpressionsHelper.BuildLambdaWithConstructor<QueryHandler<ModType>>());
    }

    public IQueryHandler<TAsset> Build<TAsset>(DbContext dbContext)
        where TAsset : Asset
    {
        if (storage.TryGetValue(typeof(TAsset), out var expression))
        {
            return expression().Build<IQueryHandler<TAsset>>(dbContext);
        }

        throw new NotImplementedException();
    }
}
