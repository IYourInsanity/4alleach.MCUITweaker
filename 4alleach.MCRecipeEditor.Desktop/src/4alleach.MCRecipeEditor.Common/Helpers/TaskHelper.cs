namespace _4alleach.MCRecipeEditor.Common.Helpers;

public static class TaskHelper
{
    public static void RunWithDelay(Action action, TimeSpan span, CancellationToken token)
    {
        Task.Run(async () =>
        {
            await Task.Delay(span, token);

            action();

        }, token);
    }
}
