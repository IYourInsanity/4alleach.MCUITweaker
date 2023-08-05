using _4alleach.MCRecipeEditor.Docker.Database.Controllers.Base;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _4alleach.MCRecipeEditor.Docker.Database.Controllers;

public class ItemController : BaseController<ItemRepository, Item>
{
    public ItemController(IAssetsContext context) : base(context)
    {
    }

    [HttpGet(nameof(GetAllWhereNameExist))]
    public async Task<ActionResult<IEnumerable<Item>>> GetAllWhereNameExist(CancellationToken token)
    {
        var handler = _context.BuildRepository<ItemRepository, Item>();
        var items = await handler.SelectWithConditionAsync(Specifications.Items.NameIsNotNull | Specifications.Items.DescriptionIsNotNull, token);

        if (items != null)
        {
            return Ok(items);
        }

        return NotFound();
    }
}
