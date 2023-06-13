using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using System.Windows.Controls;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

public abstract partial class ControlViewModel : BaseViewModel, IExtendedFrameworkElementViewModel
{
    protected IExtendedFrameworkElement? root;

    protected IExtendedFrameworkElement? control;

    protected IExtendedFrameworkElement? parent;

    protected IEnumerable<IExtendedFrameworkElementViewModel>? children;

    protected string ControlName => control?.Name ?? string.Empty;

    protected ControlViewModel(IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(provider)
    {
        parent = control;
    }

    protected ControlViewModel(Panel container, IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(provider)
    {
        parent = control;

        provider.Container = new ElementContainer(container);
    }

    public override void Initialize()
    {
        if (control == null)
        {
            throw new NotImplementedException();
        }

        root = control.Provider.GetParent<ExtendedWindow>();

        if (root == null)
        {
            throw new NotImplementedException();
        }

        IsInitialized = true;
    }

    public override void SetParent<TParentElement>(TParentElement? parent)
        where TParentElement : class
    {
        if (parent is IExtendedFrameworkElement validParent)
        {
            this.parent = validParent;
            return;
        }

        throw new NotImplementedException();
    }

    public TViewModel? GetChildViewModel<TViewModel>()
        where TViewModel : class, IExtendedFrameworkElementViewModel
    {
        if (children == null) return default;

        return children.Where(child => child is TViewModel).FirstOrDefault() as TViewModel;
    }

    public bool SetChildViewModel<TViewModel>(TViewModel model)
        where TViewModel : class, IExtendedFrameworkElementViewModel
    {
        children ??= new List<IExtendedFrameworkElementViewModel>();
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

    public void SetElement<TExtendedElement>(TExtendedElement control)
        where TExtendedElement : class, IExtendedFrameworkElement
    {
        this.control = control;
    }

    public TExtendedElement? GetElement<TExtendedElement>()
        where TExtendedElement : class, IExtendedFrameworkElement
    {
        return this.control as TExtendedElement;
    }

    public void KeyPress(Key key)
    {
        throw new NotImplementedException();
    }
}
