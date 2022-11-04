using Source.Stores;

namespace Source.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    public BaseViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        navigationStore.CurrentViewModelChanged += NavigationStore_CurrentViewModelChanged;
    }

    private void NavigationStore_CurrentViewModelChanged()
     => NotifyPropertyChanged(nameof(CurrentViewModel));
}
