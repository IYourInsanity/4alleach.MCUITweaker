using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;

public class ExtendedControl : System.Windows.Controls.UserControl, IExtendedControl
{
    public Guid VID { get; }

    public new string Name { get; }

    public FrameworkElement Value => this;

    public UIElementCollection Children => this.Children;

    public IElementProvider<IExtendedControl, IControlViewModel> Provider { get; }

    public ExtendedControl(string name) : base()
    {
        Loaded += ControlLoaded;

        Provider = new ElementProvider<IExtendedControl, IControlViewModel>(this);

        VID = Guid.NewGuid();
        Name = name;
    }

    protected virtual void ControlLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is IExtendedControl control)
        {
            var context = control.Provider.ViewModel;

            if (context is IControlViewModel viewModel && 
                viewModel.IsInitialized == false)
            {
                viewModel.SetControl(control);
                viewModel.Initialize();
                viewModel.UpdateVisibility(true);
            }
        }
    }
}
