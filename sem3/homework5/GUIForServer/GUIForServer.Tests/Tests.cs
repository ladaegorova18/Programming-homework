using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GUIForServer.Tests
{
    [TestClass]
    public class Tests
    {
        private string path = "\\Downloads";
        private ApplicationViewModel model;
        ObservableCollection<string> content = 
            new ObservableCollection<string>() { "folder", "oneMoreFolder", "thirdFolder" };


        [TestInitialize]
        public void Initialize() => model = new ApplicationViewModel(path);

        [TestMethod]
        public void DownloadTest()
        {
            Assert.IsFalse(File.Exists(path + "\\file.txt"));
            model.DownloadOneFile("\\file.txt");
            var directory = Directory.GetCurrentDirectory() + path + "\\file.txt";
            Assert.IsTrue(File.Exists(directory));
        }

        [TestMethod]
        public async Task OpenFolderTest()
        {
            Assert.IsTrue(Assertion(model.ClientExplorer, content));
            model.OpenClientFolder("folder");
            Assert.IsTrue(model.ClientExplorer.Count == 0);
        }

        [TestMethod]
        public void OpenServerFolderTest()
        {
            model.OpenFolderOrLoad("Downloads");
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
