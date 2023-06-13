using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
public interface IModalWindowProvider : IProviderModule<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel>
{
    TModalResult? ShowModal<TModalElement, TModalResult>(params object[]? args)
        where TModalElement : ExtendedModalWindow, new()
        where TModalResult : class;
}
