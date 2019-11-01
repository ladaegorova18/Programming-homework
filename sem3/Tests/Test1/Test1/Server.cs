using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Test1
{
    /// <summary>
    /// server class to handle requests
    /// </summary>
    public class Server
    {
        /// <summary>
        /// TcpClient to connect with
        /// </summary>
        public TcpClient client { get; private set; }

        /// <summary>
        /// constructor: assigns this TcpClient
        /// </summary>
        public Server(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        private readonly AutoResetEvent waitMain = new AutoResetEvent(false);

        /// <summary>
        /// main server process to read and write to client
        /// </summary>
        public void Process()
        {
            NetworkStream stream = null;
            try
            {
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
                if (stream != null)
                {
                    stream.Close();
                }
                if (client != null)
                {
                    client.Close();
                }
            }
        }

        private static void Writer(StreamWriter writer)
        {
            Task.Run(async () =>
            {
                Console.Write("Enter messages to chat: ");
                while (true)
                {
                    var message = Console.ReadLine();
                    if (message != null)
                    {
                        await writer.WriteLineAsync(message).ConfigureAwait(false);
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
                    var response = await reader.ReadLineAsync().ConfigureAwait(false);
                    if (response != null)
                    {
                        Console.WriteLine($"Client says: {response}");
                    }
                }
            });
        }
    }
}