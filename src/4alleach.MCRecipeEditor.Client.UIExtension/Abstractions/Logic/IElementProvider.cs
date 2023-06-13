using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Element;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;

public interface IElementProvider<TElement, TViewModel> : IElementController<TElement, TViewModel>, IHostProvider, IViewModelProvider<TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{

}
