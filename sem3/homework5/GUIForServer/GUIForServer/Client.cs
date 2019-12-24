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
            if (streamWriter != null)
            {
                streamWriter.Close();
            }
            if (streamReader != null)
            {
                streamReader.Close();
            }
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
        /// <returns> file size and file content </returns>
        public async Task<string> Get(string path, string destination)
        {
            var content = await SendRequest(path, 2).ConfigureAwait(false);
            var bytesContent = System.Text.Encoding.Default.GetBytes(content);
            if (Directory.Exists(Directory.GetCurrentDirectory() + destination))
            {
                var file = File.Create(destination);
                using (file)
                {
                    file.Write(bytesContent, 0, bytesContent.Length);
                }
            }
            return content;
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
            catch (SocketException innerException)
            {
                throw new AggregateException("Socket exception!", innerException);
            }
        }
    }
}