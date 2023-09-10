using _4alleach.MCRecipeEditor.Client.Helpers;
using System.Windows;

namespace _4alleach.MCRecipeEditor;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        RunApplication();

        base.OnStartup(e);
    }

    private void RunApplication()
    {
        ThreadPoolConfigurationHelper.ConfigureThreadPool();
    }
}



