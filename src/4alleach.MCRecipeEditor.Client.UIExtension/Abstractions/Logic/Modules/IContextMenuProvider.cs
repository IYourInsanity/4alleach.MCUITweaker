using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
public interface IContextMenuProvider : IProviderModule<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel>
{
    void Register<TContextMenu>(string key, Action<TContextMenu> registerCallback)
        where TContextMenu : IContextMenuElement;

    void Show(string key, MouseButtonEventArgs e);

    void Hide();

}
