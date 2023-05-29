namespace _4alleach.MCRecipeEditor.Models.Services.Project;

public record FileProject(string Name, IList<RecipeProject> Recipes) : IdentityObject;
