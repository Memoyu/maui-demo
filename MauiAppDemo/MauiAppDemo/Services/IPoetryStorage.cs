using MauiAppDemo.Models;

namespace MauiAppDemo.Services;

public interface IPoetryStorage
{
    Task InitializeAsync();

    Task AddAsync(Poetry poetry);

    Task<IEnumerable<Poetry>> ListAsync();
}