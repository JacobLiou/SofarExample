using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace ui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider? _serviceProvider;

    private IHost? _host;

    public App()
    {
        //方式1
        //var serviceCollection = new ServiceCollection();
        //ConfigureServices(serviceCollection);
        //_serviceProvider = serviceCollection.BuildServiceProvider();

        //方式2
        _host = Host.CreateDefaultBuilder()
                     .ConfigureServices((context, services) =>
                     {
                         ConfigureServices(context, services);
                     })
                     .Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Register your services here
        //services.AddSingleton<MainWindow>();
        //services.AddTransient<IYourService, YourServiceImplementation>();
        // Add other services as needed
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // Register application services
        services.AddSingleton<MainWindow>();
        //services.AddTransient<IMyService, MyService>();
        // Add other services
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        //var host = HostBuilderContext
        //var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        //mainWindow.Show();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        if (_host != null)
        {
            await _host.StopAsync();
            _host.Dispose();
        }

        base.OnExit(e);
    }
}

