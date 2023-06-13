using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.CustomControls.Modals;

public sealed partial class TestModalWindow : ExtendedModalWindow
{
    public TestModalWindow()
    {
        InitializeComponent();
        DataContext = new TestModalViewModel(Container, Provider);
    }
}

internal sealed partial class TestModalViewModel : WindowViewModel
{
    [ObservableProperty]
    private string text;

    public TestModalViewModel(Panel container, IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(container, provider)
    {
        Text = "Empty";
    }

    public override void Initialize()
    {
        provider.Initialize();
    }

    public override void SetArguments(params object[]? args)
    {
        if(args == null)
        {
            return;
        }

        Text = (string)args[0];
    }
}

public class TestModalResult
{
    public bool Success { get; set; }
}
