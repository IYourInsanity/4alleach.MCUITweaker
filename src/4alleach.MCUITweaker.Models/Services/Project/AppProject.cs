using CommunityToolkit.Mvvm.ComponentModel;

namespace _4alleach.MCRecipeEditor.Models.Services.Project;

public sealed partial class AppProject : IdentityObject
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    IList<FileProject> files;

    public AppProject(string name, IList<FileProject> files) : base()
    {
        Name = name;
        Files = files;
    }
}
