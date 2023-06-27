using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Database.Mapper;
using _4alleach.MCRecipeEditor.Database.Mapper.Abstractions;
using _4alleach.MCRecipeEditor.Database.Provider.Abstractions;

namespace _4alleach.MCRecipeEditor.Database.Provider;

public sealed class DatabaseProvider : IDatabaseProvider
{
    internal readonly IDbContext context;
    internal readonly IMapperRepository mapper;

    public DatabaseProvider()
    {
        this.mapper = new MapperRepository();
        this.context = Entry.CreateContext();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
