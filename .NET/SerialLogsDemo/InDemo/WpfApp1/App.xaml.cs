using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceCollection _serviceCollection = new ServiceCollection();

        public static ServiceProvider? ServicesProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //_services.AddLogging(builder => builder.AddLog4Net());
            ConfigureServices(_serviceCollection);
            ServicesProvider = _serviceCollection.BuildServiceProvider();

            var mainWindow = ServicesProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddLog4Net("log4net.config");
            });

            services.AddTransient(typeof(MainWindow));
            // 注册其他服务...
        }

    }

}
