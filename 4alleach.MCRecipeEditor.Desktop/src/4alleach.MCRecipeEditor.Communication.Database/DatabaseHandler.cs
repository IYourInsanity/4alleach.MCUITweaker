using _4alleach.MCRecipeEditor.Communication.Abstractions;
using System.Net;
using System.Net.Http.Json;

namespace _4alleach.MCRecipeEditor.Communication.Database;

public sealed class DatabaseHandler<TModel> : ICommunicationHandler<TModel>
    where TModel : class
{
    private const int TIMEOUT = 10;

    private readonly HttpClient client;
    private readonly string uri;

    public DatabaseHandler(CookieContainer container, string uri)
    {
        client = new HttpClient(new HttpClientHandler
        {
            CookieContainer = container
        }, true);

        this.uri = uri;
    }

    public async Task<IEnumerable<TModel>?> SelectAllAsync(CancellationToken token)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TIMEOUT));
        using var bindCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);

        return await client.GetFromJsonAsync<IEnumerable<TModel>>($"{uri}/GetAll", bindCts.Token)
                            .ConfigureAwait(true);
    }

    public async Task<IEnumerable<TModel>?> SelectWithConditionAsync(string condition, CancellationToken token)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TIMEOUT));
        using var bindCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);

        return await client.GetFromJsonAsync<IEnumerable<TModel>>($"{uri}/GetAll?condition={condition}", bindCts.Token)
                    .ConfigureAwait(true);
    }

    public Task InsertAsync(TModel entity, CancellationToken token)
    {
        var entities = new List<TModel>(1) { entity };

        return InsertAsync(entities, token);
    }

    public async Task InsertAsync(IEnumerable<TModel> entities, CancellationToken token)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TIMEOUT));
        using var bindCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);

        await client.PostAsJsonAsync($"{uri}/PostMany", entities, bindCts.Token)
                    .ConfigureAwait(true);
    }

    public Task UpdateAsync(TModel entity, CancellationToken token)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TIMEOUT));
        using var bindCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);

        throw new NotImplementedException();
    }

    public Task UpdateAsync(IEnumerable<TModel> entities, CancellationToken token)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TIMEOUT));
        using var bindCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);

        throw new NotImplementedException();
    }

    public Task DeleteAsync(TModel entity, CancellationToken token)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TIMEOUT));
        using var bindCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);

        throw new NotImplementedException();
    }

    public Task DeleteAsync(IEnumerable<TModel> entities, CancellationToken token)
    {
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TIMEOUT));
        using var bindCts = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, token);

        throw new NotImplementedException();
    }

    public void Dispose()
    {
        client.Dispose();
    }
}
