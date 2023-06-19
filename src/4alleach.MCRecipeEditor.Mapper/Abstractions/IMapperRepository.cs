namespace _4alleach.MCRecipeEditor.Mapper.Abstractions;

public interface IMapperRepository
{
    IModelEntityMapper GetMapper<TModel>();
}
