namespace _4alleach.MCRecipeEditor.Database.Exceptions;

public enum DatabaseState : byte
{
    Unknown = 0,
    NotFound = 1,
    DuplicateRecord = 2,
    ConnectionRefused = 3
}
