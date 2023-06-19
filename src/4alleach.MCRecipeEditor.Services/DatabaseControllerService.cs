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

    public Task<int> Delete<TModel>(TModel model) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Delete<TModel>(model);
    }

    public Task<int> Delete<TModel>(IEnumerable<TModel> models) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Delete<TModel>(models);
    }

    public Task<int> Insert<TModel>(TModel model) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Insert<TModel>(model);
    }

    public Task<int> Insert<TModel>(IEnumerable<TModel> models) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Insert<TModel>(models);
    }

    public Task<IEnumerable<TModel>?> SelectAll<TModel>() 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.SelectAll<TModel>();
    }

    public Task<IEnumerable<TModel>?> SelectCustom<TModel>(string script) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.SelectCustom<TModel>(script);
    }

    public Task<IEnumerable<TModel>?> SelectTop<TModel>(int count) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.SelectTop<TModel>(count);
    }

    public Task<int> Update<TModel>(TModel model) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Update<TModel>(model);
    }

    public Task<int> Update<TModel>(IEnumerable<TModel> models) 
        where TModel : Asset
    {
        return mapper!.GetMapper<TModel>()!.Update<TModel>(models);
    }
}
