using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.Abstractions.ViewModels;
using _4alleach.MCRecipeEditor.Client.BusinessModels;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Client.Views.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Windows;

public sealed partial class MainWindowViewModel : WindowViewModel, IExtendedWindowViewModel
{
    private readonly MainWindowBusinessModel mwBModel;

    [ObservableProperty]
    private string title;

    public MainWindowViewModel(Grid container) : base(container)
    {
        mwBModel = new MainWindowBusinessModel();
        title = "Minecraft Recipe Editor";
    }

    public void RegisterService<TService, TServiceImplementation>()
        where TService : IService
        where TServiceImplementation : class, IService
    {
        mwBModel.RegisterService<TService, TServiceImplementation>();
    }

    public TService? GetService<TService>() where TService : class, IService
    {
        return mwBModel.GetService<TService>();
    }

    public override void Initialize()
    {
        RegisterControl<PreviewControl>();
        RegisterControl<MenuControl>();

        ShowControl<PreviewControl>();

        mwBModel.Initialize();
    }
}
