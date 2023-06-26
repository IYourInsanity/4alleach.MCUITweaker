using _4alleach.MCRecipeEditor.Mapper;
using _4alleach.MCRecipeEditor.Mapper.Abstractions;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Services;

internal sealed class AutoMapperService : IAutoMapperService
{
    private readonly IMapperRepository repository;

    private readonly IServiceHub serviceHub;

    public AutoMapperService(IServiceHub serviceHub) 
    { 
        this.serviceHub = serviceHub;
        repository = new MapperRepository();
    }

    public IDbProvider CreateProvider()
    {
        return repository.CreateProvider();
    }

    public void Initialize()
    {
        repository.Initialize();
    }

    public object Map<TSource>(TSource model)
        where TSource : class
    {
        return repository.Map(model);
    }
}
