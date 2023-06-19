using _4alleach.MCRecipeEditor.Client.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using _4alleach.MCRecipeEditor.Client.ViewModels.Windows;
using _4alleach.MCRecipeEditor.Models.Services;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.Extensions;
internal static class ElementProviderExtension
{
    internal static TService? GetService<TService>(this IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider)
        where TService : class, IService
    {
        return provider?.GetRootProvider()?.GetViewModel<MainWindowViewModel>()?.GetService<TService>();
    }

    internal static void UpdateAppState(this IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider, ApplicationState state, string description = "")
    {
        provider?.GetRootProvider()?.GetProviderModule<IApplicationStateProvider>()?.Update(state, description);
    }

    internal static Task<TModalResult> ShowModal<TModalElement, TModalResult>(this IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider, params object[]? args)
        where TModalElement : ExtendedModalWindow, new()
        where TModalResult : IModalResult
    {
        if(provider.ViewModel is MainWindowViewModel)
        {
            var result = provider.GetProviderModule<IModalWindowProvider>()?.ShowModal<TModalElement, TModalResult>(args);

            if(result == null)
            {
                throw new NotImplementedException();
            }

            return result;
        }

        throw new NotImplementedException();
    }

    internal static IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel>? GetRootProvider(this IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider)
    {
        return provider.ViewModel is MainWindowViewModel ? provider : provider.GetParent<ExtendedWindow>()?.Provider;
    }
}
