using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Controllers.Base;
using _4alleach.MCRecipeEditor.Docker.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _4alleach.MCRecipeEditor.Docker.Database.Controllers;

public class ItemController : BaseController<Item>
{
    public ItemController(IAssetsContext context) : base(context)
    {
    }

    [HttpGet(nameof(GetAllWhereNameExist))]
    public async Task<ActionResult<IEnumerable<Item>>> GetAllWhereNameExist(CancellationToken token)
    {
        var handler = _context.CreateHandler<Item>();
        var items = await handler.SelectWithConditionAsync(Specifications.Items.NameIsNotNull | Specifications.Items.DescriptionIsNull, token);

        if (items != null)
        {
            return Ok(items);
        }

        return NotFound();
    }
}
