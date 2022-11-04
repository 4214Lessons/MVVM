using Source.Command;
using Source.Models;
using Source.Repositories.Abstracts;
using Source.Stores;
using System.Windows.Input;

namespace Source.ViewModels;

public class AddViewModel : BaseViewModel
{
    private readonly ICarRepository _carRepository;
    private readonly NavigationStore _navigationStore;



    public ICommand CancelCommand { get; set; }
    public ICommand SubmitCommand { get; set; }




    public AddViewModel(ICarRepository carRepository, NavigationStore navigationStore)
    {
        _carRepository = carRepository;
        _navigationStore = navigationStore;



        CancelCommand = new RelayCommand(ExecuteCancelCommand);
        SubmitCommand = new RelayCommand(ExecuteSubmitCommand);
    }


    void ExecuteSubmitCommand(object? parameter)
    {
        _carRepository.Add(new Car { Id = 4, Make = "Bmw", Model = "X7", Year = 2021 });
        _navigationStore.CurrentViewModel = new HomeViewModel(_carRepository, _navigationStore);
    }

    void ExecuteCancelCommand(object? parameter)
    {
        _navigationStore.CurrentViewModel = new HomeViewModel(_carRepository, _navigationStore);
    }


}
