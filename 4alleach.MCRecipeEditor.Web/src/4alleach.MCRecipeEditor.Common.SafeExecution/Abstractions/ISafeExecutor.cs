using _4alleach.MCRecipeEditor.Common.Type.Models.Results;

namespace _4alleach.MCRecipeEditor.Common.SafeExecution.Abstractions;

public interface ISafeExecutor
{
    Task<Result> ExecuteSafe(Func<Task<Result>> action);

    Task<Result<A>> ExecuteSafe<A>(Func<Task<Result<A>>> action);
}
