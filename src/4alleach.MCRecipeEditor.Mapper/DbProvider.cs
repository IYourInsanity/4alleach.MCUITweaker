using _4alleach.MCRecipeEditor.Database;
using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Mapper.Abstractions;

namespace _4alleach.MCRecipeEditor.Mapper;

internal sealed class DbProvider : IDbProvider, IDisposable
{
    internal readonly IDbContext dbContext;
    internal readonly IMapperRepository mapper;

    internal object? Destination { get; set; }

    internal DbProvider(IMapperRepository mapper)
    {
        this.mapper = mapper;
        this.dbContext = Entry.CreateContext();
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}
