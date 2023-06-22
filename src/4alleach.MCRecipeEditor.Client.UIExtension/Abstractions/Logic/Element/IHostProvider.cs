using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Element;

public interface IHostProvider
{
    FrameworkElement Host { get; }

    Type HostType { get; }

    IElementContainer? Container { get; set; }



    void SetParent<TParentElement>(TParentElement? parent)
        where TParentElement : FrameworkElement;

    TFrameworkElement? GetParent<TFrameworkElement>()
        where TFrameworkElement : FrameworkElement;

    TFrameworkElement? FindElement<TFrameworkElement>(string name)
        where TFrameworkElement : FrameworkElement;

    TFrameworkElement? FindElement<TFrameworkElement>(Func<DependencyObject, bool> funcCondition)
        where TFrameworkElement : FrameworkElement;
}
