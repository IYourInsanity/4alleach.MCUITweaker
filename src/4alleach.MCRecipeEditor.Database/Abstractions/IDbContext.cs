using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;

namespace _4alleach.MCRecipeEditor.Database.Abstractions;

public interface IDbContext : IDisposable
{
    IBaseQueryHandler CreateHandler(Type sourceType);
}
