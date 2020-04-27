using System.Collections.ObjectModel;
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
            Task.Run(async () => await server.Process());

            model = new ApplicationViewModel(path);
        }

        [TestMethod]
        public void OpenServerFolderTest()
        {
            var task = new Task(async () =>
            {
                await model.OpenFolderOrLoad("Downloads");
                CollectionAssert.AreEquivalent(model.ServerExplorer, content);
            });
            task.Start();
            task.Wait();
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