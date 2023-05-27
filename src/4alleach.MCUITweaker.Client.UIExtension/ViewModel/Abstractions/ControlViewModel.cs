using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public abstract partial class ControlViewModel : BaseViewModel, IControlViewModel
{
    protected IExtendedControl? control;

    protected IControlViewModel parent;

    protected IEnumerable<IControlViewModel>? children;

    protected ControlViewModel(): base()
    {
        parent = this;
    }

    protected ControlViewModel(IControlViewModel parent): base()
    {
        this.parent = parent;
    }

    public void SetControl<TControl>(TControl control) where TControl : IExtendedControl
    {
        this.control = control;
    }

    public TControl? GetControl<TControl>() where TControl : class, IExtendedControl
    {
        return control as TControl;
    }

    public TViewModel? GetParentViewModel<TViewModel>() where TViewModel : class, IControlViewModel
    {
        return parent as TViewModel;
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
}
