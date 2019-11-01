using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Test1
{
    /// <summary>
    /// server class
    /// </summary>
    public class Server
    {
        /// <summary>
        /// TcpClient to connect with
        /// </summary>
        public static TcpClient client { get; private set; }

        /// <summary>
        /// constructor: assigns this TcpClient
        /// </summary>
        public Server(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        private static readonly AutoResetEvent waitMain = new AutoResetEvent(false);
        private static TcpListener listener;

        /// <summary>
        /// main server process to read and write to client
        /// </summary>
        public void Process(TcpListener newListener)
        {
            listener = newListener;
            NetworkStream stream = null;
            try
            {
                var streamWriter = new StreamWriter(client.GetStream()) { AutoFlush = true };
                var streamReader = new StreamReader(client.GetStream());
                Reader(streamReader);
                Writer(streamWriter);
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

        private static void Writer(StreamWriter streamWriter)
        {
            Task.Run(async () =>
            {
                Console.WriteLine("Enter messages to chat: ");
                while (true)
                {
                    var message = Console.ReadLine();
                    if (message != null)
                    {
                        await streamWriter.WriteLineAsync(message).ConfigureAwait(false);
                    }
                    if (message.CompareTo("exit") == 0)
                    {
                        CloseServer();
                    }
                }
            });
        }

        private static void Reader(StreamReader streamReader)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    var response = await streamReader.ReadLineAsync().ConfigureAwait(false);
                    if (response != null)
                    {
                        Console.WriteLine($"Client: {response}");
                    }
                    if (response.CompareTo("exit") == 0)
                    {
                        CloseServer();
                    }
                }
            });
        }

        public static void CloseServer()
        {
            Console.WriteLine("closing...");
            waitMain.Set();
            listener.Stop();
        }
    }
}