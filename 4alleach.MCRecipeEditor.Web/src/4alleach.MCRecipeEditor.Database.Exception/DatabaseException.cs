namespace _4alleach.MCRecipeEditor.Database.Exceptions;

public sealed class DatabaseException : Exception
{
    public DatabaseState State { get; }

    public DatabaseException(DatabaseState state, string message, Exception? innerException = null) : base(message, innerException)
    {
        State = state;
    }
}
