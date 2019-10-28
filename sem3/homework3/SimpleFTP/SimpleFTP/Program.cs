using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace FTPServer
{
    /// <summary>
    /// main server program
    /// </summary>
    public class Program
    {
        private const int port = 8888;
        private static TcpListener listener;
        private static TcpClient client;

        private static async Task Main(string[] args)
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
