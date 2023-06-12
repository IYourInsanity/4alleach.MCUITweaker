using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using _4alleach.MCRecipeEditor.Client.ViewModels.Windows;

namespace _4alleach.MCRecipeEditor;

public partial class MainWindow : ExtendedWindow
{
    public MainWindow() : base(nameof(MainWindow))
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel(Container, Provider);
    }
}
