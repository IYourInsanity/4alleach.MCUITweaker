using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;

public interface IQueryHandlerRepository
{
    IQueryHandler<TAsset> Build<TAsset>(DbContext dbContext)
        where TAsset : Asset;
}
