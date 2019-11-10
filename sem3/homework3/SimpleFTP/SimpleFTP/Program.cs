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
            var writeable = new WriteOnConsole();
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                writeable.Write("Waiting for connections...");

                client = await listener.AcceptTcpClientAsync();
                var server = new Server(client, writeable);
                server.Process();
            }
            catch (Exception ex)
            {
                writeable.Write(ex.Message);
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
