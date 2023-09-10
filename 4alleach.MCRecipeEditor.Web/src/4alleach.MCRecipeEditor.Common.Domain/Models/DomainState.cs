namespace _4alleach.MCRecipeEditor.Common.Domain.Models;

public enum DomainState : byte
{
    Unknown = 0,
    NotFound = 1,
    Duplicate = 2,
    ConnectionRefused = 3,
    NotDefined = 4,
}
