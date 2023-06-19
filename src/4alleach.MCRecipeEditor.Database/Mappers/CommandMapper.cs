using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities.Attributes;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Text;

namespace _4alleach.MCRecipeEditor.Database.Mappers;
internal static class CommandMapper
{
    private const string ID = "Id";
    private const string SEPARATOR = ", ";

    private const string APPEND_COLUMN = "\"{0}\"";
    private const string APPEND_PROPERTY = "\"{0}\" = @{1}";

    internal static string GenerateUpdateCommand<TEntity>()
        where TEntity : Asset
    {
        var type = typeof(TEntity);
        var tableName = type.Name;
        var properties = type.GetProperties().Select(_ => _.Name).ToArray();

        var set = new StringBuilder();
        var where = new StringBuilder();

        where.Append(" WHERE ");

        for (var i = 0; i < properties.Length; i++)
        {
            var property = properties[i];

            if (property.Equals(ID))
            {
                where.AppendFormat(APPEND_PROPERTY, property, property);
                continue;
            }

            set.AppendFormat(APPEND_PROPERTY, property, property);
            set.AppendFormat(SEPARATOR);
        }

        var setString = set.ToString().TrimEnd(SEPARATOR.ToCharArray());

        return $"UPDATE {tableName} SET {setString}{where}"; 
    }

    internal static string GenerateDeleteCommand<TEntity>()
        where TEntity : Asset
    {
        var type = typeof(TEntity);
        var tableName = type.Name;
        var where = new StringBuilder();

        where.Append(" WHERE ");
        where.AppendFormat(APPEND_PROPERTY, ID, ID);

        return $"DELETE FROM {tableName}{where};";
    }

    internal static string GenerateInsertCommand<TEntity>()
        where TEntity : Asset
    {
        var type = typeof(TEntity);
        var tableName = type.Name;

        var columns = new StringBuilder();
        var parameters = new StringBuilder();

        var properties = type.GetProperties().Select(_ => _.Name).ToArray();

        for (var i = 0; i < properties.Length; i++)
        {
            var property = properties[i];

            columns.AppendFormat(APPEND_COLUMN, property);
            columns.AppendFormat(SEPARATOR);

            parameters.AppendFormat(APPEND_PROPERTY, property, property);
            parameters.AppendFormat(SEPARATOR);
        }

        var columnsString = columns.ToString().TrimEnd(SEPARATOR.ToCharArray());
        var parametersString = parameters.ToString().TrimEnd(SEPARATOR.ToCharArray());

        return $"INSERT INTO [{tableName}] ({columnsString}) VALUES ({parametersString});";
    }

    internal static string GenerateSelectAllCommand<TEntity>()
        where TEntity : Asset
    {
        var type = typeof(TEntity);
        var tableName = type.Name;

        var columns = new StringBuilder();
        var properties = type.GetProperties().Select(_ => _.Name).ToArray();

        for (var i = 0; i < properties.Length; i++)
        {
            var property = properties[i];

            columns.AppendFormat(APPEND_COLUMN, property);
            columns.AppendFormat(SEPARATOR);
        }

        var columnsString = columns.ToString().TrimEnd(SEPARATOR.ToCharArray());

        return $"SELECT {columnsString} FROM {tableName}";
    }

    internal static string GenerateSelectTopCommand<TEntity>()
        where TEntity : Asset
    {
        var commandAll = GenerateSelectAllCommand<TEntity>();

        var commandTopBuilder = new StringBuilder();

        commandTopBuilder.Append(commandAll);
        commandTopBuilder.Append(" LIMIT {0}");

        return commandTopBuilder.ToString();
    }

    internal static void SetupCollection<TEntity>(this SQLiteCommand command, TEntity entity)
        where TEntity : Asset
    {
        var collection = command.Parameters;
        var properties = typeof(TEntity).GetProperties().ToArray();

        for (var i = 0; i < properties.Length; i++)
        {
            var property = properties[i];
            var name = $"@{property.Name}";
            var value = property.GetValue(entity);

            var dbType = property.GetCustomAttributes<DbTypeAttribute>(false).FirstOrDefault();
            var parameter = command.CreateParameter();

            parameter.ParameterName = name;
            parameter.DbType = dbType!.Value;
            parameter.Value = value;
            parameter.SourceColumn = name;

            collection.Add(parameter);
        }
    }

    internal static string Compile<TEntity>(this string rawCommand, TEntity entity)
        where TEntity : Asset
    {
        var properties = typeof(TEntity).GetProperties().ToArray();

        for (var i = 0; i < properties.Length; i++)
        {
            var property = properties[i];

            var name = $"@{property.Name}";
            var value = property.GetValue(entity);

            rawCommand = rawCommand.Replace(name, GetValue(value));
        }

        return rawCommand;
    }

    private static dynamic GetValue(object? value)
    {
        if (value == null)
        {
            return "\"\"";
        }

        if(value is Guid ||
           value is string)
        {
            return $"\'{value}\'";
        }

        return value;
    }
}
