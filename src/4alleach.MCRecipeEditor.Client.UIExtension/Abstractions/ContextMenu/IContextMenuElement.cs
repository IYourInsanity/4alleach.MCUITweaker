using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu;

public interface IContextMenuElement
{
    void Initialize(Panel container);

    void Show(MouseButtonEventArgs e);

    void Hide();

    public void Add<TContextItemContent>(TContextItemContent content)
        where TContextItemContent : FrameworkElement;

    public void Remove<TContextItemContent>(TContextItemContent content)
        where TContextItemContent : FrameworkElement;
}
