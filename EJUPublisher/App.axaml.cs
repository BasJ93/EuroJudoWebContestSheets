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
using EJUPublisher.Configuration;
using EuroJudoProtocols.ShowFights;
using EuroJudoProtocols.ShowFights.Models;

namespace EJUPublisher
{
    public class App : Application
    {
        private IServiceProvider _serviceProvider;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            ShowFightsConfiguration showFightsConfiguration = configuration.GetSection("EuroJudo").Get<ShowFightsConfiguration>(); 
            IWebConfiguration webConfiguration = configuration.GetSection("Web").Get<WebConfiguration>();
            IContestOrderConfiguration contestOrderConfiguration =
                configuration.GetSection("ContestOrder").Get<ContestOrderConfiguration>();
            
            //setup our DI
            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton(showFightsConfiguration)
                .AddSingleton(webConfiguration)
                .AddSingleton(contestOrderConfiguration)
                .AddSingleton<IShowFightsClient, ShowFightsClient>()
                .AddSingleton<IEJUPublisherService, EjuPublisherService>()
                .AddScoped<MainViewModel>()
                .AddScoped<TournamentManagementView>()
                .AddScoped<TournamentManagementViewModel>()
                .BuildServiceProvider();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainView(_serviceProvider);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
