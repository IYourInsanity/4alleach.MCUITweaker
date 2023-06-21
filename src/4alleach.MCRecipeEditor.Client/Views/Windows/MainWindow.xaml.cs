using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using _4alleach.MCRecipeEditor.Client.ViewModels.Window;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor;

public partial class MainWindow : ExtendedWindow
{
    public MainWindow() : base(nameof(MainWindow))
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel(Container, Provider);
    }

    private void Container_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        Provider.GetProviderModule<IContextMenuProvider>()?.Show<MainWindowViewModel>(e);
    }
}
