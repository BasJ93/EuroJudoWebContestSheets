using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EJUPublisher.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
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

            ShowFightsConfiguration showFightsConfiguration =
                configuration.GetSection("EuroJudo").Get<ShowFightsConfiguration>();
            IWebConfiguration webConfiguration = configuration.GetSection("Web").Get<WebConfiguration>();
            IContestOrderConfiguration contestOrderConfiguration =
                configuration.GetSection("ContestOrder").Get<ContestOrderConfiguration>();
            IContestSheetsConfiguration contestSheetsConfiguration =
                configuration.GetSection("ContestSheets").Get<ContestSheetsConfiguration>();
            IUploadConfig uploadConfig = new UploadConfig();

            //setup our DI
            _serviceProvider = new ServiceCollection()
                .AddLogging(loggingBuilder => { loggingBuilder.AddConsole(); })
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton(showFightsConfiguration)
                .AddSingleton(webConfiguration)
                .AddSingleton(contestOrderConfiguration)
                .AddSingleton(contestSheetsConfiguration)
                .AddSingleton(uploadConfig)
                .AddSingleton<IFailedUploadQueue, FailedUploadQueue>()
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
                LoadQueue();
                
                desktop.MainWindow = new MainView(_serviceProvider);

                desktop.MainWindow.Closing += MainWindowOnClosing;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void MainWindowOnClosing(object sender, CancelEventArgs e)
        {
            IFailedUploadQueue queue = _serviceProvider.GetService<IFailedUploadQueue>();

            queue.FlushToDisk();
        }

        private void LoadQueue()
        {
            IConfiguration configuration = _serviceProvider.GetService<IConfiguration>();

            if (bool.TryParse(configuration["AutoLoadFailedQueue"], out bool autoUpload) && autoUpload)
            {
                IFailedUploadQueue queue = _serviceProvider.GetService<IFailedUploadQueue>();
                
                queue.ReadFromDisk();
            }
        }
    }
}