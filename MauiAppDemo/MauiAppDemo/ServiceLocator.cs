using MauiAppDemo.Services;
using MauiAppDemo.ViewModels;

namespace MauiAppDemo;

public class ServiceLocator
{
    private ServiceProvider _serviceProvider;

    /// <summary>
    /// MainPageViewModel 注入
    /// </summary>
    public MainPageViewModel MainPageViewModel => _serviceProvider.GetService<MainPageViewModel>();

    public ServiceLocator()
    {
        var serviceCollection = new ServiceCollection();

        // 注册单例MainPageViewModel
        serviceCollection.AddSingleton<MainPageViewModel>();
        serviceCollection.AddScoped<IKeyValueStorage, KeyValueStorage>();
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}