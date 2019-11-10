using System;
using System.Net.Sockets;
using FTPServer;

namespace FTPClient
{
    /// <summary>
    /// client program to send requests
    /// </summary>
    public class Program
    {
        private const int port = 8888;
        private const string address = "127.0.0.1";

        private static void Main(string[] args)
        {
            TcpClient tcpClient = null;
            try
            {
                tcpClient = new TcpClient(address, port);
                var writeable = new WriteOnConsole();
                var client = new Client(tcpClient, writeable);
                client.Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                tcpClient.Close();
            }
        }
    }
}
