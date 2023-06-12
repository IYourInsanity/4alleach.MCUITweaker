using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
public interface IHostControl
{
    UIElementCollection Children { get; }
}
