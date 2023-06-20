using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Database.Mappers;
using _4alleach.MCRecipeEditor.Mapper.Abstractions;
using _4alleach.MCRecipeEditor.Models.Database;
using System.Collections.Concurrent;

namespace _4alleach.MCRecipeEditor.Mapper;
public sealed class MapperRepository : IMapperRepository
{

    //TODO Think about SortedList
    private readonly ConcurrentDictionary<Type, IModelEntityMapper> storage;

    public MapperRepository(IDatabaseContext context)
    {
        storage = new ConcurrentDictionary<Type, IModelEntityMapper>();

        storage.TryAdd(typeof(ModType), new ModelEntityMapper<ModType, Database.Entities.ModType>(context));
        storage.TryAdd(typeof(Item), new ModelEntityMapper<Item, Database.Entities.Item>(context));
        storage.TryAdd(typeof(ItemPostfix), new ModelEntityMapper<ItemPostfix, Database.Entities.ItemPostfix>(context));
        storage.TryAdd(typeof(ItemPrefix), new ModelEntityMapper<ItemPrefix, Database.Entities.ItemPrefix>(context));
        storage.TryAdd(typeof(ItemType), new ModelEntityMapper<ItemType, Database.Entities.ItemType>(context));
    }

    public IModelEntityMapper GetMapper<TModel>()
    {
        return storage[typeof(TModel)];
    }
}
