using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace _4alleach.MCRecipeEditor.Models.CraftTweak.Abstractions;

public abstract partial class DefaultRecipe : ObservableObject
{
    [ObservableProperty]
    private string command;

    [ObservableProperty]
    private int size;

    [ObservableProperty]
    private ObservableCollection<RecipeObject> objects;

    protected DefaultRecipe(int size) : base()
    {
        Command = string.Empty;
        Size = size;
        Objects = new ObservableCollection<RecipeObject>();

        for (int i = 0; i < size; i++)
        {
            Objects.Add(new RecipeObject());
        }
    }
}
