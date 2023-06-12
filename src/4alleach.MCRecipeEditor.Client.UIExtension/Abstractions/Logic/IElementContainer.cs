using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
public interface IElementContainer
{
    bool TryAdd(FrameworkElement? element);

    bool TryRemove(FrameworkElement? element);

    bool Contains(FrameworkElement? element);
}
