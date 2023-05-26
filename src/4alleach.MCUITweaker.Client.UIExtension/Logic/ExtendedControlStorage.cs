using _4alleach.MCUITweaker.Client.UIExtension.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.UserControl.Abstractions;
using System.Windows.Controls;

namespace _4alleach.MCUITweaker.Client.UIExtension.Logic;

internal sealed class ExtendedControlStorage<TExtendedControl> : IExtendedControlStorage<TExtendedControl>
    where TExtendedControl : class, IExtendedControl
{
    private readonly Panel root;

    private readonly IList<TExtendedControl> controls;
    private readonly Dictionary<Type, TExtendedControl> storage;

    private TExtendedControl? current;

    internal ExtendedControlStorage(Panel root)
    {
        controls = new List<TExtendedControl>();
        storage = new Dictionary<Type, TExtendedControl>();

        this.root = root;
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

        root.Children.Add(control.Picker.GetHost());

        if (current != null)
        {
            root.Children.Remove(current.Picker.GetHost());
        }

        current = control;
    }

    public void Unregister<VExtendedControl>() where VExtendedControl : TExtendedControl
    {
        var control = storage[typeof(VExtendedControl)];

        controls.Remove(control);

        var host = control.Picker.GetHost();

        if (root.Children.Contains(host))
        {
            root.Children.Remove(host);
        }
    }
}
