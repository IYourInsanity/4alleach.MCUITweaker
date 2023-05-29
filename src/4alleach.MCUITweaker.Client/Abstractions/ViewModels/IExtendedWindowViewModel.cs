using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.Abstractions.ViewModels;

public interface IExtendedWindowViewModel : IWindowViewModel
{
    void RegisterService<TService, TServiceImplementation>()
        where TService : IService
        where TServiceImplementation : class, IService;

    TService? GetService<TService>() where TService : class, IService;
}
