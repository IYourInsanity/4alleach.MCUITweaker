using _4alleach.MCRecipeEditor.Common.Domain.Exceptions;
using _4alleach.MCRecipeEditor.Common.Domain.Models;
using _4alleach.MCRecipeEditor.Common.Type.Models.Results;
using _4alleach.MCRecipeEditor.Database.Exceptions;

namespace _4alleach.MCRecipeEditor.Common.Domain.Extensions;

public static class DomainExceptionExtension
{
    public static Result ToDomain(this Result result)
    {
        if (result.IsSuccess) return result;

        var exception = result.Exception!;

        return exception switch
        {
            DatabaseException dbException => dbException.ToDomain(),
            _ => exception.ToDomain(),
        };
    }

    private static DomainException ToDomain(this DatabaseException exception)
    {
        var state = DomainState.Unknown;

        switch (exception.State)
        {
            case DatabaseState.NotFound:

                state = DomainState.NotFound;

                break;
            case DatabaseState.DuplicateRecord:

                state = DomainState.Duplicate;

                break;
            case DatabaseState.ConnectionRefused:

                state = DomainState.ConnectionRefused;

                break;
        }

        return new(state, exception.Message, exception);
    }

    private static DomainException ToDomain(this Exception exception)
    {
        return new(DomainState.NotDefined, exception.Message, exception);
    }
}
