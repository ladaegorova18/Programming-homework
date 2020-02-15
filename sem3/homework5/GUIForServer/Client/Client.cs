using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace GUIForServer
{
    /// <summary>
    /// client class
    /// </summary>
    public class Client
    {
        private TcpClient client = null;

        private StreamReader streamReader;
        private StreamWriter streamWriter;

        /// <summary>
        /// is client connected to server
        /// </summary>
        public bool Connected { get; private set; }

        /// <summary>
        /// client connection to server
        /// </summary>
        public void Connect(string address, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(address, port);
                var stream = client.GetStream();
                streamWriter = new StreamWriter(stream) { AutoFlush = true };
                streamReader = new StreamReader(stream);
                Connected = true;
            }
            catch (SocketException)
            {
                Connected = false;
            }
        }

        /// <summary>
        /// server method to close client
        /// </summary>
        public void Close()
        {
            streamWriter?.Close();
            streamReader?.Close();
            client.Close();
        }

        /// <summary>
        /// user's List command 
        /// </summary>
        /// <param name="path"> path to directory </param>
        /// <returns> list of files in directory </returns>
        public async Task<string> List(string path) => await SendRequest(path, 1).ConfigureAwait(false);

        /// <summary>
        /// user's Get command 
        /// </summary>
        /// <param name="path"> path to file </param>
        /// <returns> downloads file to destination </returns>
        public async Task Get(string path, string destination)
        {
            await SendRequest(path, 2).ConfigureAwait(false);
            var content = await streamReader.ReadLineAsync();

            if (content == "-1")
            {
                throw new FileNotFoundException();
            }

            using (var file = new StreamWriter(new FileStream(destination + $"\\{path}", FileMode.Create)))
            {
                await file.WriteAsync(content);
            }
        }

        private async Task<string> SendRequest(string path, int index)
        {
            if (!Connected)
            {
                throw new ConnectionException();
            }
            try
            {
                await streamWriter.WriteLineAsync($"{index} {path}").ConfigureAwait(false);
                return await streamReader.ReadLineAsync().ConfigureAwait(false);
            }
            catch (Exception innerException)
            {
                throw new AggregateException("Socket exception!", innerException);
            }
        }
    }
}