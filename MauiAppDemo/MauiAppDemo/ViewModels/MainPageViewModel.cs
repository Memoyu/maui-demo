using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppDemo.Services;

namespace MauiAppDemo.ViewModels;

public class MainPageViewModel : ObservableObject
{
    private readonly IKeyValueStorage _keyValueStorage;

    public MainPageViewModel(IKeyValueStorage keyValueStorage)
    {
        _keyValueStorage = keyValueStorage;
    }
    
    private string _result;
    public string Result
    {
        get => _result;
        set => SetProperty(ref _result, value);
    }

    private RelayCommand _clickMeCommand;
    public RelayCommand ClickMeCommand => _clickMeCommand ??= new RelayCommand(() => Result = "Hello Word");

    private string _value;
    public string Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }
    
    private RelayCommand _readCommand;
    public RelayCommand ReadCommand =>
        _readCommand ??= new RelayCommand(() => Value = _keyValueStorage.Get("my_key", string.Empty));
    
    private RelayCommand _writeCommand;
    public RelayCommand WriteCommand =>
        _writeCommand ??= new RelayCommand(() => _keyValueStorage.Set("my_key", Value));
}