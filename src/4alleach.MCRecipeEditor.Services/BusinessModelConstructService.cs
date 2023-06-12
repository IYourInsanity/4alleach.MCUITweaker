using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Services;

internal sealed class BusinessModelConstructService : IBusinessModelConstructService
{
    private readonly Dictionary<string, Type> types;
    private readonly Dictionary<Type, DefaultBusinessModel> stash;

    private readonly IServiceHub serviceHub;

    public BusinessModelConstructService(IServiceHub serviceHub)
    {
        types = new Dictionary<string, Type>();
        stash = new Dictionary<Type, DefaultBusinessModel>();

        this.serviceHub = serviceHub;
    }

    public void Initialize()
    {
        
    }

    public void Register<TBusinessModel>(string name) 
        where TBusinessModel : DefaultBusinessModel
    {
        types.Add(name, typeof(TBusinessModel));
    }

    public TBusinessModel? GetModel<TBusinessModel>() 
        where TBusinessModel : DefaultBusinessModel
    {
        if (stash.TryGetValue(typeof(TBusinessModel), out var model))
        {
            return model as TBusinessModel;
        }

        return default;
    }

    public void GenerateBusinessModelByName(string name)
    {
        if(types.TryGetValue(name, out var type))
        {
            var model = Activator.CreateInstance(type, serviceHub) as DefaultBusinessModel;

            if(model != null)
            {
                stash.Add(type, model);
            }
        }
    }
}
