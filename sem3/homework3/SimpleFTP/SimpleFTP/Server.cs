using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTPServer
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

        private IWriteable writeable;

        /// <summary>
        /// constructor: assigns this TcpClient
        /// </summary>
        public Server(TcpClient tcpClient, IWriteable writeable)
        {
            client = tcpClient;
            this.writeable = writeable;
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
                HandleRequest(writer, reader);
                waitMain.WaitOne();
            }
            catch (Exception ex)
            {
                writeable.Write(ex.Message);
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

        /// <summary>
        /// reads a request, parses it and executes List() or Get()
        /// </summary>
        /// <param name="writer"> to write in stream </param>
        /// <param name="reader"> to read from stream </param>
        private void HandleRequest(StreamWriter writer, StreamReader reader)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    var request = await reader.ReadLineAsync().ConfigureAwait(false);
                    if (request != null)
                    {
                        string response = null;
                        writeable.Write($"Client requests: {request}");
                        var splitted = request.Split(new char[] { ' ' }, 2);
                        if (Int32.TryParse(splitted[0], out int index))
                        {
                            var path = Directory.GetCurrentDirectory() + splitted[1];
                            response = (index == 1) ? List(path) : Get(path);
                        }
                        else
                        {
                            response = "Invalid input! Try again :)";
                        }
                        await writer.WriteLineAsync(response).ConfigureAwait(false);
                    }
                }
            });
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

        /// <summary>
        /// gets information about file 
        /// </summary>
        /// <param name="path"> path to file </param>
        /// <returns> file size and contents </returns>
        private static string Get(string path)
        {
            long size = -1;
            string content = null;
            var file = new FileInfo(path);
            if (file.Exists)
            {
                size = file.Length;
                content = File.ReadAllText(path);
            }
            return size.ToString() + " " + content;
        }
    }
}
