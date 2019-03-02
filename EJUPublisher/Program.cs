using System;
using System.Net.Sockets;

namespace EJUPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            int serverPort = 50228;

            TcpClient client = new TcpClient("127.0.0.1", serverPort);
            NetworkStream _stream = client.GetStream();

            while(client.Connected)
            {
                var buffer = new Byte[256];
                _stream.Read(buffer, 0, 255);
                string command = System.Text.Encoding.ASCII.GetString(buffer, 0, 255);
                if(command.Contains("^ID"))
                {
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes("!OC0010061006       D.");
                    _stream.Write(data, 0, data.Length);
                    Console.Write($"ID received, send response. {command}");
                    Console.Write($"Responded with: {System.Text.Encoding.ASCII.GetString(data, 0, data.Length)}");
                }
                else
                {
                    Console.Write(command);
                }
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
