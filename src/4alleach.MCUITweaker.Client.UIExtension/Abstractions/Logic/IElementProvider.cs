using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;

public interface IElementProvider<TElement, TViewModel> : IElementController<TElement, TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    FrameworkElement Host { get; }

    Type HostType { get; }

    TViewModel? ViewModel { get; }

    TExtendedViewModel? GetViewModel<TExtendedViewModel>()
        where TExtendedViewModel : TViewModel;

    void SetParent<TParentElement>(TParentElement? parent)
        where TParentElement : FrameworkElement;

    void SetArguments(params object[]? args);

    TFrameworkElement? GetParentElement<TFrameworkElement>() 
        where TFrameworkElement : FrameworkElement;

    TFrameworkElement? FindElement<TFrameworkElement>(string name) 
        where TFrameworkElement : FrameworkElement;
}
