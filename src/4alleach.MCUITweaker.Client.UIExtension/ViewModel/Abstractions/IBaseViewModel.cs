using System.Windows;

namespace _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;

public interface IBaseViewModel
{
    void Initialize();

    void UpdateVisibility(bool state);

    TFrameworkElement FindElement<TFrameworkElement>(string name) where TFrameworkElement : FrameworkElement;
}
