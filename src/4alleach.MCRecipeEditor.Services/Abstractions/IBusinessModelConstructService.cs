namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public interface IBusinessModelConstructService : IService
{
    void Register<TBusinessModel>(string name)
        where TBusinessModel : BaseBusinessModel;

    TBusinessModel? GetModel<TBusinessModel>()
        where TBusinessModel : BaseBusinessModel;

    void GenerateBusinessModelByName(string name);
}
