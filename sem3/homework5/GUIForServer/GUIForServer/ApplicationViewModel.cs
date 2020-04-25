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
        private int port = 8888;
        private string host = "127.0.0.1";
        private bool connectStatus;
        private RelayCommand connectCommand;
        private RelayCommand folderUpClient;
        private RelayCommand folderUpServer;
        private readonly ObservableCollection<string> clientPaths = new ObservableCollection<string>();
        private readonly ObservableCollection<(string, bool)> serverPaths = new ObservableCollection<(string, bool)>();
        private ObservableCollection<string> serverFiles;
        private string errorBox;

        /// <summary>
        /// root in client file hierarchy 
        /// </summary>
        public string ClientRoot { get; private set; }
        
        /// <summary>
        /// current opened directory in server
        /// </summary>
        public string CurrentServerDirectory { get; private set; }

        /// <summary>
        /// path to current opened directory in client
        /// </summary>
        public string CurrentClientDirectoryPath { get; private set; }

        /// <summary>
        /// current opened directory in client
        /// </summary>
        public string CurrentClientDirectory { get; private set; }

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
        public ObservableCollection<string> ClientExplorer { get; private set; }

        /// <summary>
        /// list of server files in form
        /// </summary>
        public ObservableCollection<string> ServerExplorer { get; private set; }

        /// <summary>
        /// event to change properties on Form
        /// </summary>
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
                if (CheckValidHost(host))
                {
                    host = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// port to connect
        /// </summary>
        public int Port
        {
            get => port;
            set
            {
                if (CheckValidPort(value))
                {
                    port = value;
                    OnPropertyChanged();
                }
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
                OnPropertyChanged();
            }
        }

        private bool CheckValidHost(string host) => host == client.Host;

        private bool CheckValidPort(int port) => port == client.Port;

        /// <summary>
        /// shows errors and warnings
        /// </summary>
        public string ErrorBox
        {
            get => errorBox;
            set
            {
                errorBox = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// application view model constructor
        /// </summary>
        /// <param name="root"> root in client hierarchy </param>
        public ApplicationViewModel(string root)
        {
            root = Directory.GetCurrentDirectory() + root;
            ClientRoot = root;
            destination = root;
            CurrentClientDirectoryPath = root;

            CurrentServerDirectory = "";
            CurrentClientDirectory = ClientRoot;

            ServerExplorer = new ObservableCollection<string>();
            ClientExplorer = new ObservableCollection<string>();

            clientPaths.CollectionChanged += ClientPathsChanged;
            UpdateClientPaths("");

            Task.Run(async () => await Connect());
        }

        private async Task Connect()
        {
            try
            {
                client = new Client();
                client.Connect(host, port);

                serverFiles = new ObservableCollection<string>();
                serverFiles.CollectionChanged += ServerPathsChanged;

                ServerExplorer.Clear();

                await UpdateServerPaths("");
                ConnectStatus = "Connected";
            }
            catch (SocketException)
            {
                ErrorBox = "Failed to connect";
                connectStatus = false;
            }
        }

        /// <summary>
        /// shows content in new folder in server
        /// </summary>
        /// <param name="path"> new folder </param>
        public void UpdateClientPaths(string path)
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
        /// shows content in new folder on server
        /// </summary>
        /// <param name="path"> new folder </param>
        public async Task UpdateServerPaths(string path)
        {
            await ListPaths(path);
        }

        private async Task ListPaths(string path)
        {
            var content = await client.List(path);

            while (serverPaths.Count > 0)
            {
                serverPaths.RemoveAt(serverPaths.Count - 1);
                serverFiles.RemoveAt(serverFiles.Count - 1);
            }

            foreach (var file in content)
            {
                serverPaths.Add(file);
            }
            foreach (var file in client.Files)
            {
                serverFiles.Add(file);
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
                  (connectCommand = new RelayCommand(async obj => await Connect()));

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
                      if (CurrentClientDirectory == ClientRoot)
                      {
                          ErrorBox = "Client root reached";
                          return;
                      }

                      CurrentClientDirectory = ChangeDirectoryPath(CurrentClientDirectory);
                      UpdateClientPaths(CurrentClientDirectory);
                      CurrentClientDirectoryPath = Directory.GetParent(CurrentClientDirectoryPath).ToString();
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
                  (folderUpServer = new RelayCommand(async obj =>
                  {
                      if (CurrentServerDirectory == "")
                      {
                          ErrorBox = "Server root reached";
                          return;
                      }

                      CurrentServerDirectory = ChangeDirectoryPath(CurrentServerDirectory);
                      await UpdateServerPaths(CurrentServerDirectory);
                  }));
            }
        }

        private string ChangeDirectoryPath(string directoryPath)
        {
            var index = directoryPath.LastIndexOf('\\');
            return (index > 0) ? directoryPath.Substring(0, index) :  "";
        }

        private void GoToClientRoot()
        {
            destination = ClientRoot;
            CurrentClientDirectoryPath = ClientRoot;
            UpdateClientPaths(ClientRoot);
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
                    GoToClientRoot();
                    return;
                }
                var path = CurrentServerDirectory + file;

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

        /// <summary>
        /// open folder on client
        /// </summary>
        public void OpenClientFolder(string folder)
        {
            if (Directory.Exists(Path.Combine(CurrentClientDirectoryPath, folder)))
            {
                CurrentClientDirectoryPath = Path.Combine(CurrentClientDirectoryPath, folder);
                CurrentClientDirectory = CurrentClientDirectoryPath;
                destination = Path.Combine(destination, folder);

                UpdateClientPaths(CurrentClientDirectoryPath);
                OnPropertyChanged("Destination");
            }
        }

        /// <summary>
        /// Open folder on server or download file
        /// </summary>
        public async Task OpenFolderOrLoad(string path)
        {
            try
            {
                var isFile = false;
                foreach (var file in serverPaths)
                {
                    if (path == file.Item1 && !file.Item2)
                    {
                        isFile = true;
                    }
                }

                if (isFile)
                {
                    await DownloadOneFile(path);
                    return;
                }

                CurrentServerDirectory = Path.Combine(CurrentServerDirectory, path);
                await UpdateServerPaths(CurrentServerDirectory);
            }
            catch (IOException e)
            {
                ErrorBox = e.Message;
            }
        }
    }
}