namespace _4alleach.MCRecipeEditor.Models.Services.Project;

public record AppProject(string Name, IList<FileProject> Files) : IdentityObject;
