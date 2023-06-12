using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window.Abstractions;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

public abstract partial class ControlViewModel : BaseViewModel, IControlViewModel
{
    protected IExtendedWindow? root;

    protected IExtendedControl? control;

    protected IExtendedControl? parent;

    protected IEnumerable<IControlViewModel>? children;

    protected string ControlName => control?.Name ?? string.Empty;

    protected ControlViewModel() : base()
    {
        parent = control;
    }

    protected ControlViewModel(Grid container) : base()
    {
        parent = control;
    }

    public override void Initialize()
    {
        if (control == null)
        {
            throw new NotImplementedException();
        }

        root = control.Provider.GetParentElement<ExtendedWindow>();

        if (root == null)
        {
            throw new NotImplementedException();
        }

        IsInitialized = true;
    }

    public void SetControl<TControl>(TControl control)
        where TControl : IExtendedControl
    {
        this.control = control;
    }

    public TControl? GetControl<TControl>()
        where TControl : class, IExtendedControl
    {
        return control as TControl;
    }

    public override void SetParent<TParentElement>(TParentElement? parent)
        where TParentElement : class
    {
        if (parent is IExtendedControl validParent)
        {
            this.parent = validParent;
        }

        throw new NotImplementedException();
    }

    public TViewModel? GetChildViewModel<TViewModel>()
        where TViewModel : class, IControlViewModel
    {
        if (children == null) return default;

        return children.Where(child => child is TViewModel).FirstOrDefault() as TViewModel;
    }

    public bool SetChildViewModel<TViewModel>(TViewModel model)
        where TViewModel : class, IControlViewModel
    {
        children ??= new List<IControlViewModel>();
        children = children.Append(model);

        return true;
    }

    public override TFrameworkElement? FindElement<TFrameworkElement>(string name)
        where TFrameworkElement : class
    {
        if (control == null)
        {
            return default;
        }

        return control.Provider.FindElement<TFrameworkElement>(name);
    }
}
