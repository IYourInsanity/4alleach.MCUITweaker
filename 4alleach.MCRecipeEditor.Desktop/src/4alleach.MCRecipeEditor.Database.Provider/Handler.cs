using _4alleach.MCRecipeEditor.Database.Provider.Abstractions;
using _4alleach.MCRecipeEditor.Models.Database.Base;
using System.Net.Http.Json;

namespace _4alleach.MCRecipeEditor.Database.Provider;

internal class Handler<TModel> : IHandler<TModel>
    where TModel : Asset
{
    private const int TIMEOUT = 10;

    private readonly HttpClient _client;
    private readonly string _defaultUri;

    internal Handler(HttpClient client, string defaultUri)
    {
        _client = client;
        _defaultUri = defaultUri;
    }

    public async Task<IEnumerable<TModel>?> SelectAllAsync(CancellationToken token)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TIMEOUT));
        using var bindCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);

        var requestUri = _defaultUri + "GetAll";

        return await _client.GetFromJsonAsync<IEnumerable<TModel>>(requestUri, bindCts.Token);
    }
}
