using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;

public interface IExtendedPicker<TViewModel> where TViewModel : class, IBaseViewModel
{
    FrameworkElement GetHost();

    TViewModel? GetViewModel();

    TExtendedViewModel? GetViewModel<TExtendedViewModel>()
        where TExtendedViewModel : class, TViewModel;

    void SetParentViewModel<TExtendedViewModel>(TExtendedViewModel? parent) 
        where TExtendedViewModel : class, TViewModel;

    TElement? GetParentElement<TElement>() where TElement : FrameworkElement;

    TElement FindElement<TElement>(string name) where TElement : FrameworkElement;

    TElement FindElements<TElement>() where TElement : FrameworkElement;
}
