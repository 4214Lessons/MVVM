using Microsoft.Extensions.Configuration;
using Source.Repositories.Abstracts;
using Source.Repositories.Concretes;
using Source.ViewModels;
using Source.Views;
using System.Windows;

namespace Source;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();


        var key = configuration.GetSection("omdbApiKey").Value;
        var conStr = configuration.GetConnectionString("myConStr1");
        MessageBox.Show(key);
        MessageBox.Show(conStr);





        ICarRepository _carRepository = new FakeCarRepository();
        MainViewModel mainViewModel = new(_carRepository);

        MainView mainView = new();
        mainView.DataContext = mainViewModel;




        mainView.Show();
    }
}