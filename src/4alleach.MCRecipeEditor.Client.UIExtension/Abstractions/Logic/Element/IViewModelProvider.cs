using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Element;

public interface IViewModelProvider<TViewModel>
    where TViewModel : class, IBaseViewModel
{
    TViewModel? ViewModel { get; }



    TExtendedViewModel? GetViewModel<TExtendedViewModel>()
        where TExtendedViewModel : TViewModel;

    void SetArguments(params object[]? args);
}
