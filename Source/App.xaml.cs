using Autofac;
using Microsoft.Extensions.Configuration;
using Source.Repositories.Abstracts;
using Source.Repositories.Concretes;
using Source.Stores;
using Source.ViewModels;
using Source.Views;
using System.Windows;

namespace Source;

public partial class App : Application
{
    public static IContainer? Container { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();


        // var key = configuration.GetSection("omdbApiKey").Value;
        // var conStr = configuration.GetConnectionString("myConStr1");





        // IoC container

        NavigationStore navigationStore = new();

        var builder = new ContainerBuilder();

        builder.RegisterType<MainViewModel>();
        builder.RegisterType<HomeViewModel>();


        builder.RegisterInstance(navigationStore)
            .SingleInstance();


        builder.RegisterType<FakeCarRepository>()
            .As<ICarRepository>()
            .SingleInstance();

       Container = builder.Build();





        navigationStore.CurrentViewModel = Container.Resolve<HomeViewModel>();




        MainView mainView = new();
        mainView.DataContext = Container.Resolve<MainViewModel>();
        mainView.Show();
    }
}