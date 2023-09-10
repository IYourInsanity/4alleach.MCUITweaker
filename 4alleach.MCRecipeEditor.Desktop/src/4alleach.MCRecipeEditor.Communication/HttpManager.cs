using _4alleach.MCRecipeEditor.Communication.Abstractions;
using _4alleach.MCRecipeEditor.Communication.Database;
using _4alleach.MCRecipeEditor.Communication.Models;
using _4alleach.MCRecipeEditor.Models.Database;
using System.Net;

namespace _4alleach.MCRecipeEditor.Communication;

public sealed class HttpManager : IHttpManager
{
    private readonly Dictionary<ProviderType, IHttpProvider> Providers;

    public HttpManager()
    {
        Providers = new Dictionary<ProviderType, IHttpProvider>()
        {
            { ProviderType.Database, new HttpProvider(Constants.API.Database, GetRequestUriCollectionForDatabase(), GetHandlerCollectionForDatabase(), GetCookieContainerForDatabase()) }
        };
    }

    public IHttpProvider Use(ProviderType type)
    {
        return Providers[type];
    }

    private Dictionary<Type, string> GetRequestUriCollectionForDatabase()
    {
        return new Dictionary<Type, string>()
        {
            { typeof(Item), $"{Constants.API.Database}/{nameof(Item)}" }
        };
    }

    private Dictionary<Type, Type> GetHandlerCollectionForDatabase()
    {
        return new Dictionary<Type, Type>()
        {
            { typeof(Item), typeof(DatabaseHandler<Item>) }
        };
    }

    private CookieContainer GetCookieContainerForDatabase()
    {
        var container = new CookieContainer();

        container.Add(new Uri(Constants.API.Database), new Cookie("token", "E3155B56-0A8A-4FAA-9884-12A364ADAB97"));

        return container;
    }
}
