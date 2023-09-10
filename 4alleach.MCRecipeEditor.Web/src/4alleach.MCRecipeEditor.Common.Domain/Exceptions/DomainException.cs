using _4alleach.MCRecipeEditor.Common.Domain.Models;

namespace _4alleach.MCRecipeEditor.Common.Domain.Exceptions;

public sealed class DomainException : Exception
{
    public DomainState State { get; }

    public DomainException(DomainState state, string message, Exception innerException) : base(message, innerException)
    {
        State = state;
    }
}
