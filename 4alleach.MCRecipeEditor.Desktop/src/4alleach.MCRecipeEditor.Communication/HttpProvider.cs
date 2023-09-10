using _4alleach.MCRecipeEditor.Communication.Abstractions;
using _4alleach.MCRecipeEditor.Models.Database.Base;
using System.Net;

namespace _4alleach.MCRecipeEditor.Communication;

internal sealed class HttpProvider : IHttpProvider
{
    private readonly string uri;

    private readonly Dictionary<Type, string> requestUriCollection;

    private readonly Dictionary<Type, Type> handlerCollection;

    private readonly CookieContainer cookieContainer;

    public HttpProvider(string uri, Dictionary<Type, string> requestUriCollection, Dictionary<Type, Type> handlerCollection, CookieContainer cookieContainer)
    {
        this.uri = uri;
        this.requestUriCollection = requestUriCollection;
        this.handlerCollection = handlerCollection;
        this.cookieContainer = cookieContainer;
    }

    public ICommunicationHandler<TModel> UseHandler<TModel>()
        where TModel : Asset
    {
        var type = typeof(TModel);

        if (requestUriCollection.TryGetValue(type, out var assetUri) && assetUri != null &&
            handlerCollection.TryGetValue(type, out var handlerType) && handlerType != null)
        {
            return (ICommunicationHandler<TModel>)Activator.CreateInstance(handlerType, cookieContainer, assetUri)!;
        }

        throw new NotImplementedException();
    }
}
