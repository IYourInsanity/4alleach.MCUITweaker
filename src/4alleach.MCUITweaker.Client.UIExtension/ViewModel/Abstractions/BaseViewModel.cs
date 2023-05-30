﻿using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public abstract partial class BaseViewModel : ObservableObject, IBaseViewModel
{
    [ObservableProperty]
    protected Guid id;

    [ObservableProperty]
    protected bool isVisible;

    protected BaseViewModel()
    {
        Id = Guid.NewGuid();
        IsVisible = false;
    }

    public abstract void Initialize();

    public virtual void SetParentViewModel<TViewModel>(TViewModel? parent) where TViewModel : class, IBaseViewModel { }

    public abstract TFrameworkElement FindElement<TFrameworkElement>(string name) where TFrameworkElement : FrameworkElement;

    public void UpdateVisibility(bool state)
    {
        IsVisible = state;
    }
}
