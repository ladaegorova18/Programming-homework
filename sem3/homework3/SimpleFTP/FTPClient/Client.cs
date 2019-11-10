using FTPServer;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace FTPClient
{
    public class Client
    {
        private static AutoResetEvent locker = new AutoResetEvent(true);
        private static AutoResetEvent waitMain = new AutoResetEvent(false);
        private static AutoResetEvent waitResponse = new AutoResetEvent(false);
        private TcpClient client;
        private IWriteable writeable;
        private string request;
        private volatile string response;

        public string Response
        {
            get
            {
                if (response == null)
                {
                    waitResponse.WaitOne();
                }
                return response;
            }
            private set => response = value;
        }

        public Client (TcpClient client, IWriteable writeable)
        {
            this.writeable = writeable;
            this.client = client;
        }

        public void Process()
        {
            var streamWriter = new StreamWriter(client.GetStream()) { AutoFlush = true };
            var streamReader = new StreamReader(client.GetStream());
            Reader(streamReader);
            Writer(streamWriter);
            waitMain.WaitOne();
        }

        public void Send(string line) => request = line;

        private void Writer(StreamWriter writer)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    locker.WaitOne();
                    writeable.Write("Please enter a FTP request:");
                    request = writeable.Read();
                    if (request != null)
                    {
                        await writer.WriteLineAsync(request).ConfigureAwait(false);
                    }
                }
            });
        }

        private void Reader(StreamReader reader)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    var serverResponse = await reader.ReadLineAsync().ConfigureAwait(false);
                    if (serverResponse != null)
                    {
                        writeable.Write($"Server responses: {serverResponse}");
                        response = serverResponse;
                        locker.Set();
                        waitResponse.Set();
                    }
                }
            });
        }
    }
}
