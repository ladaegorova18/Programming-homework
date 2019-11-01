using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Test1
{
    /// <summary>
    /// main console chat program
    /// </summary>
    public class Program
    {
        private static TcpListener listener;
        private static TcpClient client;

        private static async Task Main(string[] args)
        {
            Console.WriteLine("Enter port or port and IP address:");
            var input = Console.ReadLine();
            var splitted = input.Split(new char[] { ' ' });
            if (Int32.TryParse(splitted[0], out int port))
            {
                if (splitted.Length == 2)
                {
                    Console.WriteLine("You have made a client");
                    Client.Process(port, splitted[1]);
                }
                else
                {
                    Console.WriteLine("You have made a server");
                    await MakeServer(port).ConfigureAwait(false);
                }
            }
        }

        private static async Task MakeServer(int port)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine("Waiting for connections...");

                while (true)
                {
                    client = await listener.AcceptTcpClientAsync();
                    var server = new Server(client);
                    server.Process();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
                if (listener != null)
                {
                    listener.Stop();
                }
            }
        }
    }
}