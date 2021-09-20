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

        private CancellationTokenSource cancellationToken;

        private int serverPort;
        private string EJUServer;
        private int numberOfTatami;
        private string WebServer;
        private HttpClient httpClient;
        private int numberOfContests;

        public EJUPublisherService(IConfiguration configuration, ILog logger)
        {
            this.Logger = logger;
            this.WebServer = configuration["WebServer"];

            this.serverPort = Convert.ToInt32(configuration["EJUPort"]);
            this.EJUServer = configuration["EJUServer"];

            this.httpClient = new HttpClient();
            this.numberOfContests = Convert.ToInt32(configuration["NumberOfContests"]);
            this.numberOfTatami = Convert.ToInt32(configuration["NumberOfTatami"]);

            this.cancellationToken = new CancellationTokenSource();

        }

        public void Publish()
        {
            this.showFights = new ShowFightsClient(Logger, EJUServer, serverPort, numberOfTatami, numberOfContests, 4096);

            this.showFights.ContestsUpdated += PublishContests;

            this.showFights.StartListener(cancellationToken.Token);

            while(true)
            {
                Thread.Sleep(1000);
            }
        }

        private void PublishContests(object sender, IEnumerable<Contest> contests)
        {
            List<ContestOrder> contestOrder = new List<ContestOrder>();

            for (int i = 0; i < numberOfTatami; i++)
            {
                contestOrder.Add(new ContestOrder() { Tatami = i + 1 });
            }

            Console.WriteLine($"Data received at {DateTime.Now.ToLongTimeString()} consisting of {contests.Count()} contests:");

            foreach (var tatami in contestOrder)
            {
                tatami.Contests.Clear();
            }

            contestOrder = contests.GroupBy(c => c.Tatami).OrderBy(g => g.Key).Skip(1).Select(group => new ContestOrder(group.Key, group.Take(numberOfContests))).ToList();

            //Upload to webserver
            StringContent requestBody = new StringContent(JsonConvert.SerializeObject(contestOrder), Encoding.UTF8, "application/json");

            //File.WriteAllTextAsync("json_example.json", JsonConvert.SerializeObject(contestOrder));

            var result = this.httpClient.PostAsync(WebServer, requestBody).Result;
        }
    }
}