namespace _4alleach.MCRecipeEditor.Database.Mapper.Abstractions;

public interface IMapperRepository
{
    object Map<TSource>(TSource model)
        where TSource : class;

    TDestination Map<TDestination>(object source)
        where TDestination : class;

    IEnumerable<TDestination> Map<TDestination>(IEnumerable<object> source)
        where TDestination : class;

    Type Map<TSource>()
        where TSource : class;
}
