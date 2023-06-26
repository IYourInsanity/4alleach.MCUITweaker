using _4alleach.MCRecipeEditor.Mapper.Abstractions;

namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public interface IAutoMapperService : IService
{
    IDbProvider CreateProvider();

    object Map<TSource>(TSource model)
        where TSource : class;
}
