using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window.Abstractions;
using System.Windows.Controls;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public abstract partial class WindowViewModel : BaseViewModel, IWindowViewModel
{
    protected IExtendedWindow? window;

    protected readonly IExtendedControlStorage<IExtendedControl> storage;

    public WindowViewModel(Grid container) : base()
    {
        storage = new ExtendedControlStorage<IExtendedControl>(container);
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

    public void RegisterControl<VExtendedControl>(VExtendedControl? parent = default) where VExtendedControl : IExtendedControl
    {
        storage.Register<VExtendedControl>(parent);
    }

    public void ShowControl<VExtendedControl>() where VExtendedControl : IExtendedControl
    {
        storage.Show<VExtendedControl>();
    }

    public void HideControl<VExtendedControl>() where VExtendedControl : IExtendedControl
    {
        storage.Hide<VExtendedControl>();
    }

    public void UnregisterControl<VExtendedControl>() where VExtendedControl : IExtendedControl
    {
        storage.Unregister<VExtendedControl>();
    }
}
