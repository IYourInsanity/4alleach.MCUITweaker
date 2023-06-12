using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;

public interface IBaseElement<TElement, TViewModel> : IHostControl
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    string Name { get; }

    Guid VID { get; }

    FrameworkElement Value { get; }

    IElementProvider<TElement, TViewModel> Provider { get; }
}
