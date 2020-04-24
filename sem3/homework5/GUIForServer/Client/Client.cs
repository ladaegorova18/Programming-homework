using System;
using System.Collections.ObjectModel;
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
        /// List of files to show in explorer
        /// </summary>
        public ObservableCollection<string> Files { get; private set; }

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
                Files = new ObservableCollection<string>();
            }
            catch (SocketException)
            {
                Connected = false;
            }
        }

        /// <summary>
        /// server method to close client
        /// </summary>
        public void Dispose()
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
        public async Task<ObservableCollection<(string, bool)>> List(string path)
        {
            var folders = new ObservableCollection<(string, bool)>();

            var response = await SendRequest(path, 1).ConfigureAwait(false);
            response = response.Substring(response.IndexOf(' ') + 1);

            var foldersSplit = response.Split('\t').ToList();
            Files.Clear();

            foreach (var folder in foldersSplit)
            {
                var info = folder.Split(' ');
                var file = info[0].Substring(folder.LastIndexOf('\\') + 1);
                if (file != "")
                {
                    var isDir = info[1] == "True";
                    folders.Add((file, isDir));
                    Files.Add(file);
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
            var content = await SendRequest(path, 2).ConfigureAwait(false);

            if (content == "-1")
            {
                throw new FileNotFoundException();
            }

            using (var file = new StreamWriter(new FileStream(destination + $"\\{path}", FileMode.Create)))
            {
                await file.WriteAsync(content).ConfigureAwait(false);
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