using CommunityToolkit.Mvvm.ComponentModel;

namespace _4alleach.MCRecipeEditor.Models;

public abstract partial class IdentityObject : ObservableObject
{
    [ObservableProperty]
    private Guid id; 

    protected IdentityObject()
    {
        Id = Guid.NewGuid();
    }
}
