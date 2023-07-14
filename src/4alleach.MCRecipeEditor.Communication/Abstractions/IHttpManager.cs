using _4alleach.MCRecipeEditor.Communication.Models;

namespace _4alleach.MCRecipeEditor.Communication.Abstractions;

public interface IHttpManager
{
    public IHttpProvider Use(ProviderType type);
}
