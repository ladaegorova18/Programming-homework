using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Test1
{
    /// <summary>
    /// client class
    /// </summary>
    public class Client
    {
        private static AutoResetEvent waitMain = new AutoResetEvent(false);
        private static TcpClient client = null;

        /// <summary>
        /// main client process to read and write to server
        /// </summary>
        /// <param name="port"> port to connect </param>
        /// <param name="address"> ip address </param>
        public static void Process(int port, string address)
        {
            try
            {
                client = new TcpClient(address, port);
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
                client.Close();
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
                    if (message.CompareTo("exit") == 0)
                    {
                        CloseClient();
                    }
                    if (message != null)
                    {
                        await streamWriter.WriteLineAsync(message).ConfigureAwait(false);
                    }
                }
            });
        }

        /// <summary>
        /// metod by server to close client
        /// </summary>
        public static void CloseClient()
        {
            Console.WriteLine("closing...");
            waitMain.Set();
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
                        Console.WriteLine($"Server: {response}");
                    }
                }
            });
        }
    }
}
