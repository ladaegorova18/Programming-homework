using System.Windows;
using System.Windows.Controls;

namespace GUIForServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationViewModel model;

        public MainWindow()
        {
            InitializeComponent();

            model = new ApplicationViewModel("..\\Downloads");

            DataContext = model;
        }

        private async void HandleServerDoubleClick(object sender, RoutedEventArgs e)
        {
            await model.OpenFolderOrLoad((sender as ListViewItem).Content.ToString());
        }
    }
}
