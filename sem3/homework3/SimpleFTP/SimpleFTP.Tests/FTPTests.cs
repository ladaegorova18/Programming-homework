using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleFTP.Tests
{
    [TestClass]
    public class FTPTests
    {
        private Server server;
        private Client client;
        private string path = "/test";

        [TestInitialize]
        public void Initialize()
        {
            server = new Server(8888);
            server.Process();
            client = new Client();
            client.Connect(8888, "localhost");
        }

        [TestMethod]
        public async Task ListTest()
        {
            var listResponse = await client.List(path);
            var expected = "3 /test" + "\\" + "folder True /test" + "\\" + "oneMoreFolder True /test" + "\\" + "file.txt False ";
            Assert.AreEqual(expected, listResponse);
            server.Close();
            client.CloseClient();
        }
    }
}
