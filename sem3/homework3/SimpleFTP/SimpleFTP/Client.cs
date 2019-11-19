using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleFTP
{
    /// <summary>
    /// client class
    /// </summary>
    public class Client
    {
        private static TcpClient client = null;

        private StreamReader streamReader;
        private StreamWriter streamWriter;

        private CancellationTokenSource token = new CancellationTokenSource();

        public bool IsConnected { get; private set; }



        /// <summary>
        /// main client process to read and write to server
        /// </summary>
        /// <param name="port"> port to connect </param>
        /// <param name="address"> ip address </param>
        public void Process(int port, string address)
        {
            try
            {
                client = new TcpClient(address, port);
                streamWriter = new StreamWriter(client.GetStream()) { AutoFlush = true };
                streamReader = new StreamReader(client.GetStream());
            }
            finally
            {
                client.Close();
            }
        }

        /// <summary>
        /// Client connection to server
        /// </summary>
        public async Task<bool> Connect(int port, string address)
        {
            var delay = TimeSpan.FromSeconds(1);
            int counter = 0;
            for (var i = 0; i < 3; ++i)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(address, port);
                    break;
                }
                catch
                {
                    ++counter;
                }
                await Task.Delay(delay);
            }

            if (counter != 3)
            {
                var stream = client.GetStream();
                streamWriter = new StreamWriter(stream) { AutoFlush = true };
                streamReader = new StreamReader(stream);
                return IsConnected = true;
            }
            return false;
        }

        /// <summary>
        /// metod by server to close client
        /// </summary>
        public void CloseClient()
        {
            client.Close();
        }

        public async Task<string> List(string path)
        {
            await streamWriter.WriteLineAsync($"1 {path}").ConfigureAwait(false);
            return await streamReader.ReadLineAsync().ConfigureAwait(false);
        }

        public async Task<string> Get(string path)
        {
            await streamWriter.WriteLineAsync($"2 {path}").ConfigureAwait(false);
            return await streamReader.ReadLineAsync().ConfigureAwait(false);
        }
    }
}