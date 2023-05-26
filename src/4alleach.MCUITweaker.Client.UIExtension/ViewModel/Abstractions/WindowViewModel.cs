﻿using _4alleach.MCUITweaker.Client.UIExtension.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.Logic;
using _4alleach.MCUITweaker.Client.UIExtension.UserControl.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.Window.Abstractions;
using System.Windows.Controls;
using System.Windows.Input;

namespace _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;

public abstract partial class WindowViewModel : BaseViewModel, IWindowViewModel
{
    protected IExtendedWindow? window;

    protected readonly IExtendedControlStorage<IExtendedControl> storage;

    public WindowViewModel(Panel root) : base()
    {
        storage = new ExtendedControlStorage<IExtendedControl>(root);
    }

    public void SetWindow<TWindow>(TWindow window) where TWindow : IExtendedWindow
    {
        this.window = window;
    }

    public TWindow? GetWindow<TWindow>() where TWindow : class, IExtendedWindow
    {
        return window as TWindow;
    }

    public override TFrameworkElement FindElement<TFrameworkElement>(string name)
    {
        return window!.Picker.FindElement<TFrameworkElement>(name);
    }

    public void KeyPress(Key key)
    {
        throw new NotImplementedException();
    }

    public void RegisterControl<VExtendedControl>() where VExtendedControl : IExtendedControl
    {
        storage.Register<VExtendedControl>();
    }

    public void NavigateToControl<VExtendedControl>() where VExtendedControl : IExtendedControl
    {
        storage.Navigate<VExtendedControl>();
    }

    public void UnregisterControl<VExtendedControl>() where VExtendedControl : IExtendedControl
    {
        storage.Unregister<VExtendedControl>();
    }
}
