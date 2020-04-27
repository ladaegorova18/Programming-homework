using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace GUIForServer
{
    /// <summary>
    /// Client class
    /// </summary>
    public class Client : IDisposable
    {
        private TcpClient client = null;

        private StreamReader streamReader;
        private StreamWriter streamWriter;

        /// <summary>
        /// Host client is connected to
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// Port client is connected to
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// is client connected to server
        /// </summary>
        public bool Connected { get; private set; }

        /// <summary>
        /// client connection to server
        /// </summary>
        public void Connect(string host, int port)
        {
            try
            {
                client = new TcpClient();
                client.Connect(host, port);
                var stream = client.GetStream();
                streamWriter = new StreamWriter(stream) { AutoFlush = true };
                streamReader = new StreamReader(stream);
                Connected = true;
                Host = host;
                Port = port;
            }
            catch (SocketException e)
            {
                Connected = false;
            }
        }

        /// <summary>
        /// Stops the server
        /// </summary>
        public void Stop() => client.Close();

        /// <summary>
        /// server method to close client
        /// </summary>
        public void Dispose()
        {
            streamWriter?.Close();
            streamReader?.Close();
            client.Dispose();
        }

        /// <summary>
        /// user's List command 
        /// </summary>
        /// <param name="path"> path to directory </param>
        /// <returns> list of files in directory </returns>
        public async Task<List<(string, bool)>> List(string path)
        {
            var folders = new List<(string, bool)>();

            var response = await SendRequest(path, 1);
            response = response.Substring(response.IndexOf(' ') + 1);

            var foldersSplit = response.Split('\t').ToList();

            foreach (var folder in foldersSplit)
            {
                var info = folder.Split(' ');
                var file = info[0].Substring(folder.LastIndexOf('\\') + 1);
                if (file != "")
                {
                    var isDir = info[1] == "True";
                    folders.Add((file, isDir));
                }
            }
            return folders;
        }

        /// <summary>
        /// user's Get command 
        /// </summary>
        /// <param name="path"> path to file </param>
        /// <returns> downloads file to destination </returns>
        public async Task Get(string path, string destination)
        {
            var content = await SendRequest(path, 2);

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
                await streamWriter.WriteLineAsync($"{index} {path}");
                return await streamReader.ReadLineAsync();
            }
            catch (Exception innerException)
            {
                throw new AggregateException("Socket exception!", innerException);
            }
        }
    }
}