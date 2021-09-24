using Avalonia.Collections;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using System;
using System.Reactive;

namespace EJUPublisher.Models.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private IConfiguration Configuration;
        private IEJUPublisherService PublisherService;

        private string _ejuServer;
        public string EJUServer
        {
            get => _ejuServer;

            set
            {
                Configuration["EJUServer"] = value;
                this.RaiseAndSetIfChanged(ref _ejuServer, value);
            }
        }

        private int numberOfTatami;
        public int NumberOfTatami
        {
            get => numberOfTatami;
            set
            {
                Configuration["NumberOfTatami"] = value.ToString();
                this.RaiseAndSetIfChanged(ref numberOfTatami, value);
            }
        }

        private int numberOfContests;
        public int NumberOfContests
        {
            get => numberOfContests;
            set
            {
                Configuration["NumberOfContests"] = value.ToString();
                this.RaiseAndSetIfChanged(ref numberOfContests, value);
            }
        }

        private int bufferSizePerTatami;

        public int BufferSizePerTatami
        {
            get => bufferSizePerTatami;
            set
            {
                Configuration["BufferSizePerTatami"] = value.ToString();
                this.RaiseAndSetIfChanged(ref bufferSizePerTatami, value);
            }
        }

        public AvaloniaList<string> LogLines { get; } = new AvaloniaList<string>();

        public ReactiveCommand<Unit, Unit> StartListenerCommand { get; }
        public ReactiveCommand<Unit, Unit> UpdateListenerCommand { get; }
        public ReactiveCommand<Unit, Unit> StopListenerCommand { get; }

        public MainViewModel(IEJUPublisherService publisherService, IConfiguration configuration)
        {
            PublisherService = publisherService;
            Configuration = configuration;

            EJUServer = configuration["EJUServer"];
            NumberOfContests = Convert.ToInt32(configuration["NumberOfContests"]);
            NumberOfTatami = Convert.ToInt32(configuration["NumberOfTatami"]);
            BufferSizePerTatami = Convert.ToInt32(configuration["BufferSizePerTatami"]);

            StartListenerCommand = ReactiveCommand.Create(PublisherService.Start);
            StopListenerCommand = ReactiveCommand.Create(PublisherService.Stop);
            UpdateListenerCommand = ReactiveCommand.Create(PublisherService.RefreshConfiguration);

            PublisherService.DataReceivedLogEvent += HandleNewLogLine;
        }

        private void HandleNewLogLine(object sender, string logline)
        {
            LogLines.Add(logline);
        }

    }
}
