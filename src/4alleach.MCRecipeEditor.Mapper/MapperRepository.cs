using _4alleach.MCRecipeEditor.Mapper.Abstractions;
using AutoMapper;
using System.Collections.Concurrent;
using ModelAsset = _4alleach.MCRecipeEditor.Database.Entities;
using EntityAsset = _4alleach.MCRecipeEditor.Models.Database;

namespace _4alleach.MCRecipeEditor.Mapper;
public sealed class MapperRepository : IMapperRepository
{
    private ConcurrentDictionary<Type, Type> types;

    private MapperConfiguration? configuration;

    private AutoMapper.IMapper? mapper;

    public MapperRepository()
    {
        types = new ConcurrentDictionary<Type, Type>();
    }

    public void Initialize()
    {
        types.TryAdd(typeof(EntityAsset.Item), typeof(ModelAsset.Item));
        types.TryAdd(typeof(EntityAsset.ItemType), typeof(ModelAsset.ItemType));
        types.TryAdd(typeof(EntityAsset.ItemPostfix), typeof(ModelAsset.ItemPostfix));
        types.TryAdd(typeof(EntityAsset.ItemPrefix), typeof(ModelAsset.ItemPrefix));
        types.TryAdd(typeof(EntityAsset.ModType), typeof(ModelAsset.ModType));

        types.TryAdd(typeof(ModelAsset.Item), typeof(EntityAsset.Item));
        types.TryAdd(typeof(ModelAsset.ItemType), typeof(EntityAsset.ItemType));
        types.TryAdd(typeof(ModelAsset.ItemPostfix), typeof(EntityAsset.ItemPostfix));
        types.TryAdd(typeof(ModelAsset.ItemPrefix), typeof(EntityAsset.ItemPrefix));
        types.TryAdd(typeof(ModelAsset.ModType), typeof(EntityAsset.ModType));

        configuration = new MapperConfiguration(cfg =>
        {
            foreach (var type in types)
            {
                cfg.CreateMap(type.Key, type.Value);
            }
        });

        mapper = configuration.CreateMapper();
    }

    public IDbProvider CreateProvider()
    {
        return new DbProvider(this);
    }

    public object Map<TSource>(TSource model)
        where TSource : class
    {
        var sourceType = typeof(TSource);

        if(types.TryGetValue(sourceType, out var destinationType))
        {
            return mapper!.Map(model, sourceType, destinationType);
        }

        throw new NotImplementedException();
    }

    public Type Map<TSource>() 
        where TSource : class
    {
        if (types.TryGetValue(typeof(TSource), out var destinationType))
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
        return source.Select(_ => mapper!.Map<TDestination>(_)).ToList();
    }
}
