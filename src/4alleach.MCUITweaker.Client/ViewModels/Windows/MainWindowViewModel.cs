using _4alleach.MCUITweaker.Client.Abstractions.Services;
using _4alleach.MCUITweaker.Client.Abstractions.ViewModels;
using _4alleach.MCUITweaker.Client.BusinessModels;
using _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;

namespace _4alleach.MCUITweaker.Client.ViewModels.Windows;

public sealed class MainWindowViewModel : WindowViewModel, IExtendedWindowViewModel
{
    private readonly MainWindowBusinessModel mwBModel;

    public MainWindowViewModel() : base()
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
       mwBModel.Initialize();
    }
}
