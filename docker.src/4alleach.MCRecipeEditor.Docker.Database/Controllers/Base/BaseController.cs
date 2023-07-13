using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Dynamic.Core;

namespace _4alleach.MCRecipeEditor.Docker.Database.Controllers.Base;

[ApiController, Route("api/[controller]")]
public abstract class BaseController<TAsset> : Controller
    where TAsset : Asset
{
    private readonly IAssetsContext _context;

    public BaseController(IAssetsContext context)
    {
        _context = context;
    }

    #region Post

    [HttpPost(nameof(Post))]
    public async Task<ActionResult<TAsset>> Post(string data, CancellationToken token)
    {
        var entity = JsonConvert.DeserializeObject<TAsset>(data);

        if (entity == null)
        {
            return BadRequest();
        }

        var handler = _context.CreateHandler<TAsset>();
        await handler.InsertAsync(entity, token);

        return CreatedAtAction(nameof(Post), entity);
    }

    [HttpPost(nameof(PostMany))]
    public async Task<ActionResult<IEnumerable<TAsset>>> PostMany(string data, CancellationToken token)
    {
        var entities = JsonConvert.DeserializeObject<IEnumerable<TAsset>>(data);

        if (entities == null)
        {
            return BadRequest();
        }

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

        return BadRequest();
    }

    [HttpGet(nameof(GetWithCondition))]
    public async Task<ActionResult<IEnumerable<TAsset>>> GetWithCondition(string condition, CancellationToken token)
    {
        var handler = _context.CreateHandler<TAsset>();

        var exp = DynamicExpressionParser.ParseLambda<TAsset, bool>(null, true, condition)
                                         .Compile(true);

        var items = await handler.SelectWithConditionAsync(exp, token);

        if (items != null)
        {
            return Ok(items);
        }

        return BadRequest();
    }

    #endregion

    #region Put

    [HttpPut(nameof(Put))]
    public async Task<ActionResult<bool>> Put(string data, CancellationToken token)
    {
        var entity = JsonConvert.DeserializeObject<TAsset>(data);

        if (entity == null)
        {
            return BadRequest();
        }

        var handler = _context.CreateHandler<TAsset>();

        try
        {
            await handler.UpdateAsync(entity, token);
            return Ok(true);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        } 
    }

    [HttpPut(nameof(PutMany))]
    public async Task<ActionResult<bool>> PutMany(string data, CancellationToken token)
    {
        var entities = JsonConvert.DeserializeObject<IEnumerable<TAsset>>(data);

        if (entities == null)
        {
            return BadRequest();
        }

        var handler = _context.CreateHandler<TAsset>();

        try
        {
            await handler.UpdateAsync(entities, token);
            return Ok(true);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    #endregion

    #region Delete

    [HttpDelete(nameof(Delete))]
    public async Task<ActionResult<bool>> Delete(string data, CancellationToken token)
    {
        var entity = JsonConvert.DeserializeObject<TAsset>(data);

        if (entity == null)
        {
            return BadRequest();
        }

        var handler = _context.CreateHandler<TAsset>();

        try
        {
            await handler.DeleteAsync(entity, token);
            return Ok(true);
        }
        //TODO Rework Exception
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpDelete(nameof(DeleteMany))]
    public async Task<ActionResult<bool>> DeleteMany(string data, CancellationToken token)
    {
        var entities = JsonConvert.DeserializeObject<IEnumerable<TAsset>>(data);

        if (entities == null)
        {
            return BadRequest();
        }

        var handler = _context.CreateHandler<TAsset>();

        try
        {
            await handler.DeleteAsync(entities, token);
            return Ok(true);
        }
        //TODO Rework Exception
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    #endregion
}
