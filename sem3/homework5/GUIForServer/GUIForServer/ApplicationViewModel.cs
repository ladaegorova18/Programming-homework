using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

//GUI для FTP
//Сделать на WPF GUI для FTP-клиента из домашней работы 5. 
//Нужно:
//иметь возможность указать папку в файловой системе клиента для скачивания файлов;
//иметь возможность скачать один файл или все файлы в текущей папке сразу;
//при этом скачивание нескольких файлов должно происходить параллельно, в клиенте должен как-нибудь отображаться статус файла --- скачивается или уже скачан.
//При этом:
//юнит-тесты на GUI можно не писать, но вся нетривиальная функциональность "бэкенда" должна быть протестирована.


namespace GUIForServer
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Client client; 

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private string host = "127.0.0.1";
        public string Host
        { get { return host; }
            set
            {
                host = value;
                OnPropertyChanged("Host");
            }
        }

        private string port = "8888";
        public string Port
        {
            get { return port; }
            set
            {
                port = value;
                OnPropertyChanged("Port");
            }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        private string path;
        public string PathTo
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged("PathTo");
            }
        }

        private RelayCommand connect;

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
                          //status.Content = "Connected";
                          SetContent(path);
                      }
                      else
                      {
                          //status.Content = "Connection failed";
                      }
                  }));
            }
        }

        private RelayCommand folderUp;

        public RelayCommand FolderUp
        {
            get
            {
                return folderUp ??
                  (folderUp = new RelayCommand(obj =>
                  {
                      var root = Directory.GetCurrentDirectory();
                      var length = root.Length;
                      var fullPath = Directory.GetCurrentDirectory() + PathTo;
                      if (root != fullPath)
                      {
                          var parent = Path.GetDirectoryName(fullPath);
                          parent = parent.Substring(length);
                          SetContent(parent);
                      }
                  }));
            }
        }

        public async Task SetContent(string path) => Content = await client.List(path);

        private RelayCommand goToFolder;

        public RelayCommand GoToFolder
        {
            get
            {
                return goToFolder ??
                  (goToFolder = new RelayCommand(obj => SetContent(PathTo)));
            }
        }
    }
}
