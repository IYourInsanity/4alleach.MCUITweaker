using _4alleach.MCRecipeEditor.Database.Provider.Abstractions;
using _4alleach.MCRecipeEditor.Models.Database;
using _4alleach.MCRecipeEditor.Models.Database.Base;
using System.Net;

namespace _4alleach.MCRecipeEditor.Database.Provider;

public sealed class DatabaseProvider : IDatabaseProvider
{
    private const string TOKEN_NAME = "token";
    private const string TOKEN_VALUE = "E3155B56-0A8A-4FAA-9884-12A364ADAB97";

    private readonly static string baseUri;
    private readonly static Dictionary<Type, string> requestUriCollection;

    private readonly static CookieContainer cookieContainer;

    private readonly HttpClient client;
    private readonly Dictionary<Type, IHandler> handlerCollection;

    static DatabaseProvider()
    {
        baseUri = "https://localhost:7072/api";
        requestUriCollection = new Dictionary<Type, string>()
        {
            { typeof(Item), $"{baseUri}/{nameof(Item)}/" }
        };

        cookieContainer = new CookieContainer();
        cookieContainer.Add(new Uri(baseUri), new Cookie(TOKEN_NAME, TOKEN_VALUE));
    }

    public DatabaseProvider()
    {
        handlerCollection = new Dictionary<Type, IHandler>();

        var handler = new HttpClientHandler
        {
            CookieContainer = cookieContainer
        };

        client = new HttpClient(handler, true);
    }

    public IHandler<TModel> UseHandler<TModel>()
        where TModel : Asset
    {
        var type = typeof(TModel);

        if(handlerCollection.TryGetValue(type, out var handler))
        {
            return (IHandler<TModel>)handler;
        }

        var defaultUri = string.Empty;

        if (requestUriCollection.TryGetValue(type, out defaultUri) == false)
        {
            throw new NotImplementedException();
        }

        var newHandler = new Handler<TModel>(client, defaultUri);

        handlerCollection.TryAdd(type, newHandler);

        return newHandler;
    }

    public void Dispose()
    {
        client.Dispose();
    }
}
