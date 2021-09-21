using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EJUPublisher.Models.ViewModels;
using log4net;
using log4net.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace EJUPublisher
{
    public class App : Application
    {
        private IServiceProvider ServiceProvider;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            //setup our DI
            ServiceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<ILog>(LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType))
                .AddSingleton<IEJUPublisherService, EJUPublisherService>()
                .AddScoped<MainViewModel>()
                .BuildServiceProvider();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainView(ServiceProvider);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
