using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public abstract partial class ControlViewModel<TExtendedWindowViewModel> : BaseViewModel, IControlViewModel
    where TExtendedWindowViewModel : class, IWindowViewModel
{
    private readonly IExtendedControlStorage<IExtendedControl>? storage;

    protected TExtendedWindowViewModel? window;

    protected IExtendedControl? control;

    protected IControlViewModel? parent;

    protected IEnumerable<IControlViewModel>? children;

    protected string ControlName => control?.Name ?? string.Empty;

    protected ControlViewModel(): base()
    {
        parent = this;
    }

    protected ControlViewModel(Grid container): base()
    {
        parent = this;
        storage = new ExtendedControlStorage<IExtendedControl>(container);
    }

    public override void Initialize()
    {
        if (control == null)
        {
            throw new NotImplementedException();
        }

        var root = control.Picker.GetParentElement<ExtendedWindow>();

        if (root == null)
        {
            throw new NotImplementedException();
        }

        window = root.Picker.GetViewModel<TExtendedWindowViewModel>();

        if (window == null)
        {
            throw new NotImplementedException();
        }

        IsInitialized = true;
    }

    public void SetControl<TControl>(TControl control) where TControl : IExtendedControl
    {
        this.control = control;
    }

    public TControl? GetControl<TControl>() where TControl : class, IExtendedControl
    {
        return control as TControl;
    }

    public override void SetParentViewModel<TViewModel>(TViewModel? parent) where TViewModel : class
    {
        this.parent = parent as IControlViewModel;
    }

    public TViewModel? GetChildViewModel<TViewModel>() where TViewModel : class, IControlViewModel
    {
        if (children == null) return default;

        return children.Where(child => child is TViewModel).FirstOrDefault() as TViewModel;
    }

    public bool SetChildViewModel<TViewModel>(TViewModel model) where TViewModel : class, IControlViewModel
    {
        children ??= new List<IControlViewModel>();
        children = children.Append(model);

        return true;
    }

    public override TFrameworkElement FindElement<TFrameworkElement>(string name)
    {
        return control!.Picker.FindElement<TFrameworkElement>(name);
    }

    public void RegisterControl<VExtendedControl>(IExtendedControl? parent = default) where VExtendedControl : IExtendedControl
    {
        storage?.Register<VExtendedControl>(parent);
    }

    public void UnregisterControl<VExtendedControl>() where VExtendedControl : IExtendedControl
    {
        storage?.Unregister<VExtendedControl>();
    }

    public void ShowControl<VExtendedControl>(params object[]? args) where VExtendedControl : IExtendedControl
    {
        storage?.Show<VExtendedControl>(args);
    }

    public void HideControl<VExtendedControl>() where VExtendedControl : IExtendedControl
    {
        storage?.Hide<VExtendedControl>();
    }

    public void HideLatestControl()
    {
        storage?.HideLatest();
    }
}
