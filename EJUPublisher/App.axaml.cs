using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EJUPublisher.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using EJUPublisher.Configuration;
using EJUPublisher.Services;
using EJUPublisher.Services.Interfaces;
using EuroJudoProtocols.ShowFights;
using EuroJudoProtocols.ShowFights.Models;
using Microsoft.Extensions.Logging;

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
            IContestSheetsConfiguration contestSheetsConfiguration =
                configuration.GetSection("ContestSheets").Get<ContestSheetsConfiguration>();
            IUploadConfig uploadConfig = new UploadConfig();
            
            //setup our DI
            _serviceProvider = new ServiceCollection()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConsole();
                })
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton(showFightsConfiguration)
                .AddSingleton(webConfiguration)
                .AddSingleton(contestOrderConfiguration)
                .AddSingleton(contestSheetsConfiguration)
                .AddSingleton(uploadConfig)
                .AddSingleton<IShowFightsClient, ShowFightsClient>()
                .AddSingleton<IEjuPublisherService, EjuPublisherService>()
                .AddSingleton<IWebTournamentService, WebTournamentService>()
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
