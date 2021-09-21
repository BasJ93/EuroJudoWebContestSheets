using EJUPublisher.Models;
using EuroJudoProtocols.ShowFights;
using EuroJudoProtocols.ShowFights.Models;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace EJUPublisher
{
    public class EJUPublisherService : IEJUPublisherService
    {
        private ILog Logger;
        private IShowFightsClient showFights;
        private IConfiguration configuration;

        private CancellationTokenSource cancellationToken;

        private int serverPort;
        private string EJUServer;
        private int numberOfTatami;
        private string WebServer;
        private HttpClient httpClient;
        private int numberOfContests;
        private int BufferSizePerTatami;

        public EventHandler<string> DataReceivedLogEvent { get; set; }

        public EJUPublisherService(IConfiguration configuration, ILog logger)
        {
            this.Logger = logger;
            this.configuration = configuration;
            this.WebServer = configuration["WebServer"];

            this.serverPort = Convert.ToInt32(configuration["EJUPort"]);
            this.EJUServer = configuration["EJUServer"];

            this.httpClient = new HttpClient();
            this.numberOfContests = Convert.ToInt32(configuration["NumberOfContests"]);
            this.numberOfTatami = Convert.ToInt32(configuration["NumberOfTatami"]);

            this.BufferSizePerTatami = 8192;

            this.cancellationToken = new CancellationTokenSource();

        }

        // Provide a configuration object to this method
        public void RefreshConfiguration()
        {
            this.WebServer = configuration["WebServer"];

            this.serverPort = Convert.ToInt32(configuration["EJUPort"]);
            this.EJUServer = configuration["EJUServer"];

            this.httpClient = new HttpClient();
            this.numberOfContests = Convert.ToInt32(configuration["NumberOfContests"]);
            this.numberOfTatami = Convert.ToInt32(configuration["NumberOfTatami"]);

            var showfightsConfig = new ShowFightsConfiguration
            {
                EjuServer = EJUServer,
                EjuServerPort = serverPort,
                NumberOfTatami = numberOfTatami,
                NumberOfFights = numberOfContests,
                BufferSizePerTatami = BufferSizePerTatami
            };

            this.showFights?.UpdateConfiguration(showfightsConfig);
        }

        public void Start()
        {
            var showfightsConfig = new ShowFightsConfiguration
            {
                EjuServer = EJUServer,
                EjuServerPort = serverPort,
                NumberOfTatami = numberOfTatami,
                NumberOfFights = numberOfContests,
                BufferSizePerTatami = BufferSizePerTatami
            };

            this.showFights = new ShowFightsClient(Logger, showfightsConfig);

            this.showFights.ContestsUpdated += PublishContests;

            if(cancellationToken.IsCancellationRequested)
            {
                cancellationToken = new CancellationTokenSource();
            }

            this.showFights.StartListener(cancellationToken.Token);

            DataReceivedLogEvent?.Invoke(this, $"{DateTime.Now.ToLongTimeString()} Started ShowFights Listener for {this.EJUServer}:{this.serverPort}");
        }

        public void Stop()
        {
            this.cancellationToken.Cancel();
            DataReceivedLogEvent?.Invoke(this, $"{DateTime.Now.ToLongTimeString()} Stopped ShowFights Listener");
        }

        private void PublishContests(object sender, IEnumerable<Contest> contests)
        {
            List<ContestOrder> contestOrder = contests
                .GroupBy(c => c.Tatami)
                .OrderBy(g => g.Key)
                .Skip(1)
                .Select(group => new ContestOrder(group.Key, group.Take(numberOfContests)))
                .ToList();

            //Upload to webserver
            StringContent requestBody = new StringContent(JsonConvert.SerializeObject(contestOrder), Encoding.UTF8, "application/json");

            //File.WriteAllTextAsync("json_example.json", JsonConvert.SerializeObject(contestOrder));

            var result = this.httpClient.PostAsync(WebServer, requestBody).Result;

            DataReceivedLogEvent?.Invoke(this, $"{DateTime.Now.ToLongTimeString()} New data received consisting of {contests.Count()} contests. Upload succes: {result.IsSuccessStatusCode}");
        }
    }
}