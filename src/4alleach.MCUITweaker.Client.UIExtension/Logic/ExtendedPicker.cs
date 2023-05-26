using _4alleach.MCUITweaker.Client.UIExtension.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;
using System.Windows;

namespace _4alleach.MCUITweaker.Client.UIExtension.Logic;

internal sealed class ExtendedPicker<TViewModel> : IExtendedPicker<TViewModel> where TViewModel : class, IBaseViewModel
{
    private readonly FrameworkElement element;

    internal ExtendedPicker(FrameworkElement element)
    {
        this.element = element;
    }

    public TElement FindElement<TElement>(string name) where TElement : FrameworkElement
    {
        return (element!.FindName(name) as TElement)!;
    }

    public TParent? GetParent<TParent>() where TParent : FrameworkElement
    {
        var parent = element.Parent;

        while (parent != null)
        {
            if(parent is TParent)
            {
                return parent as TParent;
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
