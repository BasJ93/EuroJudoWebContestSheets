using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using EJUPublisher.Configuration;
using EJUPublisher.Services.Interfaces;
using EuroJudoProtocols.ShowFights;
using EuroJudoProtocols.ShowFights.Models;
using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EJUPublisher.Services
{
    /// <inheritdoc />
    public sealed class EjuPublisherService : IEjuPublisherService
    {
        private readonly ILogger<EjuPublisherService> _logger;
        
        private readonly IShowFightsClient _showFights;
        private readonly IWebTournamentService _tournamentService;

        private readonly IWebConfiguration _webConfiguration;
        private readonly IContestOrderConfiguration _contestOrderConfiguration;
        private readonly IUploadConfig _uploadConfig;
        private ShowFightsConfiguration _showFightsConfiguration;

        private CancellationTokenSource _cancellationToken;

        private string _uploadPath;
        private HttpClient _httpClient;

        public EventHandler<string> DataReceivedLogEvent { get; set; }

        public EjuPublisherService(ILogger<EjuPublisherService> logger, IShowFightsClient showFights,
            IWebConfiguration webConfiguration, IContestOrderConfiguration contestOrderConfiguration,
            ShowFightsConfiguration showFightsConfiguration, IUploadConfig uploadConfig, IWebTournamentService tournamentService)
        {
            _logger = logger;
            _showFights = showFights;
            _webConfiguration = webConfiguration;
            _contestOrderConfiguration = contestOrderConfiguration;
            _showFightsConfiguration = showFightsConfiguration;
            _uploadConfig = uploadConfig;
            _tournamentService = tournamentService;

            _cancellationToken = new CancellationTokenSource();

            _showFights.ContestsUpdated += PublishContests;
            
            _uploadPath = $"{_webConfiguration.WebServer}{_contestOrderConfiguration.Path}";

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _webConfiguration.ApiKey);
        }

        /// <inheritdoc />
        public void RefreshConfiguration()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RefreshConfiguration(ShowFightsConfiguration showFightsConfiguration)
        {
            _showFightsConfiguration = showFightsConfiguration;

            _uploadPath = $"{_webConfiguration.WebServer}{_contestOrderConfiguration.Path}";

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _webConfiguration.ApiKey);

            _showFights?.UpdateConfiguration(showFightsConfiguration);
        }

        /// <inheritdoc />
        public void Start()
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken = new CancellationTokenSource();
            }

            _showFights.StartListener(_cancellationToken.Token);

            DataReceivedLogEvent?.Invoke(this,
                $"{DateTime.Now.ToLongTimeString()} Started ShowFights Listener for {_showFightsConfiguration.EjuServer}:{_showFightsConfiguration.EjuServerPort}");
        }

        /// <inheritdoc />
        public void Stop()
        {
            _cancellationToken.Cancel();
            DataReceivedLogEvent?.Invoke(this, $"{DateTime.Now.ToLongTimeString()} Stopped ShowFights Listener");
        }

        private async void PublishContests(object sender, IEnumerable<Contest> contests)
        {
            List<ContestOrderDto> contestOrder = new();
            
            var grouped = contests.GroupBy(c => c.Tatami);
            var ordered = grouped.OrderBy(g => g.Key);
            var filtered = ordered.Where(g => g.Key != 0);
            //var skipped = ordered.Skip(1);

            // Extract the correct number of contests.
            if (_showFightsConfiguration.KeepLastFight == 1)
            {
                var selected = filtered.Select(group => new ContestOrderDto(group.Key,
                    group.Skip(1).Take(_showFightsConfiguration.NumberOfFights).Select(c =>
                        new ContestDto(c.Order, c.CompetitorWhite, c.CompetitorBlue, c.Weight, c.Short))));
                contestOrder = selected.ToList();
            }
            else
            {
                var selected = filtered.Select(group => new ContestOrderDto(group.Key,
                    group.Take(_showFightsConfiguration.NumberOfFights).Select(c =>
                        new ContestDto(c.Order, c.CompetitorWhite, c.CompetitorBlue, c.Weight, c.Short))));
                contestOrder = selected.ToList();
            }

            if (_uploadConfig.UploadContest)
            {
                //Upload to webserver
                StringContent requestBody = new StringContent(JsonConvert.SerializeObject(contestOrder), Encoding.UTF8,
                    "application/json");

                //File.WriteAllTextAsync("json_example.json", JsonConvert.SerializeObject(contestOrder));

                try
                {
                    var result = await _httpClient.PostAsync(_uploadPath, requestBody);

                    DataReceivedLogEvent?.Invoke(this,
                        $"{DateTime.Now.ToLongTimeString()} New data received consisting of {contestOrder.SelectMany(c => c.Contests).Count()} contests. Upload success: {result.IsSuccessStatusCode}");
                    _logger.LogDebug("Contest order upload. Success [{success}]. Reason [{reason}]", result.IsSuccessStatusCode, result.StatusCode);
                }
                catch (Exception ex)
                {
                    DataReceivedLogEvent?.Invoke(this,
                        $"{DateTime.Now.ToLongTimeString()} New data received consisting of {contestOrder.SelectMany(c => c.Contests).Count()} contests. Upload success: False. Reason: {ex.Message}");
                }
            }

            if (_uploadConfig.UploadResults)
            {
                if (_showFightsConfiguration.KeepLastFight == 1)
                {
                    List<Contest> selected = filtered.Select(group => group.First()).ToList();

                    foreach (Contest contestResult in selected)
                    {
                        bool succes = await _tournamentService.UploadContestResult(contestResult);
                    }
                }
            }
        }
    }
}