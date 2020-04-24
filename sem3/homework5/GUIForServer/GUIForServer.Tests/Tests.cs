using System.Collections.ObjectModel;
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


        [TestInitialize]
        public void Initialize() => model = new ApplicationViewModel(path);

        [TestMethod]
        public void OpenFolderTest()
        {
            Assert.IsTrue(Assertion(model.ClientExplorer, content));
            model.OpenClientFolder("folder");
            Assert.IsTrue(model.ClientExplorer.Count == 0);
        }

        [TestMethod]
        public async void OpenServerFolderTest()
        {
            await model.OpenFolderOrLoad("Downloads");
            Assert.IsTrue(Assertion(model.ServerExplorer, content));
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