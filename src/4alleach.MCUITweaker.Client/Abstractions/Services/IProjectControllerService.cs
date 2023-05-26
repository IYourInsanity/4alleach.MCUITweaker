namespace _4alleach.MCUITweaker.Client.Abstractions.Services;

internal interface IProjectControllerService : IService
{
    void CreateProject(string name);

    void LoadProject(string name);
}
