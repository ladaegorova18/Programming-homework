using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net.Sockets;

namespace GUIForServer
{
    /// <summary>
    /// Class to link form and FTP server logic
    /// </summary>
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Client client;

        private string destination;

        private string host = "127.0.0.1";

        private string port = "8888";

        private bool connectStatus;

        private RelayCommand connectCommand;

        private RelayCommand folderUpClient;

        private RelayCommand folderUpServer;

        private ObservableCollection<string> clientPaths = new ObservableCollection<string>();

        private ObservableCollection<(string, bool)> serverPaths = new ObservableCollection<(string, bool)>();

        private ObservableCollection<string> serverFiles = new ObservableCollection<string>();

        private string errorBox;

        /// <summary>
        /// root in client file hierarchy 
        /// </summary>
        public string ClientRoot { get; private set; }
        
        /// <summary>
        /// current opened directory in server
        /// </summary>
        public string currentServerDirectory { get; private set; }

        /// <summary>
        /// path to current opened directory in client
        /// </summary>
        public string currentClientDirectoryPath { get; private set; }

        /// <summary>
        /// current opened directory in client
        /// </summary>
        public string currentClientDirectory { get; private set; }

        /// <summary>
        /// list of downloading files
        /// </summary>
        public ObservableCollection<string> LoadingFiles { get; private set; } = new ObservableCollection<string>();

        /// <summary>
        /// list of downloaded files 
        /// </summary>
        public ObservableCollection<string> LoadedFiles { get; private set; } = new ObservableCollection<string>();

        /// <summary>
        /// list of client files in form
        /// </summary>
        public ObservableCollection<string> ClientExplorer { get; private set; } = new ObservableCollection<string>();

        /// <summary>
        /// list of server files in form
        /// </summary>
        public ObservableCollection<string> ServerExplorer { get; private set; } = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// changes value on form if value here was changed
        /// </summary>
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        /// <summary>
        /// host address to connect
        /// </summary>
        public string Host
        {
            get => host;
            set
            {
                host = value;
                OnPropertyChanged("Host");
            }
        }

        /// <summary>
        /// port to connect
        /// </summary>
        public string Port
        {
            get => port;
            set
            {
                port = value;
                OnPropertyChanged("Port");
            }
        }

        /// <summary>
        /// connection status
        /// </summary>
        public string ConnectStatus
        {
            get => connectStatus ? "connected" : "disconnected";
            set
            {
                connectStatus = client.Connected;
                OnPropertyChanged("ConnectStatus");
            }
        }

        public string ErrorBox
        {
            get => errorBox;
            set
            {
                errorBox = value;
                OnPropertyChanged("ErrorBox");
            }
        }

        /// <summary>
        /// path to download files
        /// </summary>
        public string Destination
        {
            get => destination.Substring(ClientRoot.Length);
            set
            {
                destination = Path.Combine(ClientRoot, value);
                OnPropertyChanged("Destination");
            }
        }

        /// <summary>
        /// application view model constructor
        /// </summary>
        /// <param name="root"> root in client hierarchy </param>
        public ApplicationViewModel(string root)
        {
            Connect();

            root = Directory.GetCurrentDirectory() + root;
            ClientRoot = root;
            destination = root;
            currentClientDirectoryPath = root;

            currentServerDirectory = "";
            //currentClientDirectory = "";
            currentClientDirectory = ClientRoot;

            InitializePaths();
        }

        /// <summary>
        /// initialize paths to folders on server and client
        /// </summary>
        public async Task InitializePaths()
        {
            clientPaths.CollectionChanged += ClientPathsChanged;
            await UpdateClientPaths("");

            serverFiles.CollectionChanged += ServerPathsChanged;
            await UpdateServerPaths("");
        }

        /// <summary>
        /// shows content in new folder in server
        /// </summary>
        /// <param name="path"> new folder </param>
        public async Task UpdateClientPaths(string path)
        {
            var folders = Directory.EnumerateDirectories(Path.Combine(ClientRoot, path));
            while (clientPaths.Count > 0)
            {
                clientPaths.RemoveAt(clientPaths.Count - 1);
            }

            foreach (var folder in folders)
            {
                var file = folder.Substring(folder.LastIndexOf('\\') + 1);
                clientPaths.Add(file);
            }
        }

        /// <summary>
        /// shows content in new folder in server
        /// </summary>
        /// <param name="path"> new folder </param>
        public async Task UpdateServerPaths(string path)
        {
            var content = await client.List(path);
            content = content.Substring(content.IndexOf(' ') + 1);
            var folders = content.Split('\t');
            while (serverPaths.Count > 0)
            {
                serverPaths.RemoveAt(serverPaths.Count - 1);
                serverFiles.RemoveAt(serverFiles.Count - 1);
            }

            foreach (var folder in folders)
            {
                var info = folder.Split(' ');
                var file = info[0].Substring(folder.LastIndexOf('\\') + 1);
                if (file != "")
                {
                    var isDir = info[1] == "True" ? true : false;
                    serverPaths.Add((file, isDir));
                    serverFiles.Add(file);
                }
            }
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

        /// <summary>
        /// connect to server command
        /// </summary>
        public RelayCommand ConnectCommand => connectCommand ??
                  (connectCommand = new RelayCommand(obj => Connect()));

        private void Connect()
        {
            try
            {
                if (int.TryParse(port, out int portValue))
                {
                    var server = new Server(host, portValue);
                    server.Process();
                    client = new Client();
                    client.Connect(host, portValue);
                    connectStatus = true;
                }
            }
            catch (SocketException)
            {
                ErrorBox = "Failed to connect";
                connectStatus = false;
            }
        }

        /// <summary>
        /// goes to upper level in client file hierarchy
        /// </summary>
        public RelayCommand FolderUpClient
        {
            get
            {
                return folderUpClient ??
                  (folderUpClient = new RelayCommand(obj =>
                  {
                      if (currentClientDirectory == ClientRoot)
                      {
                          ErrorBox = "Client root reached";
                          return;
                      }

                      currentClientDirectory = ChangeDirectoryPath(currentClientDirectory);
                      UpdateClientPaths(currentClientDirectory);
                      currentClientDirectoryPath = Directory.GetParent(currentClientDirectoryPath).ToString();
                      destination = Directory.GetParent(destination).ToString();
                      OnPropertyChanged("Destination");
                  }));
            }
        }

        /// <summary>
        /// goes to upper level in server file hierarchy
        /// </summary>
        public RelayCommand FolderUpServer
        {
            get
            {
                return folderUpServer ??
                  (folderUpServer = new RelayCommand(obj =>
                  {
                      if (currentServerDirectory == "")
                      {
                          ErrorBox = "Server root reached";
                          return;
                      }

                      currentServerDirectory = ChangeDirectoryPath(currentServerDirectory);
                      UpdateServerPaths(currentServerDirectory);
                  }));
            }
        }

        private string ChangeDirectoryPath(string directoryPath)
        {
            var index = directoryPath.LastIndexOf('\\');
            if (index > 0)
            {
                return directoryPath.Substring(0, index);
            }
            else
            {
                return "";
            }
        }

        private async Task GoToClientRoot()
        {
            destination = ClientRoot;
            currentClientDirectoryPath = ClientRoot;
            await UpdateClientPaths(ClientRoot);
        }

        /// <summary>
        /// downloads a file in a folder
        /// </summary>
        /// <param name="file"> file to download </param>
        public async Task DownloadOneFile(string file)
        {
            try
            {
                if (!Directory.Exists(destination))
                {
                    ErrorBox = "Directory not found!";
                    await GoToClientRoot();
                    return;
                }
                var path = Path.Combine(currentServerDirectory, file);

                LoadingFiles.Add(file);

                await client.Get(path, destination);

                LoadingFiles.Remove(file);
                LoadedFiles.Add(file);
            }
            catch (IOException e)
            {
                ErrorBox = e.Message;
            }
        }

        /// <summary>
        /// download all files in a folder
        /// </summary>
        public async Task DownloadAllFiles()
        {
            try
            {
                foreach (var file in serverPaths)
                {
                    if (!file.Item2)
                    {
                        await DownloadOneFile(file.Item1);
                    }
                }
            }
            catch (IOException e)
            {
                ErrorBox = e.Message;
            }
        }

        private RelayCommand load;

        /// <summary>
        /// download a file command
        /// </summary>
        public RelayCommand Load => load ??
                  (load = new RelayCommand(async obj => await DownloadAllFiles()));

        public async Task OpenClientFolder(string folder)
        {
            if (Directory.Exists(Path.Combine(currentClientDirectoryPath, folder)))
            {
                currentClientDirectoryPath = Path.Combine(currentClientDirectoryPath, folder);
                currentClientDirectory = currentClientDirectoryPath;
                destination = Path.Combine(destination, folder);
                await UpdateClientPaths(currentClientDirectoryPath);
                OnPropertyChanged("Destination");
            }
        }

        public async Task OpenFolderOrLoad(string path)
        {
            try
            {
                if (IsFile(path))
                {
                    await DownloadOneFile(path);
                    return;
                }

                currentServerDirectory = Path.Combine(currentServerDirectory, path);
                await UpdateServerPaths(currentServerDirectory);
            }
            catch (IOException e)
            {
                ErrorBox = e.Message;
            }
        }

        private bool IsFile(string folder)
        {
            foreach (var file in serverPaths)
            {
                if (folder == file.Item1 && !file.Item2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
