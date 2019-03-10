using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace EJUPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            int serverPort = 50228;

            int numberOfTatami = 8;

            TcpClient client = new TcpClient("192.168.2.3", serverPort);
            NetworkStream _stream = client.GetStream();

            while(client.Connected)
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
                    foreach (var contest in contests)
                    {
                        Console.WriteLine(contest);
                    }
                }
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
