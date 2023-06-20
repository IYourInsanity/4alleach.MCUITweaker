using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.CustomControls.Modals;

public sealed partial class TestModalWindow : ExtendedModalWindow
{
    private TaskCompletionSource<IModalResult> completionSource;

    public TestModalWindow()
    {
        InitializeComponent();

        completionSource = new TaskCompletionSource<IModalResult>(TaskCreationOptions.RunContinuationsAsynchronously);
        DataContext = new TestModalViewModel(Container, completionSource, Provider);
    }

    public override Task<IModalResult> AwaitResult()
    {
        return completionSource.Task;
    }

    protected override void OnActivated(EventArgs e)
    {
        completionSource = new TaskCompletionSource<IModalResult>(TaskCreationOptions.RunContinuationsAsynchronously);

        base.OnActivated(e);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        e.Cancel = true;

        Hide();

        completionSource.SetResult(new TestModalResult(true));

        base.OnClosing(e);
    }
}

internal sealed partial class TestModalViewModel : WindowViewModel
{
    [ObservableProperty]
    private string text;

    private TaskCompletionSource<IModalResult> completionSource;

    public TestModalViewModel(Panel container, TaskCompletionSource<IModalResult> completionSource, IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(container, provider)
    {
        this.completionSource = completionSource;
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

public record TestModalResult(bool Success) : IModalResult;
