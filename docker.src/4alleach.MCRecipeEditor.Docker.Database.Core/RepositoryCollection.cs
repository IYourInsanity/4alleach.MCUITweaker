using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Helpers;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Repositories;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core;

public sealed class RepositoryCollection : IRepositoryCollection
{
    private readonly ConcurrentDictionary<Type, Func<IBaseRepository>> _storage;

    public RepositoryCollection()
    {
        _storage = new ConcurrentDictionary<Type, Func<IBaseRepository>>();

        _storage.TryAdd(typeof(Item), ExpressionsHelper.BuildLambdaWithConstructor<ItemRepository>());
        _storage.TryAdd(typeof(ItemPostfix), ExpressionsHelper.BuildLambdaWithConstructor<ItemPostfixRepository>());
        _storage.TryAdd(typeof(ItemPrefix), ExpressionsHelper.BuildLambdaWithConstructor<ItemPrefixRepository>());
        _storage.TryAdd(typeof(ItemType), ExpressionsHelper.BuildLambdaWithConstructor<ItemTypeRepository>());
        _storage.TryAdd(typeof(ModType), ExpressionsHelper.BuildLambdaWithConstructor<ModTypeRepository>());

        _storage.TryAdd(typeof(Account), ExpressionsHelper.BuildLambdaWithConstructor<AccountRepository>());
    }

    public TRepository Build<TRepository, TAsset>(DbContext dbContext) 
        where TRepository : IBaseRepository<TAsset> 
        where TAsset : Asset
    {
        if (_storage.TryGetValue(typeof(TAsset), out var expression) == false)
        {
            throw new NotImplementedException();
        }

        var repository = expression();

        if (repository is TRepository mappedRepository)
        {
            return mappedRepository.Build<TRepository>(dbContext);
        }

        throw new NotImplementedException();
    }
}
