using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public interface IBaseViewModel
{
    bool IsInitialized { get; }

    void Initialize();

    void UpdateVisibility(bool state);

    void SetParentViewModel<TViewModel>(TViewModel? parent) where TViewModel : class, IBaseViewModel;

    void SetArguments(params object[]? args);

    TFrameworkElement FindElement<TFrameworkElement>(string name) where TFrameworkElement : FrameworkElement;
}
