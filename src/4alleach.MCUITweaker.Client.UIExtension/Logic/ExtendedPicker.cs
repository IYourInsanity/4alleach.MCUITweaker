using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Logic;

internal sealed class ExtendedPicker<TViewModel> : IExtendedPicker<TViewModel> where TViewModel : class, IBaseViewModel
{
    private readonly FrameworkElement element;

    internal ExtendedPicker(FrameworkElement element)
    {
        this.element = element;
    }

    public FrameworkElement GetHost() => element;

    public TElement FindElement<TElement>(string name) where TElement : FrameworkElement
    {
        return (element!.FindName(name) as TElement)!;
    }

    public void SetParentViewModel<TExtendedViewModel>(TExtendedViewModel? parent)
        where TExtendedViewModel : class, TViewModel
    {
        GetViewModel<TViewModel>()?.SetParentViewModel(parent);
    }

    public void SetArguments(params object[]? args)
    {
        GetViewModel<TViewModel>()?.SetArguments(args);
    }

    public TElement? GetParentElement<TElement>() where TElement : FrameworkElement
    {
        var parent = element.Parent;

        while (parent != null)
        {
            if(parent is TElement)
            {
                return parent as TElement;
            }

            if(parent is FrameworkElement elementParent)
            {
                parent = elementParent.Parent;
            }
            else
            {
                break;
            }
        }

        return null;
    }

    public TElement FindElements<TElement>() where TElement : FrameworkElement
    {
        throw new NotImplementedException();
    }

    public TViewModel? GetViewModel()
    {
        return element?.DataContext as TViewModel;
    }

    public TExtendedViewModel? GetViewModel<TExtendedViewModel>()
        where TExtendedViewModel : class, TViewModel
    {
        return element?.DataContext as TExtendedViewModel;
    }
}
