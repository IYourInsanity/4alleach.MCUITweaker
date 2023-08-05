using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;

public interface IRepositoryCollection
{
    TRepository Build<TRepository, TAsset>(DbContext dbContext)
        where TRepository : IBaseRepository<TAsset>
        where TAsset : Asset;
}
