using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic;
using System.Windows;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;

public class ExtendedControl : System.Windows.Controls.UserControl, IExtendedFrameworkElement
{
    public Guid VID { get; }

    public new string Name { get; }

    public FrameworkElement Value => this;

    public UIElementCollection Children => this.Children;

    public IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> Provider { get; }

    public ExtendedControl(string name) : base()
    {
        Loaded += ControlLoaded;

        Provider = new ElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel>(this);

        VID = Guid.NewGuid();
        Name = name;
    }

    protected virtual void ControlLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is IExtendedFrameworkElement control)
        {
            var context = control.Provider.ViewModel;

            if (context is IExtendedFrameworkElementViewModel viewModel && 
                viewModel.IsInitialized == false)
            {
                viewModel.SetElement(control);
                viewModel.Initialize();
                viewModel.UpdateVisibility(true);
            }
        }
    }
}
