using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Test2
{
    /// <summary>
    /// ApplicationViewModel for game
    /// </summary>
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private XandOs game = new XandOs();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private RelayCommand newGame;

        public RelayCommand NewGame
        {
            get
            {
                return newGame ??
                  (newGame = new RelayCommand(obj =>
                  {
                      
                  }));
            }
        }
    }
}
