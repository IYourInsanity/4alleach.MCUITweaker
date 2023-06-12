using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.BusinessModels;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.Views.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Windows;

public sealed partial class MainWindowViewModel : WindowViewModel, IExtendedFrameworkElementViewModel
{
    private readonly MainWindowBusinessModel mwBModel;

    [ObservableProperty]
    private string title;

    public MainWindowViewModel(Grid container, IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(container, provider)
    {
        mwBModel = new MainWindowBusinessModel();
        title = "Minecraft Recipe Editor";
    }

    public override void Initialize()
    {
        provider.Register<PreviewControl>();
        provider.Register<MenuControl>();

        provider.Show<PreviewControl>();

        mwBModel.Initialize();
    }

    internal TService? GetService<TService>() 
        where TService : class, IService
    {
        return mwBModel.GetService<TService>();
    }
}
