using _4alleach.MCUITweaker.Client.Abstractions.Services;
using _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;

namespace _4alleach.MCUITweaker.Client.Abstractions.ViewModels;

internal interface IExtendedWindowViewModel : IWindowViewModel
{
    void RegisterService<TService, TServiceImplementation>()
        where TService : IService
        where TServiceImplementation : class, IService;

    TService? GetService<TService>() where TService : class, IService;
}
