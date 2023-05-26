using _4alleach.MCUITweaker.Client.UIExtension.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.Logic;
using _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.Window.Abstractions;
using System.Windows;
using System.Windows.Input;

namespace _4alleach.MCUITweaker.Client.UIExtension.Window;

public class ExtendedWindow : System.Windows.Window, IExtendedWindow
{
    public Guid VID { get; }

    public new string Name { get; }

    public IExtendedPicker<IWindowViewModel> Picker { get; }

    protected ExtendedWindow(string name) : base()
    {
        Loaded += WindowLoaded;
        Picker = new ExtendedPicker<IWindowViewModel>(this);

        VID = Guid.NewGuid();
        Name = name;
    }

    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
        if (sender is ExtendedWindow control)
        {
            if (control.Picker.GetViewModel() is IWindowViewModel viewModel)
            {
                viewModel.SetWindow(this);
                viewModel.Initialize();
                viewModel.UpdateVisibility(true);
            }
        }
    }

    private void KeyPressed(object sender, KeyEventArgs e)
    {
        Picker.GetViewModel()?.KeyPress(e.Key);
    }

    private void DragWindow(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void MinimizeWindow(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void ResizeWindow(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Normal)
        {
            WindowState = WindowState.Maximized;
        }
        else
        {
            WindowState = WindowState.Normal;
        }
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
        //TODO: Rework it
        Environment.Exit(0);
    }
}
