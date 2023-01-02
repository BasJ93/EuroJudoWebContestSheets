using Avalonia.Collections;
using Microsoft.Extensions.Configuration;
using ReactiveUI;
using System.Reactive;
using Avalonia.Controls;
using EJUPublisher.Configuration;
using EJUPublisher.Services.Interfaces;
using EuroJudoProtocols.ShowFights.Models;

namespace EJUPublisher.Models.ViewModels
{
    public sealed class MainViewModel : ReactiveObject
    {
        private readonly IConfiguration _configuration;
        private readonly IEjuPublisherService _publisherService;
        private readonly TournamentManagementView _tournamentManagementView;
        private readonly ShowFightsConfiguration _showFightsConfiguration;
        private readonly IUploadConfig _uploadConfig;

        private string _ejuServer;
        public string EjuServer
        {
            get => _ejuServer;

            set
            {
                _showFightsConfiguration.EjuServer = value;
                _configuration["EJUServer"] = value;
                this.RaiseAndSetIfChanged(ref _ejuServer, value);
            }
        }

        private int _numberOfTatami;
        public int NumberOfTatami
        {
            get => _numberOfTatami;
            set
            {
                _showFightsConfiguration.NumberOfTatami = value;
                _configuration["NumberOfTatami"] = value.ToString();
                this.RaiseAndSetIfChanged(ref _numberOfTatami, value);
            }
        }

        private int _numberOfContests;
        public int NumberOfContests
        {
            get => _numberOfContests;
            set
            {
                _showFightsConfiguration.NumberOfFights = value;
                _configuration["NumberOfContests"] = value.ToString();
                this.RaiseAndSetIfChanged(ref _numberOfContests, value);
            }
        }

        private int _bufferSizePerTatami;

        public int BufferSizePerTatami
        {
            get => _bufferSizePerTatami;
            set
            {
                _showFightsConfiguration.BufferSizePerTatami = value;
                _configuration["BufferSizePerTatami"] = value.ToString();
                this.RaiseAndSetIfChanged(ref _bufferSizePerTatami, value);
            }
        }

        private bool _uploadContests;

        public bool UploadContests
        {
            get => _uploadContests;
            set
            {
                _uploadConfig.UploadContest = value;
                this.RaiseAndSetIfChanged(ref _uploadContests, value);
            }
        }
        
        private bool _uploadResults;

        public bool UploadResults
        {
            get => _uploadResults;
            set
            {
                _uploadConfig.UploadResults = value;
                this.RaiseAndSetIfChanged(ref _uploadResults, value);
            }
        }
        
        public AvaloniaList<string> LogLines { get; } = new();

        private string _selectedLogLine;
        
        public string SelectedLogLine
        {
            get => _selectedLogLine;
            set => this.RaiseAndSetIfChanged(ref _selectedLogLine, value);
        }

        public ReactiveCommand<Unit, Unit> StartListenerCommand { get; }
        public ReactiveCommand<Unit, Unit> UpdateListenerCommand { get; }
        public ReactiveCommand<Unit, Unit> StopListenerCommand { get; }
        public ReactiveCommand<Unit, Unit> ConfigureTournamentCommand { get; }

        public MainViewModel(IEjuPublisherService publisherService, IConfiguration configuration, TournamentManagementView tournamentManagementView, ShowFightsConfiguration showFightsConfiguration, IUploadConfig uploadConfig)
        {
            _publisherService = publisherService;
            _configuration = configuration;
            _tournamentManagementView = tournamentManagementView;
            _showFightsConfiguration = showFightsConfiguration;
            _uploadConfig = uploadConfig;

            tournamentManagementView.Closing += (s, e) =>
            {
                ((Window)s)?.Hide();
                e.Cancel = true;
            };
            
            EjuServer = _showFightsConfiguration.EjuServer;
            NumberOfContests = _showFightsConfiguration.NumberOfFights;
            NumberOfTatami = _showFightsConfiguration.NumberOfTatami;
            BufferSizePerTatami = _showFightsConfiguration.BufferSizePerTatami;

            StartListenerCommand = ReactiveCommand.Create(_publisherService.Start);
            StopListenerCommand = ReactiveCommand.Create(_publisherService.Stop);
            UpdateListenerCommand = ReactiveCommand.Create(() =>_publisherService.RefreshConfiguration(_showFightsConfiguration));

            ConfigureTournamentCommand = ReactiveCommand.Create(_tournamentManagementView.Show);

            _publisherService.DataReceivedLogEvent += HandleNewLogLine;
        }

        private void HandleNewLogLine(object sender, string logLine)
        {
            LogLines.Add(logLine);
            SelectedLogLine = logLine;
        }

    }
}
