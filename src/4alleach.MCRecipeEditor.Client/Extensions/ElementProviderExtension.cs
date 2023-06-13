using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using _4alleach.MCRecipeEditor.Client.ViewModels.Windows;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.Extensions;
internal static class ElementProviderExtension
{
    internal static TService? GetService<TService>(this IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider)
        where TService : class, IService
    {
        return provider?.GetViewModel<MainWindowViewModel>()?.GetService<TService>();
    }

    internal static TModalResult? ShowModal<TModalElement, TModalResult>(this IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider, params object[]? args)
        where TModalElement : ExtendedModalWindow, new()
        where TModalResult : class
    {
        if(provider.ViewModel is MainWindowViewModel)
        {
            return provider.GetProviderModule<IModalWindowProvider>()?.ShowModal<TModalElement, TModalResult>(args);
        }

        return default;
    }
}
