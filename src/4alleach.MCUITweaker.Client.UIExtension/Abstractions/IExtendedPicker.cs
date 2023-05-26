using _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;
using System.Windows;

namespace _4alleach.MCUITweaker.Client.UIExtension.Abstractions;

public interface IExtendedPicker<TViewModel> where TViewModel : IBaseViewModel
{
    FrameworkElement GetHost();

    TViewModel? GetViewModel();

    TExtendedViewModel? GetViewModel<TExtendedViewModel>()
        where TExtendedViewModel : class, TViewModel;

    TParent? GetParent<TParent>() where TParent : FrameworkElement;

    TElement FindElement<TElement>(string name) where TElement : FrameworkElement;

    TElement FindElements<TElement>() where TElement : FrameworkElement;
}
