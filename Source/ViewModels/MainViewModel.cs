using Source.Command;
using Source.Models;
using Source.Repositories.Abstracts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Source.ViewModels;

public class MainViewModel
{
    private readonly ICarRepository _carRepository;


    public ObservableCollection<Car> Cars { get; set; }
    public Car? SelectedCar { get; set; }


    public ICommand ShowCommand { get; set; }
    // public ICommand AddCommand { get; set; }
    // public ICommand UpdateCommand { get; set; }
    // public ICommand DeleteCommand { get; set; }



    public MainViewModel(ICarRepository carRepository)
    {
        _carRepository = carRepository;
        Cars = new(_carRepository.GetList() ?? new List<Car>());

        ShowCommand = new RelayCommand(ExecuteShowCommand, CanExecuteShowCommand);
    }

    void ExecuteShowCommand(object? parameter)
        => MessageBox.Show(SelectedCar?.Model);


    bool CanExecuteShowCommand(object? parameter)
        => SelectedCar is not null;

}
