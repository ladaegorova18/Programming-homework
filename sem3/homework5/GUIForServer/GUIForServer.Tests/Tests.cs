using System;
using System.Collections.Generic;
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

        [TestInitialize]
        public void Initialize() => model = new ApplicationViewModel(path);

        [TestMethod]
        public async Task DownloadTest()
        {
            Assert.IsFalse(File.Exists(path + "\\file.txt"));
            await model.DownloadOneFile("\\file.txt");
            Assert.IsTrue(File.Exists(Directory.GetCurrentDirectory() + path + "\\file.txt"));
        }

        [TestMethod]
        public async Task OpenFolderTest()
        {
            var content = new ObservableCollection<string>() { "folder", "oneMoreFolder", "thirdFolder" };
            Assert.IsTrue(Assertion(model.ClientExplorer, content));
            await model.OpenClientFolder("folder");
            Assert.IsTrue(model.ClientExplorer.Count == 0);
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
