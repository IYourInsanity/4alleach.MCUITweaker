using _4alleach.MCRecipeEditor.Common.Extensions;
using _4alleach.MCRecipeEditor.Common.Helpers;
using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Database.Constants;
using _4alleach.MCRecipeEditor.Database.Entities;
using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Mappers;
using System.Data;
using System.Data.SQLite;

namespace _4alleach.MCRecipeEditor.Database;

internal class DatabaseContext : IDatabaseContext
{
    private const string Extension = ".db";
    private const string Asset = "4alleach.Asset";
    private const string Folder = "Assets";

    private readonly CommandRegistry commandRegistry;

    private string connectionString;
    

    private string SourceName => $"{Asset}{Extension}";
    private string FolderPath => Path.Combine(FileHelper.RootPath, Folder);
    private string AssetPath => Path.Combine(FolderPath, SourceName);

    internal DatabaseContext()
    {
        connectionString = string.Empty;
        commandRegistry = new CommandRegistry();
    }

    public async void Initialize()
    {
        connectionString = new SQLiteConnectionStringBuilder()
        {
            DataSource = AssetPath,
            DefaultTimeout = 5,
            Pooling = true,
            BinaryGUID = false,
            DateTimeKind = DateTimeKind.Utc,
            JournalMode = SQLiteJournalModeEnum.Wal,
            SyncMode = SynchronizationModes.Normal,
            CacheSize = 8_192_000,
            Version = 3
        }.ToString();

        if (FileHelper.IsExist(AssetPath) == false)
        {
            if(FolderHelper.IsExist(FolderPath) == false)
            {
                FolderHelper.Create(FolderPath);
            }

            await ExecuteNonQueryAsync(DBCreateScripts.Asset);
            await ExecuteNonQueryAsync(DBCreateScripts.AssetTestItem);
        }
        else if (await TestConnection() == false)
        {
            throw new NotImplementedException();
        }

        commandRegistry.Register<Item>();
    }

    public async Task<bool> TestConnection()
    {
        var result = false;

        await MakeSessionAsync(connection =>
        {
            result = true;
        });

        return result;
    }

    #region SELECT

    public Task<IEnumerable<TEntity>?> SelectAll<TEntity>()
        where TEntity : Asset
    {
        var script = commandRegistry.ClaimSelectAllCommand<TEntity>();

        return SelectInternal<TEntity>(script);
    }

    public Task<IEnumerable<TEntity>?> SelectTop<TEntity>(int count)
        where TEntity : Asset
    {
        var script = commandRegistry.ClaimSelectTopCommand<TEntity>().Format(count);

        return SelectInternal<TEntity>(script);
    }

    public Task<IEnumerable<TEntity>?> SelectCustom<TEntity>(string script)
        where TEntity : Asset
    {
        return SelectInternal<TEntity>(script);
    }

    private async Task<IEnumerable<TEntity>?> SelectInternal<TEntity>(string script)
        where TEntity : Asset
    {
        var name = typeof(TEntity).Name;
        var entities = default(IEnumerable<TEntity>);

        await ExecuteAdapter(script, adapter =>
        {
            using (var table = new DataTable(name))
            {
                adapter.Fill(table);
                entities = table.Map<TEntity>();
            }
        });

        return entities;
    }

    #endregion

    #region INSERT

    public async Task<int> Insert<TEntity>(TEntity entity)
        where TEntity : Asset
    {
        var result = 0;
        var name = typeof(TEntity).Name;
        var script = commandRegistry.ClaimSelectAllCommand<TEntity>();

        await ExecuteAdapter(script, adapter =>
        {
            using (var table = new DataTable(name))
            {
                adapter.FillSchema(table, SchemaType.Source);

                var tt = entity.Map(table);
                result = adapter.Update(tt);
            }
        });

        return result;
    }

    public async Task<int> Insert<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : Asset
    {
        var result = 0;
        var name = typeof(TEntity).Name;
        var script = commandRegistry.ClaimSelectAllCommand<TEntity>();

        //TODO Implement BulkCopy

        await ExecuteAdapter(script, adapter =>
        {
            using (var table = new DataTable(name))
            {
                adapter.FillSchema(table, SchemaType.Source);

                var tt = entities.Map(table);
                result = adapter.Update(tt);
            }
        });

        return result;
    }

    #endregion

    public Task<int> Update<TEntity>(TEntity entity) where TEntity : Asset
    {
        throw new NotImplementedException();
    }

    public Task<int> Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : Asset
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete<TEntity>(TEntity entity) where TEntity : Asset
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : Asset
    {
        throw new NotImplementedException();
    }

    #region DEFAULT

    public Task ExecuteNonQueryAsync(string script)
    {
        return MakeSessionAsync(connection =>
        {
            MakeCommand(script, connection, command =>
            {
                command.ExecuteNonQuery();
            });
        });
    }

    public Task ExecuteNonQueryAsync(string script, Action<SQLiteCommand> action)
    {
        return MakeSessionAsync(connection =>
        {
            MakeCommand(script, connection, action);
        });
    }

    public Task ExecuteReader<TResult>(string script, Func<SQLiteDataReader, TResult> func)
    {
        return MakeSessionAsync(connection =>
        {
            MakeCommand(script, connection, command =>
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read() == true)
                    {
                        func(reader);
                    }
                }
            });
        });
    }

    public Task ExecuteAdapter(string script, Action<SQLiteDataAdapter> action)
    {
        return MakeSessionAsync(connection =>
        {
            MakeCommand(script, connection, command =>
            {
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    _ = new SQLiteCommandBuilder(adapter);

                    action(adapter);
                }
            });
        });
    }

    #endregion

    private async Task MakeSessionAsync(Action<SQLiteConnection> action)
    {
        using (var connection = CreateConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();
                action(connection);
            }
            catch (Exception)
            {

            }
            finally
            {
                await connection.CloseAsync();
            }
        }
    }

    private void MakeCommand(string script, SQLiteConnection connection, Action<SQLiteCommand> action)
    {
        using (var command = new SQLiteCommand(script, connection))
        {
            try
            {
                action(command);
            }
            catch (Exception)
            {

            }
            finally
            {

            }
        }
    }

    private static SQLiteConnection CreateConnection(string connectionString)
    {
        try
        {
            return new SQLiteConnection(connectionString);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static SQLiteCommand CreateCommand(string script, SQLiteConnection connection)
    {
        return new SQLiteCommand(script, connection);
    }
}
