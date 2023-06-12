namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public interface IBusinessModelConstructService : IService
{
    void Register<TBusinessModel>(string name)
        where TBusinessModel : DefaultBusinessModel;

    TBusinessModel? GetModel<TBusinessModel>()
        where TBusinessModel : DefaultBusinessModel;

    void GenerateBusinessModelByName(string name);
}
