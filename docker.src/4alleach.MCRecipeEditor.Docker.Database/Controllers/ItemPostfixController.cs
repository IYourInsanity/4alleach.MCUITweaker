using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Controllers.Base;
using _4alleach.MCRecipeEditor.Docker.Database.Entities;

namespace _4alleach.MCRecipeEditor.Docker.Database.Controllers;

public class ItemPostfixController : BaseController<Item>
{
    public ItemPostfixController(IAssetsContext context)
        : base(context)
    {

    }
}
