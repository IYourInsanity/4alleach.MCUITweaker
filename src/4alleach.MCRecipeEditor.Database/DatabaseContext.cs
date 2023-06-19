using _4alleach.MCRecipeEditor.Common.Extensions;
using _4alleach.MCRecipeEditor.Common.Helpers;
using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Database.Constants;
using _4alleach.MCRecipeEditor.Database.Entities;
using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Mappers;
using System.Data;
using System.Data.SQLite;
using System.Text;

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
            DefaultTimeout = 30,
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
        commandRegistry.Register<ItemType>();
        commandRegistry.Register<ItemPostfix>();
        commandRegistry.Register<ItemPrefix>();
        commandRegistry.Register<ModType>();
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

        await ExecuteAdapter(script, (connection, adapter) =>
        {
            adapter.SelectCommand = CreateCommand(script, connection);

            _ = new SQLiteCommandBuilder(adapter);

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
        var script = commandRegistry.ClaimInsertCommand<TEntity>().Compile(entity);

        await ExecuteNonQueryAsync(script, command =>
        {
            result = command.ExecuteNonQuery();
        });

        return result;
    }

    public async Task<int> Insert<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : Asset
    {
        //TODO Implement BulkCopy

        var result = 0;

        var strScriptBuild = new StringBuilder();
        var claimedCommand = commandRegistry.ClaimInsertCommand<TEntity>();

        foreach (var entity in entities)
        {
            var script = claimedCommand.Compile(entity);

            strScriptBuild.AppendLine(script);
        }

        await ExecuteNonQueryAsync(strScriptBuild.ToString(), command =>
        {
            result = command.ExecuteNonQuery();
        });

        return result;
    }

    #endregion

    #region UPDATE

    public async Task<int> Update<TEntity>(TEntity entity)
        where TEntity : Asset
    {
        var result = 0;
        var script = commandRegistry.ClaimUpdateCommand<TEntity>().Compile(entity);

        await ExecuteNonQueryAsync(script, command =>
        {
            result = command.ExecuteNonQuery();
        });

        return result;
    }

    public async Task<int> Update<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : Asset
    {
        var result = 0;

        var strScriptBuild = new StringBuilder();
        var claimedCommand = commandRegistry.ClaimUpdateCommand<TEntity>();

        foreach (var entity in entities)
        {
            var script = claimedCommand.Compile(entity);

            strScriptBuild.AppendLine(script);
        }

        await ExecuteNonQueryAsync(strScriptBuild.ToString(), command =>
        {
            result = command.ExecuteNonQuery();
        });

        return result;
    }

    #endregion

    public async Task<int> Delete<TEntity>(TEntity entity) where TEntity : Asset
    {
        var result = 0;
        var script = commandRegistry.ClaimDeleteCommand<TEntity>().Compile(entity);

        await ExecuteNonQueryAsync(script, command =>
        {
            result = command.ExecuteNonQuery();
        });

        return result;
    }

    public Task<int> Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : Asset
    {
        throw new NotImplementedException();
    }

    #region DEFAULT

    private Task ExecuteNonQueryAsync(string script)
    {
        return MakeSessionAsync(connection =>
        {
            MakeCommand(script, connection, command =>
            {
                command.ExecuteNonQuery();
            });
        });
    }

    private Task ExecuteNonQueryAsync(string script, Action<SQLiteCommand> action)
    {
        return MakeSessionAsync(connection =>
        {
            MakeCommand(script, connection, action);
        });
    }

    private Task ExecuteReader<TResult>(string script, Func<SQLiteDataReader, TResult> func)
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

    private Task ExecuteAdapter(string script, Action<SQLiteConnection, SQLiteDataAdapter> action)
    {
        return MakeSessionAsync(connection =>
        {
            MakeCommand(script, connection, command =>
            {
                using (var adapter = new SQLiteDataAdapter(command))
                {
                    action(connection, adapter);
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
