using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Logic;

internal sealed class ExtendedControlStorage<TExtendedControl> : IExtendedControlStorage<TExtendedControl>
    where TExtendedControl : class, IExtendedControl
{
    private readonly Panel container;

    private readonly IList<TExtendedControl> controls;
    private readonly Dictionary<Type, TExtendedControl> storage;

    private TExtendedControl? current;

    internal ExtendedControlStorage(Grid container)
    {
        controls = new List<TExtendedControl>();
        storage = new Dictionary<Type, TExtendedControl>();

        this.container = container;
    }

    public void Register<VExtendedControl>(TExtendedControl? parent) where VExtendedControl : TExtendedControl
    {
        var control = Activator.CreateInstance<VExtendedControl>();

        controls.Add(control);
        storage.Add(control.GetType(), control);

        if (parent != null)
        {
            var viewModel = parent.Picker.GetViewModel();

            control.Picker.SetParentViewModel(viewModel);
        }
    }

    public void Show<VExtendedControl>(params object[]? args) where VExtendedControl : TExtendedControl
    {
        var control = storage[typeof(VExtendedControl)];
        var uiControl = control.Picker.GetHost();

        var children = container.Children;

        control.Picker.SetArguments(args);

        if (children.Contains(uiControl) == true)
        {
            return;
        }

        container.Children.Add(uiControl);

        if (current != null && current != control)
        {
            container.Children.Remove(current.Picker.GetHost());
        }

        current = control;
    }

    public void Hide<VExtendedControl>() where VExtendedControl : TExtendedControl
    {
        var control = storage[typeof(VExtendedControl)];
        var uiControl = control.Picker.GetHost();

        container.Children.Remove(uiControl);

        current = null;
    }

    public void Unregister<VExtendedControl>() where VExtendedControl : TExtendedControl
    {
        var control = storage[typeof(VExtendedControl)];

        controls.Remove(control);

        var host = control.Picker.GetHost();

        if (container.Children.Contains(host))
        {
            container.Children.Remove(host);
        }
    }
}
