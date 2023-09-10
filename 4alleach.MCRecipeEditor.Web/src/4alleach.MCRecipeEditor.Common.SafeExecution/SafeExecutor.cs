using _4alleach.MCRecipeEditor.Common.SafeExecution.Abstractions;
using _4alleach.MCRecipeEditor.Common.Type.Models.Results;
using Microsoft.Extensions.Logging;

namespace _4alleach.MCRecipeEditor.Common.SafeExecution;

public sealed class SafeExecutor : ISafeExecutor
{
    private readonly ILogger<SafeExecutor> _logger;

    public SafeExecutor(ILogger<SafeExecutor> logger)
    {
        _logger = logger;
    }

    public async Task<Result> ExecuteSafe(Func<Task<Result>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception happened.");
            return ex;
        }
    }

    public async Task<Result<A>> ExecuteSafe<A>(Func<Task<Result<A>>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception happened.");
            return ex;
        }
    }
}
