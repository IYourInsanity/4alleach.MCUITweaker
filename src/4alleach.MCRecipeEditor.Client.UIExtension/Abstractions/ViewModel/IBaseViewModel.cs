using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

public interface IBaseViewModel
{
    bool IsInitialized { get; }

    void Initialize();

    void UpdateVisibility(bool state);

    void SetParent<TParentElement>(TParentElement? parent)
        where TParentElement : FrameworkElement;

    void SetArguments(params object[]? args);

    TFrameworkElement? FindElement<TFrameworkElement>(string name)
        where TFrameworkElement : FrameworkElement;
}
