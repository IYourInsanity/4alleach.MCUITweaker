using _4alleach.MCRecipeEditor.Database.Mapper.Abstractions;
using AutoMapper;
using System.Collections.Concurrent;

using ModelAsset = _4alleach.MCRecipeEditor.Database.Entities;
using EntityAsset = _4alleach.MCRecipeEditor.Models.Database;

namespace _4alleach.MCRecipeEditor.Database.Mapper;

public sealed class MapperRepository : IMapperRepository
{
    private readonly static ConcurrentDictionary<Type, Type> Types;

    private readonly static MapperConfiguration Configuration;

    private readonly IMapper mapper;

    static MapperRepository()
    {
        Types = new ConcurrentDictionary<Type, Type>();

        Types.TryAdd(typeof(EntityAsset.Item), typeof(ModelAsset.Item));
        Types.TryAdd(typeof(EntityAsset.ItemType), typeof(ModelAsset.ItemType));
        Types.TryAdd(typeof(EntityAsset.ItemPostfix), typeof(ModelAsset.ItemPostfix));
        Types.TryAdd(typeof(EntityAsset.ItemPrefix), typeof(ModelAsset.ItemPrefix));
        Types.TryAdd(typeof(EntityAsset.ModType), typeof(ModelAsset.ModType));

        Types.TryAdd(typeof(ModelAsset.Item), typeof(EntityAsset.Item));
        Types.TryAdd(typeof(ModelAsset.ItemType), typeof(EntityAsset.ItemType));
        Types.TryAdd(typeof(ModelAsset.ItemPostfix), typeof(EntityAsset.ItemPostfix));
        Types.TryAdd(typeof(ModelAsset.ItemPrefix), typeof(EntityAsset.ItemPrefix));
        Types.TryAdd(typeof(ModelAsset.ModType), typeof(EntityAsset.ModType));

        Configuration = new MapperConfiguration(cfg =>
        {
            foreach (var type in Types)
            {
                cfg.CreateMap(type.Key, type.Value);
            }
        });
    }

    public MapperRepository()
    {
        mapper = Configuration.CreateMapper();
    }

    public object Map<TSource>(TSource model)
        where TSource : class
    {
        var sourceType = typeof(TSource);

        if (Types.TryGetValue(sourceType, out var destinationType))
        {
            return mapper!.Map(model, sourceType, destinationType);
        }

        throw new NotImplementedException();
    }

    public Type Map<TSource>()
        where TSource : class
    {
        if (Types.TryGetValue(typeof(TSource), out var destinationType))
        {
            return destinationType;
        }

        throw new NotImplementedException();
    }

    public TDestination Map<TDestination>(object source)
        where TDestination : class
    {
        return mapper!.Map<TDestination>(source);
    }

    public IEnumerable<TDestination> Map<TDestination>(IEnumerable<object> source)
        where TDestination : class
    {
        return source.Select(_ => mapper!.Map<TDestination>(_));
    }
}
