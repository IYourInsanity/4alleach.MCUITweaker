using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
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

    protected IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider;

    protected BaseViewModel(IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base()
    {
        this.provider = provider;
    }

    public abstract void Initialize();

    public abstract TFrameworkElement? FindElement<TFrameworkElement>(string name)
        where TFrameworkElement : FrameworkElement;

    public virtual void SetParent<TParentElement>(TParentElement? parent)
        where TParentElement : FrameworkElement
    {
        
    }

    public virtual void SetArguments(params object[]? args) 
    { 
        
    }

    public void UpdateVisibility(bool state)
    {
        IsVisible = state;
    }
}
