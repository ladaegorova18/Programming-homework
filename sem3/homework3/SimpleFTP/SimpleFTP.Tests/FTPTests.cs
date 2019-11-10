using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using FTPClient;
using FTPServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleFTP.Tests
{
    [TestClass]
    public class FTPTests
    {
        private TcpListener listener;
        private TcpClient tcpClient;
        private Client client;
        private IWriteable writeable;
        private const int port = 8888;
        private const string address = "127.0.0.1";
        private static AutoResetEvent locker = new AutoResetEvent(false);

        [TestInitialize]
        public void Initialize()
        {
            writeable = new WriteForTests();
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            CreateServer();
        }

        private void CreateServer()
        {
            Task.Run( () =>
            {
                //tcpClient = await listener.AcceptTcpClientAsync();
                tcpClient = new TcpClient(address, port);
                var server = new Server(tcpClient, writeable);
                CreateClient();
                server.Process();
            });
        }

        private void CreateClient()
        {
            Task.Run(() =>
            {
                client = new Client(tcpClient, writeable);
                locker.Set();
                client.Process();
            });
        }

        [TestMethod]
        public void ListTest()
        {
            locker.WaitOne();
            client.Send("1 /test");
            var response = client.Response;
            //Assert.AreEqual();
        }
    }
}
