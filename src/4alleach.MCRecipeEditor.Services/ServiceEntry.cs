using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Services;

public static class ServiceEntry
{
    public readonly static IServiceHub Instance = ServiceHub.Instance;
}

