using _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;
using System.Windows;

namespace _4alleach.MCUITweaker.Client.UIExtension.Abstractions;

public interface IExtendedPicker<TViewModel> where TViewModel : IBaseViewModel
{
    TViewModel? GetViewModel();

    TElement FindElement<TElement>(string name) where TElement : FrameworkElement;
}
