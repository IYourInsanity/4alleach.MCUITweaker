using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public interface IBaseViewModel
{
    void Initialize();

    void UpdateVisibility(bool state);

    void SetParentViewModel<TViewModel>(TViewModel? parent) where TViewModel : class, IBaseViewModel;

    TFrameworkElement FindElement<TFrameworkElement>(string name) where TFrameworkElement : FrameworkElement;
}
