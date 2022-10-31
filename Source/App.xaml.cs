using Source.Repositories.Abstracts;
using Source.Repositories.Concretes;
using Source.ViewModels;
using Source.Views;
using System.Windows;

namespace Source;

public partial class App : Application
{
    void ApplicationStartup(object sender, StartupEventArgs e)
    {
        ICarRepository _carRepository = new FakeCarRepository();
        MainViewModel mainViewModel = new(_carRepository);

        MainView mainView = new();
        mainView.DataContext = mainViewModel;


        mainView.Show();
    }
}