using Source.ViewModels;
using System;

namespace Source.Stores;

public class NavigationStore
{
    private BaseViewModel? _currentViewModel;

    public BaseViewModel? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }


    public event Action? CurrentViewModelChanged;
}
