using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace GUIForServer
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Client client;

        private string destination;

        private string host = "127.0.0.1";

        private string port = "8888";

        private string path;

        private string content;

        private string connectStatus;

        private RelayCommand connect;

        private RelayCommand folderUpClient;

        private RelayCommand folderUpServer;

        private RelayCommand goToFolder;

        private ObservableCollection<string> clientPaths = new ObservableCollection<string>();

        private ObservableCollection<string> serverPaths = new ObservableCollection<string>();

        public string ClientRoot { get; private set; }

        private string errorBox;

        public string currentServerDirectory { get; private set; }

        public string currentClientDirectoryPath { get; private set; }

        public string currentClientDirectory { get; private set; }

        public ObservableCollection<string> LoadingFiles { get; private set; } = new ObservableCollection<string>(); 

        public ObservableCollection<string> LoadedFiles { get; private set; } = new ObservableCollection<string>();

        public ObservableCollection<string> ClientExplorer { get; private set; } = new ObservableCollection<string>();

        public ObservableCollection<string> ServerExplorer { get; private set; } = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string Host
        {
            get => host;
            set
            {
                host = value;
                OnPropertyChanged("Host");
            }
        }

        public string Port
        {
            get => port;
            set
            {
                port = value;
                OnPropertyChanged("Port");
            }
        }

        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public string ConnectStatus
        {
            get => connectStatus;
            set
            {
                connectStatus = client.Connected.ToString();
                OnPropertyChanged("ConnectStatus");
            }
        }

        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                OnPropertyChanged("Destination");
            }
        }

        public ApplicationViewModel(string root)
        {
            ClientRoot = root;
            destination = root;
            currentClientDirectoryPath = root;

            currentServerDirectory = "";
            currentClientDirectory = "";

            InitializeClientPaths();
        }

        public async Task InitializeClientPaths()
        {
            clientPaths.CollectionChanged += ClientPathsChanged;
            await UpdateClientPaths(ClientRoot);
        }

        public async Task InitializeServerPaths()
        {
            serverPaths.CollectionChanged += ServerPathsChanged;
            await UpdateServerPaths("");
        }

        private void ClientPathsChanged(object sender, NotifyCollectionChangedEventArgs e) => RefreshExplorer(ClientExplorer, e);

        private void ServerPathsChanged(object sender, NotifyCollectionChangedEventArgs e) => RefreshExplorer(ServerExplorer, e);

        private void RefreshExplorer(ObservableCollection<string> explorer, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (var file in e.OldItems)
                {
                    explorer.Remove(file.ToString());
                }
            }
            if (e.NewItems != null)
            {
                foreach (var file in e.NewItems)
                {
                    explorer.Add(file.ToString());
                }
            }
        }

        public async Task UpdateClientPaths(string path)
        {
            var folders = Directory.EnumerateDirectories(Path.Combine(ClientRoot, path));

            clientPaths.Clear();

            foreach (var folder in folders)
            {
                var file = folder.Substring(folder.LastIndexOf('\\') + 1);
                clientPaths.Add(file);
            }
        }

        public async Task UpdateServerPaths(string path)
        {
            var folders = (await client.List(path)).Split(' ');

            serverPaths.Clear();

            foreach (var folder in folders)
            {
                var file = folder.Substring(folder.LastIndexOf('\\') + 1);
                serverPaths.Add(file);
            }
        }

        public RelayCommand Connect
        {
            get
            {
                return connect ??
                  (connect = new RelayCommand(obj =>
                  {
                      if (int.TryParse(port, out int portValue))
                      {
                          var server = new Server(host, portValue); // границы
                          server.Process();
                          client = new Client();
                          client.Connect(host, portValue);
                          ConnectStatus = "true";
                          //client.Connected = true;
                          SetContent(path);
                      }
                  }));
            }
        }

        public RelayCommand FolderUpClient
        {
            get
            {
                return folderUpClient ??
                  (folderUpClient = new RelayCommand(obj =>
                  {
                      if (currentClientDirectory == "")
                      {

                      }
                      var index = currentClientDirectory.LastIndexOf('\\');
                      if (index > 0)
                      {
                          currentClientDirectory = currentClientDirectory.Substring(0, index);
                      }
                      else
                      {
                          currentClientDirectory = "";
                      }
                      UpdateClientPaths(currentClientDirectory);
                      currentClientDirectoryPath = Directory.GetParent(currentClientDirectoryPath).ToString();
                  }));
            }
        }

        public RelayCommand FolderUpServer
        {
            get
            {
                return folderUpServer ??
                  (folderUpServer = new RelayCommand(obj =>
                  {
                      if (currentServerDirectory == "")
                      {

                      }
                      var index = currentServerDirectory.LastIndexOf('\\');
                      if (index > 0)
                      {
                          currentServerDirectory = currentServerDirectory.Substring(0, index);
                      }
                      else
                      {
                          currentServerDirectory = "";
                      }
                      UpdateServerPaths(currentServerDirectory);
                  }));
            }
        }

        public async Task SetContent(string path) => Content = await client.List(path);

        public RelayCommand GoToFolder
        {
            get
            {
                return goToFolder ??
                  (goToFolder = new RelayCommand(obj =>
                  {
                      if (destination != currentClientDirectoryPath)
                      {
                          Destination = Path.Combine(currentClientDirectoryPath, "\\");
                      }
                  }));
            }
        }



        private RelayCommand load;

        public RelayCommand Load
        {
            get
            {
                return load ??
                  (load = new RelayCommand(obj =>
                  {
                      DownloadAllFiles();
                  }));
            }
        }

        public void OpenClientFolder(string folder)
        {
            if (Directory.Exists(Path.Combine(currentClientDirectoryPath, folder)))
            {
                currentClientDirectoryPath = Path.Combine(currentClientDirectory, folder);
                currentClientDirectory = currentClientDirectoryPath;
                UpdateClientPaths(currentClientDirectoryPath);
            }
        }

        public async Task OpenFolderOrLoad(string path)
        {
            if (IsFile(path))
            {
                await DownloadOneFile(path);
                return;
            }

            await UpdateServerPaths(Path.Combine(currentServerDirectory, path));
        }

        private bool IsFile(string folder)
        {
            foreach (var file in serverPaths)
            {
                if (folder == file && Directory.Exists(Path.Combine(currentServerDirectory, path)))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task DownloadOneFile(string file)
        {
            var path = Path.Combine(currentServerDirectory, file);

            LoadingFiles.Add(file);

            await client.Get(path, destination);

            LoadingFiles.Remove(file);
            LoadedFiles.Add(file);
        }

        public async Task DownloadAllFiles()
        {
            foreach (var file in serverPaths)
            {
                if (!Directory.Exists(Path.Combine(currentServerDirectory, file))) ///
                {
                    await DownloadOneFile(file);
                }
            }
        }

        //public string ErrorBox
        //{
        //    get { return errorBox; }
        //    set
        //    {
        //        errorBox = value;
        //        OnPropertyChanged("ErrorBox");
        //    }
        //}
    }
}
