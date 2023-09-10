using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu.ViewModel;

public interface IContextMenuViewModel
{
    void Setup(Point position, Size size);

    void Add<TContextItemContent>(TContextItemContent element)
        where TContextItemContent : FrameworkElement;

    void Remove<TContextItemContent>(TContextItemContent element)
        where TContextItemContent : FrameworkElement;
}
