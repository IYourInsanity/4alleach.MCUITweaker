using _4alleach.MCUITweaker.Client.UIExtension.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.Logic;
using _4alleach.MCUITweaker.Client.UIExtension.UserControl.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;
using System.Windows;

namespace _4alleach.MCUITweaker.Client.UIExtension.UserControl;

public class ExtendedControl : System.Windows.Controls.UserControl, IExtendedControl
{
    public Guid VID { get; }

    public new string Name { get; }

    public IExtendedPicker<IControlViewModel> Picker { get; }

    protected ExtendedControl(IControlViewModel viewModel, string name) : base()
    {
        Loaded += ControlLoaded;
        DataContext = viewModel;
        Picker = new ExtendedPicker<IControlViewModel>(this);

        VID = Guid.NewGuid();
        Name = name;
    }

    protected void ControlLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is ExtendedControl control)
        {
            var context = control.Picker.GetViewModel();

            if (context is IControlViewModel viewModel)
            {
                viewModel.SetControl(this);
                viewModel.Initialize();
                viewModel.UpdateVisibility(true);
            }
        }
    }
}
