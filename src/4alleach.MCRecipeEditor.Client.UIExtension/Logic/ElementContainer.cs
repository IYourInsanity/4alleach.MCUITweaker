using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using System.Windows;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Logic;

internal sealed class ElementContainer : IElementContainer
{
    private readonly Panel container;

    internal ElementContainer(Panel container)
    {
        this.container = container;
    }

    public bool Contains(FrameworkElement? element)
    {
        if(element == null)
        {
            return false;
        }

        return container?.Children.Contains(element) == true;
    }

    public bool TryAdd(FrameworkElement? element)
    {
        if (Contains(element))
        {
            return false;
        }

        container?.Children.Add(element);

        return true;
    }

    public bool TryRemove(FrameworkElement? element)
    {
        if (Contains(element) == false)
        {
            return false;
        }

        container?.Children.Remove(element);

        return true;
    }
}
