using _4alleach.MCRecipeEditor.Database;
using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Mapper;
using _4alleach.MCRecipeEditor.Mapper.Abstractions;
using _4alleach.MCRecipeEditor.Models.Abstractions.Database;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Services;
internal sealed class DatabaseControllerService : IDatabaseControllerService
{
    private readonly IServiceHub serviceHub;

    private IDatabaseContext? context;

    private IMapperRepository? mapper;

    public DatabaseControllerService(IServiceHub serviceHub)
    {
        this.serviceHub = serviceHub;
    }

    public void Initialize()
    {
        context = Entry.CreateContext();
        context.Initialize();

        mapper = new MapperRepository(context);
    }

    public Task<bool> TestConnection()
    {
        if (context == null)
        {
            return Task.FromResult(false);
        }

        return context.TestConnection();
    }

    public Task<int> Delete<TModel>(TModel model, CancellationToken token) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Delete(model, token);
    }

    public Task<int> Delete<TModel>(IEnumerable<TModel> models, CancellationToken token) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Delete(models, token);
    }

    public Task<int> Insert<TModel>(TModel model, CancellationToken token) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Insert(model, token);
    }

    public Task<int> Insert<TModel>(IEnumerable<TModel> models, CancellationToken token) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Insert(models, token);
    }

    public Task<IEnumerable<TModel>?> SelectAll<TModel>(CancellationToken token) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.SelectAll<TModel>(token);
    }

    public Task<IEnumerable<TModel>?> SelectCustom<TModel>(string script, CancellationToken token) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.SelectCustom<TModel>(script, token);
    }

    public Task<IEnumerable<TModel>?> SelectTop<TModel>(int count, CancellationToken token) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.SelectTop<TModel>(count, token);
    }

    public Task<int> Update<TModel>(TModel model, CancellationToken token) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Update(model, token);
    }

    public Task<int> Update<TModel>(IEnumerable<TModel> models, CancellationToken token) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Update(models, token);
    }
}
