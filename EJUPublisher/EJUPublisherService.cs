using EuroJudoProtocols.ShowFights;
using EuroJudoProtocols.ShowFights.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using EJUPublisher.Configuration;
using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.Extensions.Logging;

namespace EJUPublisher
{
    public class EjuPublisherService : IEJUPublisherService
    {
        private readonly ILogger<EjuPublisherService> _logger;
        private readonly IShowFightsClient _showFights;
        private readonly IConfiguration _configuration;
        private readonly IWebConfiguration _webConfiguration;
        private readonly IContestOrderConfiguration _contestOrderConfiguration;

        private CancellationTokenSource _cancellationToken;

        private int _serverPort;
        private string _ejuServer;
        private int _numberOfTatami;
        private string _uploadPath;
        private HttpClient _httpClient;
        private int _numberOfContests;
        private int _bufferSizePerTatami;

        public EventHandler<string> DataReceivedLogEvent { get; set; }

        public EjuPublisherService(IConfiguration configuration, ILogger<EjuPublisherService> logger, IShowFightsClient showFights, IWebConfiguration webConfiguration, IContestOrderConfiguration contestOrderConfiguration)
        {
            _logger = logger;
            _showFights = showFights;
            _webConfiguration = webConfiguration;
            _contestOrderConfiguration = contestOrderConfiguration;
            _configuration = configuration;

            _cancellationToken = new CancellationTokenSource();

            _showFights.ContestsUpdated += PublishContests;
            
            RefreshConfiguration();
        }

        // Provide a configuration object to this method
        public void RefreshConfiguration()
        {
            _uploadPath = $"{_webConfiguration.WebServer}{_contestOrderConfiguration.Path}";

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _webConfiguration.ApiKey);

            _serverPort = Convert.ToInt32(_configuration["EJUPort"]);
            _ejuServer = _configuration["EJUServer"];

            _numberOfContests = Convert.ToInt32(_configuration["NumberOfContests"]);
            _numberOfTatami = Convert.ToInt32(_configuration["NumberOfTatami"]);
            _bufferSizePerTatami = Convert.ToInt32(_configuration["BufferSizePerTatami"]);

            var showfightsConfig = new ShowFightsConfiguration
            {
                EjuServer = _ejuServer,
                EjuServerPort = _serverPort,
                NumberOfTatami = _numberOfTatami,
                NumberOfFights = _numberOfContests,
                BufferSizePerTatami = _bufferSizePerTatami
            };

            _showFights?.UpdateConfiguration(showfightsConfig);
        }

        public void Start()
        {
            if (_cancellationToken.IsCancellationRequested)
            {
                _cancellationToken = new CancellationTokenSource();
            }

            _showFights.StartListener(_cancellationToken.Token);

            DataReceivedLogEvent?.Invoke(this, $"{DateTime.Now.ToLongTimeString()} Started ShowFights Listener for {this._ejuServer}:{this._serverPort}");
        }

        public void Stop()
        {
            _cancellationToken.Cancel();
            DataReceivedLogEvent?.Invoke(this, $"{DateTime.Now.ToLongTimeString()} Stopped ShowFights Listener");
        }

        private void PublishContests(object sender, IEnumerable<Contest> contests)
        {
            var grouped = contests.GroupBy(c => c.Tatami);
            var ordered = grouped.OrderBy(g => g.Key);
            var filtered = ordered.Where(g => g.Key != 0);
            //var skipped = ordered.Skip(1);
            var selected = filtered.Select(group => new ContestOrderDto(group.Key, group.Take(_numberOfContests).Select(c => new ContestDto(c.Number, c.CompetitorWhite, c.CompetitorBlue, c.Weight, c.Short))));
            List<ContestOrderDto> contestOrder = selected.ToList();

            //Upload to webserver
            StringContent requestBody = new StringContent(JsonConvert.SerializeObject(contestOrder), Encoding.UTF8, "application/json");

            //File.WriteAllTextAsync("json_example.json", JsonConvert.SerializeObject(contestOrder));

            var result = this._httpClient.PostAsync(_uploadPath, requestBody).Result;

            DataReceivedLogEvent?.Invoke(this, $"{DateTime.Now.ToLongTimeString()} New data received consisting of {contestOrder.SelectMany(c => c.Contests).Count()} contests. Upload success: {result.IsSuccessStatusCode}");
        }
    }
}