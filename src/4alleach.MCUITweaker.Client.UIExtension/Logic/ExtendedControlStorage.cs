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

    public void Register<VExtendedControl>() where VExtendedControl : TExtendedControl
    {
        var control = Activator.CreateInstance<VExtendedControl>();

        controls.Add(control);
        storage.Add(control.GetType(), control);
    }

    public void Navigate<VExtendedControl>() where VExtendedControl : TExtendedControl
    {
        var control = storage[typeof(VExtendedControl)];
        var uiControl = control.Picker.GetHost();

        container.Children.Add(uiControl);
        
        if (current != null)
        {
            container.Children.Remove(current.Picker.GetHost());
        }

        current = control;
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
