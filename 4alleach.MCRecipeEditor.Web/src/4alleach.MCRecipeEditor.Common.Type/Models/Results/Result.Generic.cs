namespace _4alleach.MCRecipeEditor.Common.Type.Models.Results;
public sealed record Result<A> : BaseResult
{
    public A? Value { get; }

    public Result() : base() { }

    public Result(A val) : base()
    {
        Value = val;
    }

    public Result(Exception ex) : base(ex)
    {
    }

    public static implicit operator Result<A>(Exception ex)
    {
        return new Result<A>(ex);
    }

    public static implicit operator Result<A>(A val)
    {
        return new Result<A>(val);
    }

    public readonly static Result Success = new();
}
