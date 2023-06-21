using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
public interface IContextMenuProvider : IProviderModule<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel>
{
    void Register<TCreator, TContextMenu>(string containerName, Action<TContextMenu> registerCallback)
        where TCreator : IExtendedFrameworkElementViewModel
        where TContextMenu : IContextMenuElement;

    void Show<TCreator>(MouseButtonEventArgs e)
        where TCreator : IExtendedFrameworkElementViewModel;

}
