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
        private WriteForTests writeable = new WriteForTests();

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
            server.Cancel();
            client.Close();
        }

        [TestMethod]
        public async Task ListEmptyFolderTest()
        {
            var listResponse = await client.List(path + "/folder");
            var expected = "0 ";
            Assert.AreEqual(expected, listResponse);
            server.Cancel();
            client.Close();
        }

        [TestMethod]
        public async Task GetTest()
        {
            var getResponse = await client.Get("/test/file.txt");
            var expected = "44 Is this the real life? Is this just fantasy?";
            Assert.AreEqual(expected, getResponse);
            server.Cancel();
            client.Close();
        }

        [TestMethod]
        public async Task WrongPathListTest()
        {
            path = "/test/test";
            var listResponse = await client.List(path);
            var expected = "-1 ";
            Assert.AreEqual(expected, listResponse);
            server.Cancel();
            client.Close();
        }

        [TestMethod]
        public async Task WrongPathGetTest()
        {
            path = "/test/test";
            var getResponse = await client.Get(path);
            var expected = "-1 ";
            Assert.AreEqual(expected, getResponse);
            server.Cancel();
            client.Close();
        }
    }
}
