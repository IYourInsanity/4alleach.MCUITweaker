using _4alleach.MCRecipeEditor.Docker.Database.Controllers.Base;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;

namespace _4alleach.MCRecipeEditor.Docker.Database.Controllers;

public class ItemPrefixController : BaseController<Item>
{
    public ItemPrefixController(IAssetsContext context)
        : base(context)
    {

    }
}
