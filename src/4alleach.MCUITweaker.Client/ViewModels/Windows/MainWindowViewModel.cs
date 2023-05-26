using _4alleach.MCUITweaker.Client.Abstractions.Services;
using _4alleach.MCUITweaker.Client.Abstractions.ViewModels;
using _4alleach.MCUITweaker.Client.BusinessModels;
using _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCUITweaker.Client.Views.Control;
using _4alleach.MCUITweaker.Client.Views.Controls;
using System.Windows.Controls;

namespace _4alleach.MCUITweaker.Client.ViewModels.Windows;

public sealed class MainWindowViewModel : WindowViewModel, IExtendedWindowViewModel
{
    private readonly MainWindowBusinessModel mwBModel;

    public MainWindowViewModel(Panel root) : base(root)
    {
        mwBModel = new MainWindowBusinessModel();
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

        NavigateToControl<PreviewControl>();

        mwBModel.Initialize();
    }
}
