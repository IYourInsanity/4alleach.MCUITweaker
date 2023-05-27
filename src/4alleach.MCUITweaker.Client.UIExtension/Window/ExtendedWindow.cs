using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window.Abstractions;
using System.Windows;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Window;

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

    protected void KeyPressed(object sender, KeyEventArgs e)
    {
        Picker.GetViewModel()?.KeyPress(e.Key);
    }

    protected void DragWindow(object sender, MouseButtonEventArgs e)
    {
        DragMove();

        if(e.ClickCount > 1)
        {
            ResizeWindow(sender, e);
        }
    }

    protected void MinimizeWindow(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    protected void ResizeWindow(object sender, MouseButtonEventArgs e)
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

    protected void CloseWindow(object sender, MouseButtonEventArgs e)
    {
        //TODO: Rework it
        Environment.Exit(0);
    }
}
