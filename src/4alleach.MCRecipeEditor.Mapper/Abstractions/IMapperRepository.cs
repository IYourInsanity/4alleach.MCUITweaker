namespace _4alleach.MCRecipeEditor.Mapper.Abstractions;

public interface IMapperRepository
{
    IDbProvider CreateProvider();

    void Initialize();

    object Map<TSource>(TSource model)
        where TSource : class;

    TDestination Map<TDestination>(object source)
        where TDestination : class;

    IEnumerable<TDestination> Map<TDestination>(IEnumerable<object> source)
        where TDestination : class;

    Type Map<TSource>()
        where TSource : class;
}
