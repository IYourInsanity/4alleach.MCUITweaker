using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities.Attributes;
using System.Data;
using System.Reflection;

namespace _4alleach.MCRecipeEditor.Database.Mappers;

//TODO Rework logic because it's cause perfomance
internal static class DataMapper
{
    static DataMapper()
    {

    }

    #region ToEntity

    public static IEnumerable<TEntity> Map<TEntity>(this DataTable table)
        where TEntity : Asset
    {
        var customAttributeType = typeof(DataNameAttribute);
        var type = typeof(TEntity);

        var properties = type.GetProperties().ToArray();
        var propertiesLength = properties.Length;

        var rows = table.Rows;
        var rowsCount = rows.Count;

        var entities = new TEntity[rowsCount];

        for (var i = 0; i < rowsCount; i++)
        {
            var entity = Activator.CreateInstance<TEntity>();
            var row = rows[i];

            for (int j = 0; j < propertiesLength; j++)
            {
                Map(row, properties[j], entity);
            }

            entities[i] = entity;
        }

        return entities;
    }

    private static void Map(DataRow row, PropertyInfo prop, object entity)
    {
        var name = prop.Name;

        if (row.Table.Columns.Contains(name))
        {
            var propertyValue = row[name];

            if (propertyValue != DBNull.Value)
            {
                ParsePrimitive(prop, entity, propertyValue);
            }
        }
    }

    private static void ParsePrimitive(PropertyInfo prop, object entity, object value)
    {
        var type = prop.PropertyType;

        if (value == null)
        {
            return;
        }

        if(type == typeof(int) || type == typeof(int?))
        {
            var intValue = int.Parse(value.ToString() ?? string.Empty);

            prop.SetValue(entity, intValue, null);
        }

        if (type == typeof(string))
        {
            var stringValue = value.ToString()!.Trim();

            prop.SetValue(entity, stringValue, null);
        }

        if (prop.PropertyType == typeof(Guid))
        {
            prop.SetValue(entity, value, null);
        }
    }

    #endregion

    #region ToTable

    public static DataTable Map<TEntity>(this TEntity entity, DataTable table)
        where TEntity : Asset
    {
        var type = typeof(TEntity);

        var properties = type.GetProperties().ToArray();
        var propertiesLength = properties.Length;

        var newRow = table.NewRow();

        for (int j = 0; j < propertiesLength; j++)
        {
            var property = properties[j];
            var name = property.Name;
            newRow[name] = property.GetValue(entity) ?? DBNull.Value;
        }

        table.Rows.Add(newRow);

        return table;
    }

    public static DataTable Map<TEntity>(this IEnumerable<TEntity> entities, DataTable table)
        where TEntity : Asset
    {
        foreach (var entity in entities)
        {
            Map<TEntity>(entity, table);
        }

        return table;
    }

    #endregion
}
