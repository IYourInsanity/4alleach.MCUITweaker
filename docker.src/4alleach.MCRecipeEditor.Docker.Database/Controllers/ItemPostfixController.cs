using _4alleach.MCRecipeEditor.Docker.Database.Controllers.Base;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Repositories;

namespace _4alleach.MCRecipeEditor.Docker.Database.Controllers;

public class ItemPostfixController : BaseController<ItemPostfixRepository, ItemPostfix>
{
    public ItemPostfixController(IAssetsContext context)
        : base(context)
    {

    }
}
