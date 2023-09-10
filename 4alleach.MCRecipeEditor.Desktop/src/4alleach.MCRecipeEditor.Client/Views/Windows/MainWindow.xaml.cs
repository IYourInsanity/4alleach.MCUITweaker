using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Helpers;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using _4alleach.MCRecipeEditor.Client.ViewModels.Window;
using System.Windows;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor;

public partial class MainWindow : ExtendedWindow
{
    public MainWindow() : base(nameof(MainWindow))
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel(Container, Provider);
    }

    private void ContextMenuContainerMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Provider.GetProviderModule<IContextMenuProvider>()?.Hide();
    }

    private void ContextMenuContainerMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        Provider.GetProviderModule<IContextMenuProvider>()?.Hide();


        //TODO Rework this logic
        if(sender is FrameworkElement element)
        {
            var hitResult = InputHitTest(e.GetPosition(element));

            if(hitResult is FrameworkElement elementUnderContextMenu)
            {
               var identifier = (string)elementUnderContextMenu.GetValue(ContextMenuHelper.IdentifierProperty);

                if(identifier.Equals(string.Empty) == false)
                {
                    Provider.GetProviderModule<IContextMenuProvider>()?.Show(identifier, e);
                }
            }     
        }
    }
}
