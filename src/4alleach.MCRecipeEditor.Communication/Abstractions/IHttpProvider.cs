using _4alleach.MCRecipeEditor.Models.Database.Base;

namespace _4alleach.MCRecipeEditor.Communication.Abstractions;

public interface IHttpProvider
{
    ICommunicationHandler<TModel> UseHandler<TModel>()
        where TModel : Asset;
}
