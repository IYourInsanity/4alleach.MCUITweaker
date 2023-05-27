using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Window;

public class ExtendedModalWindow<TResult> : System.Windows.Window, IExtendedModalWindow where TResult: class
{
    public Guid VID { get; }

    public new string Name { get; }

    public IExtendedPicker<IModalWindowViewModel> Picker { get; }

    public ExtendedModalWindow(IModalWindowViewModel viewModel, string name) : base()
    {
        DataContext = viewModel;
        Picker = new ExtendedPicker<IModalWindowViewModel>(this);

        VID = Guid.NewGuid();
        Name = name;
    }
}
