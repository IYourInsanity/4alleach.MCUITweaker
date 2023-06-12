using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public abstract partial class BaseViewModel : ObservableObject, IBaseViewModel
{
    [ObservableProperty]
    protected Guid id;

    [ObservableProperty]
    protected bool isVisible;

    [ObservableProperty]
    protected bool isInitialized;

    protected BaseViewModel()
    {
        Id = Guid.NewGuid();
        IsVisible = false;
    }

    public abstract void Initialize();

    public abstract TFrameworkElement? FindElement<TFrameworkElement>(string name)
        where TFrameworkElement : FrameworkElement;

    public virtual void SetParent<TParentElement>(TParentElement? parent)
        where TParentElement : FrameworkElement
    {
        throw new NotImplementedException();
    }

    public virtual void SetArguments(params object[]? args) 
    { 
        throw new NotImplementedException();
    }

    public void UpdateVisibility(bool state)
    {
        IsVisible = state;
    }
}
