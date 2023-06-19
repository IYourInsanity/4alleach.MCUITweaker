using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Mappers;
using System.Collections.Concurrent;

namespace _4alleach.MCRecipeEditor.Database;
internal sealed class CommandRegistry
{
    private readonly ConcurrentDictionary<Type, string> _selectAllDictionary;
    private readonly ConcurrentDictionary<Type, string> _selectTopDictionary;

    private readonly ConcurrentDictionary<Type, string> _insertDictionary;
    private readonly ConcurrentDictionary<Type, string> _updateDictionary;
    private readonly ConcurrentDictionary<Type, string> _deleteDictionary;

    internal CommandRegistry()
    {
        _selectAllDictionary = new ConcurrentDictionary<Type, string>();
        _selectTopDictionary = new ConcurrentDictionary<Type, string>();

        _insertDictionary = new ConcurrentDictionary<Type, string>();
        _updateDictionary = new ConcurrentDictionary<Type, string>();
        _deleteDictionary = new ConcurrentDictionary<Type, string>();
    }

    internal void Register<TEntity>()
        where TEntity : Asset
    {
        var type = typeof(TEntity);

        _selectAllDictionary.TryAdd(type, CommandMapper.GenerateSelectAllCommand<TEntity>());
        _selectTopDictionary.TryAdd(type, CommandMapper.GenerateSelectTopCommand<TEntity>());

        _insertDictionary.TryAdd(type, CommandMapper.GenerateInsertCommand<TEntity>());
        _updateDictionary.TryAdd(type, CommandMapper.GenerateUpdateCommand<TEntity>());
        _deleteDictionary.TryAdd(type, CommandMapper.GenerateDeleteCommand<TEntity>());
    }

    internal string ClaimSelectAllCommand<TEntity>()
        where TEntity : Asset
    {
        return _selectAllDictionary[typeof(TEntity)];
    }

    internal string ClaimSelectTopCommand<TEntity>()
        where TEntity : Asset
    {
        return _selectTopDictionary[typeof(TEntity)];
    }

    internal string ClaimInsertCommand<TEntity>()
        where TEntity : Asset
    {
        return _insertDictionary[typeof(TEntity)];
    }

    internal string ClaimUpdateCommand<TEntity>()
        where TEntity : Asset
    {
        return _updateDictionary[typeof(TEntity)];
    }

    internal string ClaimDeleteCommand<TEntity>()
        where TEntity : Asset
    {
        return _deleteDictionary[typeof(TEntity)];
    }
}
