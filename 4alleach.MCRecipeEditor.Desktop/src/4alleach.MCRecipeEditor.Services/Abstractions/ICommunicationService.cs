using _4alleach.MCRecipeEditor.Communication.Abstractions;
using _4alleach.MCRecipeEditor.Communication.Models;

namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public interface ICommunicationService : IService
{
    IHttpProvider Use(ProviderType type);
}
