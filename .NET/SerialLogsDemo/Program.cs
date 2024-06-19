using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace SerialLogsDemo;

static class Program
{
    private static IServiceProvider? serviceProvider;

    public static IServiceProvider? ServiceProvider => serviceProvider;


    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.

        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("logs/log.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog();
        });

        serviceCollection.AddSingleton<Form1>();
        serviceProvider = serviceCollection.BuildServiceProvider();

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }    
}