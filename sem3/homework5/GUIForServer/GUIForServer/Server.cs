using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUIForServer
{
    /// <summary>
    /// server class
    /// </summary>
    public class Server
    {
        private readonly CancellationTokenSource token = new CancellationTokenSource();
        private readonly TcpListener listener;
        private TcpClient client;
        private StreamWriter streamWriter;
        private StreamReader streamReader;

        /// <summary>
        /// constructor: assigns this TcpClient
        /// </summary>
        public Server(string host, int port)
        {
            listener = new TcpListener(IPAddress.Parse(host), port);
        }

        /// <summary>
        /// main server process to read and write to client
        /// </summary>
        public async Task Process()
        {
            listener.Start();
            try
            {
                while (!token.IsCancellationRequested)
                {
                    client = await listener.AcceptTcpClientAsync();
                    await Task.Run(() => HandleRequest()).ConfigureAwait(false);
                }
            }
            finally
            {
                streamWriter?.Close();
                streamReader?.Close();
                listener.Stop();
            }
        }

        /// <summary>
        /// reads a request, parses it and executes List() or Get()
        /// </summary>
        /// <param name="writer"> to write in stream </param>
        /// <param name="reader"> to read from stream </param>
        private async Task HandleRequest()
        {
            streamWriter = new StreamWriter(client.GetStream()) { AutoFlush = true };
            streamReader = new StreamReader(client.GetStream());
            while (!token.IsCancellationRequested)
            {
                var request = await streamReader.ReadLineAsync().ConfigureAwait(false);
                if (request != null)
                {
                    var response = ParseRequest(request);
                    if (response != null)
                    {
                        await streamWriter.WriteLineAsync(response).ConfigureAwait(false);
                    }
                }
            }
        }

        /// <summary>
        /// lists files in a directory on server
        /// </summary>
        /// <param name="path"> path to directory </param>
        /// <returns> list of files and directories, count of them and information which of them are directories </returns>
        private static string List(string path)
        {
            var size = -1;
            string catalog = null;
            if (Directory.Exists(path))
            {
                var directories = Directory.GetDirectories(path);
                var files = Directory.GetFiles(path);
                catalog = ListFiles(directories, catalog, true);
                catalog = ListFiles(files, catalog, false);
                size = directories.Length + files.Length;
            }
            return size.ToString() + " " + catalog;
        }

        private static string ListFiles(string[] list, string catalog, bool isDir)
        {
            var length = Directory.GetCurrentDirectory().Length;
            var buider = new StringBuilder();
            buider.Append(catalog);
            for (var i = 0; i < list.Length; ++i)
            {
                list[i] = list[i].Substring(length);
                buider.Append(list[i] + " " + isDir + " ");
            }
            catalog = buider.ToString();
            return catalog;
        }

        private static byte[] Get(string path)
        {
            byte[] content = null;
            var file = new FileInfo(path);
            if (file.Exists)
            {
                content = File.ReadAllBytes(path);
            }
            return content;
        }

        private static string ParseRequest(string request)
        {
            var splitted = request.Split(new char[] { ' ' }, 2);
            if (Int32.TryParse(splitted[0], out int index))
            {
                var path = Directory.GetCurrentDirectory() + splitted[1];
                return (index == 1) ? List(path) : Get(path).ToString();
            }
            return null;
        }

        public void Cancel() => token.Cancel();
    }
}