using EJUPublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Text;

namespace EJUPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            int serverPort = 50228;

            int numberOfTatami = 8;

            string EJUServer = "127.0.0.1";// "192.168.2.3";

            string WebServer = "http://localhost:50256/ContestOrder/PostContestOrderLists";

            HttpClient _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "EJUPublisher");

            List<ContestOrder> contestOrder = new List<ContestOrder>();
            for(int i=0; i<numberOfTatami; i++)
            {
                contestOrder.Add(new ContestOrder() { Tatami = i });
            }

            TcpClient HTTPClient = new TcpClient(EJUServer, serverPort);
            NetworkStream _stream = HTTPClient.GetStream();

            while(HTTPClient.Connected)
            {
                var buffer = new Byte[1500 * numberOfTatami];
                _stream.Read(buffer, 0, 1500 * numberOfTatami);
                string command = System.Text.Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                if(command.Contains("^ID"))
                {
                    //!OC beginmat{000} eindmat{000} keep{1/0} aantal{000} extended_hex lenght{} \0
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes("!OC001" + numberOfTatami.ToString().PadLeft(3, '0' )  + "0006       D\0");//Deze string kan niet langer worden, dus kan ik die hardcoden.
                    _stream.Write(data, 0, data.Length);
                    Console.WriteLine($"ID received, send response. {command}");
                    Console.WriteLine($"Responded with: {System.Text.Encoding.ASCII.GetString(data, 0, data.Length)}");
                }
                else if(command.Contains("_OC"))
                {
                    command = command.Substring(command.IndexOf("_OC") + 3);
                    command = command.Substring(0, command.IndexOf('\0'));
                    List<string> contests = command.Split("\n").ToList();
                    Console.WriteLine($"Data received at {DateTime.Now.ToLongTimeString()} consisting of {contests.Count} contests:");

                    foreach(var tatami in contestOrder)
                    {
                        tatami.Contests.Clear();
                    }

                    //Convert to contestOrder lists
                    foreach (var contest in contests)
                    {
                        Console.WriteLine(contest);
                        var _contest = EJU2Contest(contest);
                        if (_contest.Tatami > 0)
                        {
                            contestOrder[_contest.Tatami - 1].Contests.Add(_contest);
                        }
                    }

                    //Upload to webserver
                    StringContent requestBody = new StringContent(JsonConvert.SerializeObject(contestOrder), Encoding.UTF8, "application/json");
                    _httpClient.PostAsync(WebServer, requestBody);
                }
            }
        }

        private static Contest EJU2Contest(string EJU)
        {
            if (EJU.Contains(';'))
            {
                List<string> components = EJU.Split(';').ToList();
                Contest _contest = new Contest()
                {
                    Tatami = Convert.ToInt32(components[0]),
                    Number = Convert.ToInt32(components[1]),
                    Weight = components[2],
                    CompeditorWhite = components[3],
                    CompeditorBlue = components[7]
                };

                return _contest;
            }
            else
            {
                return new Contest();
            }
        }
    }
}
