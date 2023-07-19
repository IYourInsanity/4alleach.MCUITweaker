using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace _4alleach.MCRecipeEditor.Docker.Database.Controllers.Base;

[ApiController, Route("[controller]")]
public abstract class BaseController<TAsset> : Controller
    where TAsset : Asset
{
    protected readonly IAssetsContext _context;

    public BaseController(IAssetsContext context)
    {
        _context = context;
    }

    #region Post

    [HttpPost(nameof(Post))]
    public async Task<ActionResult<TAsset>> Post(TAsset entity, CancellationToken token)
    {
        var handler = _context.CreateHandler<TAsset>();
        await handler.InsertAsync(entity, token);

        return CreatedAtAction(nameof(Post), entity);
    }

    [HttpPost(nameof(PostMany))]
    public async Task<ActionResult<IEnumerable<TAsset>>> PostMany(IEnumerable<TAsset> entities, CancellationToken token)
    {
        var handler = _context.CreateHandler<TAsset>();
        await handler.InsertAsync(entities, token);

        return CreatedAtAction(nameof(PostMany), entities);
    }

    #endregion

    #region Get

    [HttpGet(nameof(GetAll))]
    public async Task<ActionResult<IEnumerable<TAsset>>> GetAll(CancellationToken token)
    {
        var handler = _context.CreateHandler<TAsset>();
        var items = await handler.SelectAllAsync(token);

        if (items != null)
        {
            return Ok(items);
        }

        return NoContent();
    }

    [HttpGet(nameof(GetWithCondition))]
    public async Task<ActionResult<IEnumerable<TAsset>>> GetWithCondition(string condition, CancellationToken token)
    {
        var handler = _context.CreateHandler<TAsset>();
        var exp = DynamicExpressionParser.ParseLambda<TAsset, bool>(null, true, condition);
        var items = await handler.SelectWithConditionAsync(exp, token);

        if (items != null)
        {
            return Ok(items);
        }

        return NoContent();
    }

    #endregion

    #region Put

    [HttpPut(nameof(Put))]
    public async Task<ActionResult<bool>> Put(TAsset entity, CancellationToken token)
    {
        var handler = _context.CreateHandler<TAsset>();
        await handler.UpdateAsync(entity, token);
        return Ok(true);
    }

    [HttpPut(nameof(PutMany))]
    public async Task<ActionResult<bool>> PutMany(IEnumerable<TAsset> entities, CancellationToken token)
    {
        var handler = _context.CreateHandler<TAsset>();
        await handler.UpdateAsync(entities, token);
        return Ok(true);
    }

    #endregion

    #region Delete

    [HttpDelete(nameof(Delete))]
    public async Task<ActionResult<bool>> Delete(TAsset entity, CancellationToken token)
    {
        var handler = _context.CreateHandler<TAsset>();
        await handler.DeleteAsync(entity, token);
        return Ok(true);
    }

    [HttpDelete(nameof(DeleteMany))]
    public async Task<ActionResult<bool>> DeleteMany(IEnumerable<TAsset> entities, CancellationToken token)
    {
        var handler = _context.CreateHandler<TAsset>();
        await handler.DeleteAsync(entities, token);
        return Ok(true);
    }

    #endregion
}
