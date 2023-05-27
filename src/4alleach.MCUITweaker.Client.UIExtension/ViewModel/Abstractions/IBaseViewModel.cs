using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public interface IBaseViewModel
{
    void Initialize();

    void UpdateVisibility(bool state);

    TFrameworkElement FindElement<TFrameworkElement>(string name) where TFrameworkElement : FrameworkElement;
}
