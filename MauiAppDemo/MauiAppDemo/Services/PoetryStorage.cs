using MauiAppDemo.Models;
using SQLite;

namespace MauiAppDemo.Services;

public class PoetryStorage : IPoetryStorage
{
    public const string DbFileName = "poetrydb.sqlite3";

    public static readonly string DbFilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbFileName);

    private SQLiteAsyncConnection _connection;

    public SQLiteAsyncConnection Connection => _connection ??= new SQLiteAsyncConnection(DbFileName);
    
    public async Task InitializeAsync()
    {
       await Connection.CreateTableAsync<Poetry>();
    }

    public async Task AddAsync(Poetry poetry)
    {
        await Connection.InsertAsync(poetry);
    }

    public async Task<IEnumerable<Poetry>> ListAsync()
    {
        return await Connection.Table<Poetry>().ToListAsync();
    }
}