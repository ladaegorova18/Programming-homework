using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Test1
{
    public class Client
    {
        private static AutoResetEvent waitMain = new AutoResetEvent(false);

        public static void Process(int port, string address)
        {
            TcpClient client = null;
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
                        Console.WriteLine($"Server requests: {response}");
                    }
                }
            });
        }
    }
}
