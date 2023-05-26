using _4alleach.MCUITweaker.Client.UIExtension.Window;
using _4alleach.MCUITweaker.Client.ViewModels.Windows;

namespace _4alleach.MCUITweaker;

public partial class MainWindow : ExtendedWindow
{
    public MainWindow() : base(nameof(MainWindow))
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel(Root);
    }
}
