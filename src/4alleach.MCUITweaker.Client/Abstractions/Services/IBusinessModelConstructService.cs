using _4alleach.MCUITweaker.Client.UIExtension.Abstractions;

namespace _4alleach.MCUITweaker.Client.Abstractions.Services;

internal interface IBusinessModelConstructService : IService
{
    void Register<TBusinessModel>(string name) where TBusinessModel : class, IDefaultBusinessModel;

    TBusinessModel? GetModel<TBusinessModel>(string name) where TBusinessModel : class, IDefaultBusinessModel;

    void GenerateBusinessModelByName(string name);

    void DisposeBusinessModelByName(string name);
}
