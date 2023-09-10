
namespace _4alleach.MCRecipeEditor.Client.Helpers;
internal static class ThreadPoolConfigurationHelper
{
    internal static void ConfigureThreadPool(int divider = 16)
    {
        ThreadPool.GetMinThreads(out var minWorkerThreads, out var minIo);
        ThreadPool.GetMaxThreads(out var maxWorkerThreads, out _);
        ThreadPool.SetMinThreads(minWorkerThreads + (maxWorkerThreads - minWorkerThreads) / divider, minIo);
    }
}
