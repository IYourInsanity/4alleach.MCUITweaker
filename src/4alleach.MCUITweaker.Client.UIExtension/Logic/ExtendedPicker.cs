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

    public TViewModel? GetViewModel()
    {
        return element?.DataContext as TViewModel;
    }
}
