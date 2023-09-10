namespace _4alleach.MCRecipeEditor.Common.Type.Models.Results;
public sealed record Result : BaseResult
{
    public Result() : base() { }

    public Result(Exception ex) : base(ex) { }

    public static implicit operator Result(Exception ex)
    {
        return new Result(ex);
    }

    public readonly static Result Success = new();
}
