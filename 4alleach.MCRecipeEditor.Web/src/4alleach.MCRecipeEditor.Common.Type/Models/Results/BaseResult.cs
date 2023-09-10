namespace _4alleach.MCRecipeEditor.Common.Type.Models.Results;
public abstract record BaseResult
{
    public bool IsSuccess => Exception == null;

    public bool IsFaulted => Exception != null;

    public Exception? Exception { get; }

    protected BaseResult()
    {
    }

    protected BaseResult(Exception ex)
    {
        Exception = ex;
    }
}
