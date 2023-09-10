namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public interface IServiceHub
{
    TService Get<TService>() 
        where TService : class, IService;
}
