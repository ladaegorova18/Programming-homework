using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GUIForServer.Tests
{
    [TestClass]
    public class Tests
    {
        private readonly string path = "\\Downloads";
        private ApplicationViewModel model;
        private readonly ObservableCollection<string> content =
            new ObservableCollection<string> { "folder", "oneMoreFolder", "thirdFolder" };
        private Server server;


        [TestInitialize]
        public void Initialize()
        {
            server = new Server(8888);
            var serverThread = new Thread(StartServer);
            serverThread.Start();

            model = new ApplicationViewModel(path);
        }

        private void StartServer()
        {
            Task.Run(async () =>
            {
                await server.Process();
            });
        }

        [TestMethod]
        public void OpenServerFolderTest()
        {
            Task.Run(async () =>
            {
                await model.OpenFolderOrLoad("Downloads");
                Assert.IsTrue(Assertion(model.ServerExplorer, content));
            });
        }

        private bool Assertion(ObservableCollection<string> paths, ObservableCollection<string> content)
        {
            for (var i = 0; i < paths.Count; ++i)
            {
                if (paths[i] != content[i])
                {
                    return false;
                }
            }
            return true;
        }

        [TestMethod]
        public void ClientRootReachedTest() => RootReach(model.FolderUpClient, "Client root reached");

        [TestMethod]
        public void ServerRootReachedTest() => RootReach(model.FolderUpServer, "Server root reached");

        private void RootReach(RelayCommand folderUp, string content)
        {
            var command = folderUp;
            object obj = null;
            command.Execute(obj);
            Assert.AreEqual(content, model.ErrorBox);
        }
    }
}