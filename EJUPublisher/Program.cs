using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using log4net;
using System.Reflection;
using EJUPublisher.Models.ViewModels;
using Avalonia.ReactiveUI;
using System;
using log4net.Repository.Hierarchy;
using log4net.Layout;
using log4net.Appender;
using log4net.Core;

namespace EJUPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            //var logRepository = LogManager.GetRepository();
            //log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            AddLog4NetConfig();


            /*if (!(logRepository.GetAppenders().Length > 0))
            {
                throw new Exception("No appenders found");
            }
            if (!logRepository.Configured)
            {
                throw new NotImplementedException();
            }*/

            var logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            logger.Info("App start");

            //var EJUPublisher = serviceProvider.GetService<IEJUPublisherService>();

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

            //EJUPublisher.Publish();
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToTrace();

        private static void AddLog4NetConfig()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();

            // defining the pattern layout
            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date| %level | %message%newline";
            patternLayout.ActivateOptions();

            // creating the regular console appender
            var fileAppender = new FileAppender
            {
                Layout = patternLayout,
                File = "EJUPublisher.log",
                AppendToFile = true
            };
            fileAppender.ActivateOptions();
            hierarchy.Root.AddAppender(fileAppender);

            // defining the level and finalizing the configuration
            hierarchy.Root.Level = Level.Debug;
            hierarchy.Configured = true;
        }
    }
}
