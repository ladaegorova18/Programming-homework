using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace FTPClient
{
    /// <summary>
    /// client program to send requests
    /// </summary>
    public class Program
    {
        private const int port = 8888;
        private const string address = "127.0.0.1";
        private static AutoResetEvent locker = new AutoResetEvent(true);
        private static AutoResetEvent waitMain = new AutoResetEvent(false);

        private static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
                var reader = new StreamReader(client.GetStream());
                Reader(reader);
                Writer(writer);
                waitMain.WaitOne();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private static void Writer(StreamWriter writer)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    locker.WaitOne();
                    Console.WriteLine("Please enter a FTP request:");
                    var request = Console.ReadLine();
                    if (request != null)
                    {
                        await writer.WriteLineAsync(request);
                    }
                }
            });
        }

        private static void Reader(StreamReader reader)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    var response = await reader.ReadLineAsync();
                    if (response != null)
                    {
                        Console.WriteLine("Server requests:");
                        Console.WriteLine(response);
                        locker.Set();
                    }
                }
            });
        }
    }
}
