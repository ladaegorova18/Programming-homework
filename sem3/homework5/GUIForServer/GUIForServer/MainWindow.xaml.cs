using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUIForServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}


//GUI для FTP
//Сделать на WPF GUI для FTP-клиента из домашней работы 5. 
//Нужно:
//иметь возможность задать адрес и порт сервера;
//при подключении получить список файлов и подпапок папки, на которую "смотрит" сервер;
//иметь возможность перемещаться по папкам(переходить в подпапки и возвращаться на уровень выше, если он есть --- выходить выше "корневой" папки нельзя);
//иметь возможность указать папку в файловой системе клиента для скачивания файлов;
//иметь возможность скачать один файл или все файлы в текущей папке сразу;
//при этом скачивание нескольких файлов должно происходить параллельно, в клиенте должен как-нибудь отображаться статус файла --- скачивается или уже скачан.
//При этом:
//надо активно пользоваться Data Binding и паттерном Model-View-ViewModel;
//юнит-тесты на GUI можно не писать, но вся нетривиальная функциональность "бэкенда" должна быть протестирована.
